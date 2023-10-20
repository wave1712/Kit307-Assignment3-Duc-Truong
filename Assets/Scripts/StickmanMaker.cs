using System;
using UnityEngine;

public class StickmanMaker : MonoBehaviour
{
    public GameObject footLeft, handRight;
    public GameObject shinLeft, thighLeft, hipLeft, shinRight, thighRight, hipRight, calfRight, calfLeft;
    public GameObject ankleLeftjoint, kneeLeftjoint, hipLeftjoint, ankleRightjoint, kneeRightjoint, hipRightjoint;

    void Start()
    {
        CreateHead();
        CreateLeftLeg();
        CreateRightLeg();
        CreateBody();
        CreateLeftArm();
        CreateRightArm();
    }


    void CreateBody()
    {
        GameObject body = new GameObject("StickmanBody");
        MeshRenderer bodyRenderer = body.AddComponent<MeshRenderer>();
        bodyRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter bodyFilter = body.AddComponent<MeshFilter>();
        bodyFilter.mesh = MeshUtilities.Cube(0.2f); // Assuming 0.1f as the size, adjust as needed

        body.transform.parent = transform;
        body.transform.localPosition = new Vector3(-0.049f, 0.6f, 0.1f); // Adjusted for a cube of size 0.1f
        body.transform.localScale = new Vector3(0.5f, 1.123f, 1f); //Scale Body

    }

    void CreateHead()
    {
        GameObject head = new GameObject("Head");
        MeshRenderer headRenderer = head.AddComponent<MeshRenderer>();
        headRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter headFilter = head.AddComponent<MeshFilter>();
        headFilter.mesh = MeshUtilities.Cube(0.2f); // Assuming 0.1f as the size, adjust as needed

        head.transform.parent = transform;
        head.transform.localPosition = new Vector3(-0.049f, 0.903f, 0.1039f); // Adjusted for a cube of size 0.1f
        head.transform.localScale = new Vector3(0.5f, 0.4040341f, 0.5291486f); //Scale Body
    }

