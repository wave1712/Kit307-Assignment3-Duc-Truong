using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    private float startTime;

    void Start()
    {
        _cameraOffset = new Vector3(0f, 10f, -5f);
        startTime = Time.time;
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        float elapsedTime = Time.time - startTime;

        // Gradually adjust the Y (upward) and X (left) components of _cameraOffset
        _cameraOffset.y = Mathf.Lerp(_cameraOffset.y, 3f, Time.deltaTime * SmoothFactor);  // adjust for desired height
        _cameraOffset.x = Mathf.Lerp(_cameraOffset.x, -1f, Time.deltaTime * SmoothFactor);  // adjust for leftward shift

        // If elapsed time is around 30 seconds, move the camera backward.
        if (elapsedTime >= 30 && elapsedTime <= 35)
        {
            _cameraOffset.z = Mathf.Lerp(_cameraOffset.z, -8f, Time.deltaTime);  // Adjust the target Z value for the desired distance
        }
        else
        {
            _cameraOffset.z = Mathf.Lerp(_cameraOffset.z, -2f, Time.deltaTime * SmoothFactor);
        }

        Vector3 desiredPosition = PlayerTransform.position + _cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothFactor);

        transform.position = smoothedPosition;

        if (LookAtPlayer)
            transform.LookAt(PlayerTransform);
    }
}
