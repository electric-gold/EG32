using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseCam : MonoBehaviour
{
    Vector3 velocity;
    public float bHeight = .25f;
    public float mouseSensitivity = 223.14f;
    public float bspeed = 120f;
    public float bgravity = -9.81f;
    public Transform playerBody;
    public Camera MainCam;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        if (Recoil.RecoilCheck == true)
        {

        }
        else
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            velocity.y = Mathf.Sqrt(bHeight * -2f * bgravity);
        }

    }
}