    void CreateLeftArm()
    {
        // Create arm attachment point (smaller cylinder)
        GameObject armLeft = new GameObject("Left Arm");
        MeshRenderer armLeftRenderer = armLeft.AddComponent<MeshRenderer>();
        armLeftRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter armLeftFilter = armLeft.AddComponent<MeshFilter>();
        armLeftFilter.mesh = MeshUtilities.Cube(0.03f);

        // Set it as a child of the main stickman object
        armLeft.transform.parent = transform;
        armLeft.transform.localPosition = new Vector3(-0.114f, 0.742f, 0.314f); 

        // Create the joints for the left arm
        GameObject shoulderLeftjoint = new GameObject("Left Shoulder Joint");
        shoulderLeftjoint.transform.parent = transform;
        shoulderLeftjoint.transform.localPosition = new Vector3(-0.1046f, 0.8706f, 0.2861f); 
        shoulderLeftjoint.transform.localRotation = Quaternion.Euler(-11.202f, -29.844f, 2.405f);

        GameObject elbowLeftjoint = new GameObject("Left Elbow Joint");
        elbowLeftjoint.transform.parent = shoulderLeftjoint.transform;
        elbowLeftjoint.transform.localPosition = new Vector3(0.0074f, -0.2034f, 0.0017f);
        elbowLeftjoint.transform.localRotation = Quaternion.Euler(new Vector3(10.003f, 18.091f, 16.784f));

        // Create the sweep profile for the left arm
        Vector3[] armLeftProfile = new Vector3[10]
        {
        new Vector3(0.0f, -0.05f, 0.0f),
        new Vector3(0.01f, -0.04f, 0.0f),
        new Vector3(0.015f, -0.02f, 0.0f),
        new Vector3(0.015f, 0.15f, 0.0f),
        new Vector3(0.01f, 0.18f, 0.0f),
        new Vector3(0.0f, 0.2f, 0.0f),
        new Vector3(-0.01f, 0.18f, 0.0f),
        new Vector3(-0.015f, 0.15f, 0.0f),
        new Vector3(-0.015f, -0.02f, 0.0f),
        new Vector3(-0.01f, -0.04f, 0.0f)
        };

        // Create the arm path with transformations
        Matrix4x4[] armLeftPath = new Matrix4x4[10];
        armLeftPath[0] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        armLeftPath[1] = armLeftPath[0];
        armLeftPath[2] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        armLeftPath[3] = armLeftPath[2];
        armLeftPath[4] = Matrix4x4.Translate(new Vector3(0, 0, -0.0075f));
        armLeftPath[5] = armLeftPath[4];
        armLeftPath[6] = Matrix4x4.Translate(new Vector3(0, 0, 0.0075f));
        armLeftPath[7] = armLeftPath[6];
        armLeftPath[8] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));
        armLeftPath[9] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));

        // Create the arm using the sweep function
        GameObject forearmLeft = new GameObject("Left Forearm");
        MeshRenderer forearmLeftRenderer = forearmLeft.AddComponent<MeshRenderer>();
        forearmLeftRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter forearmLeftFilter = forearmLeft.AddComponent<MeshFilter>();
        forearmLeftFilter.mesh = MeshUtilities.Sweep(armLeftProfile, armLeftPath, false);

        // Attach the forearm to the elbow joint
        forearmLeft.transform.parent = elbowLeftjoint.transform;
        forearmLeft.transform.localPosition = new Vector3(0, -0.15f, 0);
        forearmLeft.transform.localRotation = Quaternion.identity;
    }

    void CreateRightArm()
    {
        // Create arm attachment point (smaller cube)
        GameObject armRight = new GameObject("Right Arm");
        MeshRenderer armRightRenderer = armRight.AddComponent<MeshRenderer>();
        armRightRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter armRightFilter = armRight.AddComponent<MeshFilter>();
        armRightFilter.mesh = MeshUtilities.Cube(0.03f);

        // Set it as a child of the main stickman object
        armRight.transform.parent = transform;
        armRight.transform.localPosition = new Vector3(0.0314f, 0.742f, -0.1103f);

        // Create the joints for the right arm
        GameObject shoulderRightJoint = new GameObject("Right Shoulder Joint");
        shoulderRightJoint.transform.parent = transform;
        shoulderRightJoint.transform.localPosition = new Vector3(0.0359f, 0.8706f, -0.1461f);
        shoulderRightJoint.transform.localRotation = Quaternion.Euler(-11.202f, -29.844f, 2.405f);

        GameObject elbowRightJoint = new GameObject("Right Elbow Joint");
        elbowRightJoint.transform.parent = shoulderRightJoint.transform;
        elbowRightJoint.transform.localPosition = new Vector3(0.0074f, -0.2034f, 0.0017f);
        elbowRightJoint.transform.localRotation = Quaternion.Euler(new Vector3(10.003f, 18.091f, 16.784f));

        // Create the sweep profile for the right arm
        Vector3[] armRightProfile = new Vector3[10]
            {
        new Vector3(0.0f, -0.05f, 0.0f),
        new Vector3(0.01f, -0.04f, 0.0f),
        new Vector3(0.015f, -0.02f, 0.0f),
        new Vector3(0.015f, 0.15f, 0.0f),
        new Vector3(0.01f, 0.18f, 0.0f),
        new Vector3(0.0f, 0.2f, 0.0f),
        new Vector3(-0.01f, 0.18f, 0.0f),
        new Vector3(-0.015f, 0.15f, 0.0f),
        new Vector3(-0.015f, -0.02f, 0.0f),
        new Vector3(-0.01f, -0.04f, 0.0f)
        };

        // Create the arm path with transformations
        Matrix4x4[] armRightpath = new Matrix4x4[10];
        armRightpath[0] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        armRightpath[1] = armRightpath[0];
        armRightpath[2] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        armRightpath[3] = armRightpath[2];
        armRightpath[4] = Matrix4x4.Translate(new Vector3(0, 0, -0.0075f));
        armRightpath[5] = armRightpath[4];
        armRightpath[6] = Matrix4x4.Translate(new Vector3(0, 0, 0.0075f));
        armRightpath[7] = armRightpath[6];
        armRightpath[8] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));
        armRightpath[9] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));

        // Create the arm using the sweep function
        GameObject forearmRight = new GameObject("Right Forearm");
        MeshRenderer forearmRightRenderer = forearmRight.AddComponent<MeshRenderer>();
        forearmRightRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter forearmRightFilter = forearmRight.AddComponent<MeshFilter>();
        forearmRightFilter.mesh = MeshUtilities.Sweep(armRightProfile, armRightpath, false);

        // Attach the forearm to the elbow joint
        forearmRight.transform.parent = elbowRightJoint.transform;
        forearmRight.transform.localPosition = new Vector3(0, -0.15f, 0);
        forearmRight.transform.localRotation = Quaternion.identity;
    }

    void CreateLeftLeg()
    {
        // Create leg attachment point (smaller cube)
        GameObject legLeftAttachment = new GameObject("Left Leg Attachment");
        MeshRenderer legLeftAttachRenderer = legLeftAttachment.AddComponent<MeshRenderer>();
        legLeftAttachRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter legLeftAttachFilter = legLeftAttachment.AddComponent<MeshFilter>();
        legLeftAttachFilter.mesh = MeshUtilities.Cube(0.03f);

        // Set it as a child of the main stickman object
        legLeftAttachment.transform.parent = transform;
        legLeftAttachment.transform.localPosition = new Vector3(-0.014f, 0.35f, 0.203f);

        // Create the joints for the left leg
        GameObject hipLeftJoint = new GameObject("Left Hip Joint");
        hipLeftJoint.transform.parent = transform;
        hipLeftJoint.transform.localPosition = new Vector3(0.0379f, 0.466731f, 0.164f);
        hipLeftJoint.transform.localRotation = Quaternion.Euler(-15.513f, -11.092f, -16.221f);

        GameObject kneeLeftJoint = new GameObject("Left Knee Joint");
        kneeLeftJoint.transform.parent = hipLeftJoint.transform;
        kneeLeftJoint.transform.localPosition = new Vector3(0.0074f, -0.2034f, 0.0017f);
        kneeLeftJoint.transform.localRotation = Quaternion.Euler(new Vector3(10.003f, 18.091f, 16.784f));

        // Create the sweep profile for the left leg
        Vector3[] legLeftProfile = new Vector3[10]
            {
        new Vector3(0.0f, -0.05f, 0.0f),
        new Vector3(0.01f, -0.04f, 0.0f),
        new Vector3(0.015f, -0.02f, 0.0f),
        new Vector3(0.015f, 0.15f, 0.0f),
        new Vector3(0.01f, 0.18f, 0.0f),
        new Vector3(0.0f, 0.2f, 0.0f),
        new Vector3(-0.01f, 0.18f, 0.0f),
        new Vector3(-0.015f, 0.15f, 0.0f),
        new Vector3(-0.015f, -0.02f, 0.0f),
        new Vector3(-0.01f, -0.04f, 0.0f)
        };

        // Create the arm path with transformations
        Matrix4x4[] legLeftPath = new Matrix4x4[10];
        legLeftPath[0] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        legLeftPath[1] = legLeftPath[0];
        legLeftPath[2] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        legLeftPath[3] = legLeftPath[2];
        legLeftPath[4] = Matrix4x4.Translate(new Vector3(0, 0, -0.0075f));
        legLeftPath[5] = legLeftPath[4];
        legLeftPath[6] = Matrix4x4.Translate(new Vector3(0, 0, 0.0075f));
        legLeftPath[7] = legLeftPath[6];
        legLeftPath[8] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));
        legLeftPath[9] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));

        // Create the leg using the sweep function
        GameObject calfLeft = new GameObject("Left Calf");
        MeshRenderer calfLeftRenderer = calfLeft.AddComponent<MeshRenderer>();
        calfLeftRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter calfLeftFilter = calfLeft.AddComponent<MeshFilter>();
        calfLeftFilter.mesh = MeshUtilities.Sweep(legLeftProfile, legLeftPath, false);

        // Attach the calf to the knee joint
        calfLeft.transform.parent = kneeLeftJoint.transform;
        calfLeft.transform.localPosition = new Vector3(0, -0.15f, 0);
        calfLeft.transform.localRotation = Quaternion.identity;

        // Attach the knee joint to the hip joint
        kneeLeftJoint.transform.parent = hipLeftJoint.transform;

        // Attach the hip joint to the leg attachment
        hipLeftJoint.transform.parent = legLeftAttachment.transform;
    }

    void CreateRightLeg()
    {
        // Create leg attachment point (smaller cube)
        GameObject legRightAttachment = new GameObject("Right Leg Attachment");
        MeshRenderer legRightAttachRenderer = legRightAttachment.AddComponent<MeshRenderer>();
        legRightAttachRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter legRightAttachFilter = legRightAttachment.AddComponent<MeshFilter>();
        legRightAttachFilter.mesh = MeshUtilities.Cube(0.03f);

        // Set it as a child of the main stickman object
        legRightAttachment.transform.parent = transform;
        legRightAttachment.transform.localPosition = new Vector3(-0.014f, 0.35f, 0.017f);

        // Create the joints for the right leg
        GameObject hipRightJoint = new GameObject("Right Hip Joint");
        hipRightJoint.transform.parent = transform;
        hipRightJoint.transform.localPosition = new Vector3(0.0379f, 0.466731f, -0.02199997f);
        hipRightJoint.transform.localRotation = Quaternion.Euler(-15.513f, -11.092f, -16.221f);

        GameObject kneeRightJoint = new GameObject("Right Knee Joint");
        kneeRightJoint.transform.parent = hipRightJoint.transform;
        kneeRightJoint.transform.localPosition = new Vector3(0.0074f, -0.2034f, 0.0017f);
        kneeRightJoint.transform.localRotation = Quaternion.Euler(new Vector3(10.003f, 18.091f, 16.784f));

        // Create the sweep profile for the right leg
        Vector3[] legRightProfile = new Vector3[10]
        {
        new Vector3(0.0f, -0.05f, 0.0f),
        new Vector3(0.01f, -0.04f, 0.0f),
        new Vector3(0.015f, -0.02f, 0.0f),
        new Vector3(0.015f, 0.15f, 0.0f),
        new Vector3(0.01f, 0.18f, 0.0f),
        new Vector3(0.0f, 0.2f, 0.0f),
        new Vector3(-0.01f, 0.18f, 0.0f),
        new Vector3(-0.015f, 0.15f, 0.0f),
        new Vector3(-0.015f, -0.02f, 0.0f),
        new Vector3(-0.01f, -0.04f, 0.0f)
        };

        // Create the arm path with transformations
        Matrix4x4[] legRightpath = new Matrix4x4[10];
        legRightpath[0] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        legRightpath[1] = legRightpath[0];
        legRightpath[2] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.01f));
        legRightpath[3] = legRightpath[2];
        legRightpath[4] = Matrix4x4.Translate(new Vector3(0, 0, -0.0075f));
        legRightpath[5] = legRightpath[4];
        legRightpath[6] = Matrix4x4.Translate(new Vector3(0, 0, 0.0075f));
        legRightpath[7] = legRightpath[6];
        legRightpath[8] = Matrix4x4.Scale(new Vector3(0.9f, 0.98f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));
        legRightpath[9] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.01f));

        // Create the leg using the sweep function
        GameObject calfRight = new GameObject("Right Calf");
        MeshRenderer calfRightRenderer = calfRight.AddComponent<MeshRenderer>();
        calfRightRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter calfRightFilter = calfRight.AddComponent<MeshFilter>();
        calfRightFilter.mesh = MeshUtilities.Sweep(legRightProfile, legRightpath, false);

        // Attach the calf to the knee joint
        calfRight.transform.parent = kneeRightJoint.transform;
        calfRight.transform.localPosition = new Vector3(0, -0.15f, 0);
        calfRight.transform.localRotation = Quaternion.identity;

        // Attach the knee joint to the hip joint
        kneeRightJoint.transform.parent = hipRightJoint.transform;

        // Attach the hip joint to the leg attachment
        hipRightJoint.transform.parent = legRightAttachment.transform;
    }
}
