using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 45.0f;
    private const float Y_ANGLE_MAX = 45.0f;

    public Transform lookAT;
    public Transform camTransform;

    private Camera cam;

    private float distance = 50.0f;
    private float currentX = 10.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;
    Quaternion rotation;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void Awake()
    {
        rotation = transform.rotation;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        //Add currentY before currentX for the movement to work
        camTransform.position = lookAT.position + rotation * dir;
        camTransform.LookAt(lookAT.position);
        transform.rotation = rotation;
    }
}