using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Transform stickman;
    public AnimationCurve movementCurve;
    public AnimationCurve fallCurve;
    public AnimationCurve jumpCurve;
    public AnimationCurve turnCurve;
    public Animation anim;

    private float startTime;
    private bool hasTurned = false;
    private float turnStartTime;

    void Start()
    {
        // Create an animation component and a new clip
        anim = stickman.gameObject.AddComponent<Animation>();
        AnimationClip walkingClip = new AnimationClip();
        walkingClip.legacy = true;

        // Setup curves for the left leg
        Keyframe[] leftLegKeys = new Keyframe[3];
        leftLegKeys[0] = new Keyframe(0.0f, 10.0f);  
        leftLegKeys[1] = new Keyframe(0.5f, -10.0f);
        leftLegKeys[2] = new Keyframe(1.0f, 10.0f);
        AnimationCurve leftLegCurve = new AnimationCurve(leftLegKeys);

        walkingClip.SetCurve("Left Leg Attachment", typeof(Transform), "localEulerAngles.z", leftLegCurve);

        // Setup curves for the right leg
        Keyframe[] rightLegKeys = new Keyframe[3];
        rightLegKeys[0] = new Keyframe(0.0f, -10.0f);  
        rightLegKeys[1] = new Keyframe(0.5f, 10.0f);
        rightLegKeys[2] = new Keyframe(1.0f, -10.0f);
        AnimationCurve rightLegCurve = new AnimationCurve(rightLegKeys);

        walkingClip.SetCurve("Right Leg Attachment", typeof(Transform), "localEulerAngles.z", rightLegCurve);

        walkingClip.wrapMode = WrapMode.Loop;

        AnimationClip fallDownClip = new AnimationClip();
        fallDownClip.legacy = true;

        // Setup curves for the right shoulder
        Keyframe[] rightShoulderKeys = new Keyframe[3];
        rightShoulderKeys[0] = new Keyframe(0.0f, 0.0f);
        rightShoulderKeys[1] = new Keyframe(0.25f, 10.0f);
        rightShoulderKeys[2] = new Keyframe(0.5f, 0.0f);
        AnimationCurve rightShoulderCurve = new AnimationCurve(rightShoulderKeys);

        fallDownClip.SetCurve("Right Shoulder Joint", typeof(Transform), "localEulerAngles.z", rightShoulderCurve);

        // Setup curves for the left shoulder
        Keyframe[] leftShoulderKeys = new Keyframe[3];
        leftShoulderKeys[0] = new Keyframe(0.0f, 0.0f);
        leftShoulderKeys[1] = new Keyframe(0.25f, -10.0f);  
        leftShoulderKeys[2] = new Keyframe(0.5f, 0.0f);
        AnimationCurve leftShoulderCurve = new AnimationCurve(leftShoulderKeys);
        fallDownClip.SetCurve("Left Shoulder Joint", typeof(Transform), "localEulerAngles.z", leftShoulderCurve);

        fallDownClip.wrapMode = WrapMode.Once;
        anim.AddClip(fallDownClip, "fallDownClip");

        walkingClip.wrapMode = WrapMode.Loop;
        anim.AddClip(walkingClip, "walking");

        // Movement curve
        movementCurve = new AnimationCurve();
        movementCurve.AddKey(0.0f, 0.0f);  // Start
        movementCurve.AddKey(2.0f, -1.0f); // Move backward
        movementCurve.AddKey(8.0f, 1.0f);  // Move forward
        movementCurve.AddKey(13.0f, 1.0f); // Stay after jumping back up
        movementCurve.AddKey(17.0f, 3.0f); // Travel forward
        movementCurve.AddKey(18.0f, 3.0f); // Stand still
        movementCurve.AddKey(19.0f, 4.0f); // Move forward again
        movementCurve.AddKey(21.5f, 4.0f);  // Stay after getting up
        movementCurve.AddKey(24.5f, 7.0f);  // Walk forward for 3 seconds
        movementCurve.AddKey(28.5f, 7.0f);  // Stand still
        movementCurve.AddKey(28.5f, 7.0f);  // Start of jump
        movementCurve.AddKey(29.0f, 8.0f);  // Middle of jump
        movementCurve.AddKey(29.5f, 9.0f);  // End of jump

        // Fall curve
        fallCurve = new AnimationCurve();
        fallCurve.AddKey(0.0f, 0.0f);
        fallCurve.AddKey(0.5f, -90.0f);    // First fall
        fallCurve.AddKey(19.0f, 0.0f);     // Upright before second fall
        fallCurve.AddKey(19.5f, -90.0f);   // Second fall

        // Jump curve
        jumpCurve = new AnimationCurve();
        jumpCurve.AddKey(0.0f, -90.0f); // Starting from lying down
        jumpCurve.AddKey(0.5f, 0.0f);   // End at standing upright
        jumpCurve.AddKey(28.5f, 0.0f);  // Ground level at start of jump
        jumpCurve.AddKey(29.0f, 2.0f);  // Peak of jump (adjust to desired height)
        jumpCurve.AddKey(29.5f, 0.0f);  // Ground level at end of jump

        //Turn curve
        turnCurve = new AnimationCurve();
        turnCurve.AddKey(0.0f, 0.0f);    // Start at 0 degrees
        turnCurve.AddKey(1.0f, 180.0f);  // End at 180 degrees

        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (elapsedTime <= 8.0f)
        {
            //Walking Phase
            stickman.localPosition = new Vector3(movementCurve.Evaluate(elapsedTime), 0, 0);
            anim.Play("walking");
        }
        else if (elapsedTime > 8.0f && elapsedTime <= 8.5f)
        {
            //Falling Phase
            float fallAngle = fallCurve.Evaluate(elapsedTime - 8.0f);
            stickman.localRotation = Quaternion.Euler(fallAngle, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 8.5f && elapsedTime <= 12.5f)
        {
            //Lying Down Phase
            stickman.localRotation = Quaternion.Euler(-90.0f, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 12.5f && elapsedTime <= 13.0f)
        {
            //Jumping Phase
            float jumpAngle = jumpCurve.Evaluate(elapsedTime - 12.5f);
            stickman.localRotation = Quaternion.Euler(jumpAngle, 0, 0);
            anim.Play("walking");
        }
        else if (elapsedTime > 13.0f && elapsedTime <= 17.0f)
        {
            //Travel Forward Phase
            stickman.localPosition = new Vector3(movementCurve.Evaluate(elapsedTime), 0, 0);
            anim.Play("walking");
        }
        else if (elapsedTime > 17.0f && elapsedTime <= 18.0f)
        {
            //Stand still
            stickman.localPosition = new Vector3(3.0f, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 18.0f && elapsedTime <= 19.0f)
        {
            //Move forward
            stickman.localPosition = new Vector3(movementCurve.Evaluate(elapsedTime), 0, 0);
            anim.Play("walking");
        }
        else if (elapsedTime > 19.0f && elapsedTime <= 19.5f)
        {
            //Second Falling
            float fallAngle = fallCurve.Evaluate(elapsedTime - 19.0f);
            stickman.localRotation = Quaternion.Euler(fallAngle, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 19.5f && elapsedTime <= 21.5f)
        {
            //Lying Down after Second Fall
            stickman.localRotation = Quaternion.Euler(-90.0f, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 21.5f && elapsedTime <= 22.0f)
        {
            //Getting Up
            float jumpAngle = jumpCurve.Evaluate(elapsedTime - 21.5f);
            stickman.localRotation = Quaternion.Euler(jumpAngle, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 22.0f && elapsedTime <= 25.0f)
        {
            //Walk forward
            stickman.localPosition = new Vector3(movementCurve.Evaluate(elapsedTime), 0, 0);
            stickman.localRotation = Quaternion.Euler(0.0f, 0, 0);
            anim.Play("walking");
        }
        else if (elapsedTime > 25.0f && elapsedTime <= 28.5f)
        {
            //Stand still
            stickman.localPosition = new Vector3(7.0f, 0, 0);
            stickman.localRotation = Quaternion.Euler(0.0f, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 28.5f && elapsedTime <= 29.5f)
        {
            //Jumping over an object phase
            float jumpPositionX = movementCurve.Evaluate(elapsedTime);
            float jumpPositionY = jumpCurve.Evaluate(elapsedTime);
            stickman.localPosition = new Vector3(jumpPositionX, jumpPositionY, 0);
            stickman.localRotation = Quaternion.Euler(0.0f, 0, 0);
            anim.Play("walking");
        }

        else if (elapsedTime > 29.5f && elapsedTime <= 30.5f)
        {
            if (!hasTurned)
            {
                turnStartTime = Time.time;
                hasTurned = true;
            }

            float turnElapsedTime = Time.time - turnStartTime;
            float turnAngle = turnCurve.Evaluate(turnElapsedTime);
            stickman.localRotation = Quaternion.Euler(0.0f, turnAngle, 0.0f);

            stickman.localPosition = new Vector3(9.0f, 0, 0);
            anim.Stop("walking");
        }
        else if (elapsedTime > 30.5f)
        {
            stickman.localPosition = new Vector3(9.0f, 0, 0);
            stickman.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }

    }
}

