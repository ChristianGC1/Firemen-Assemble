using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float pitch;
    float yaw;
    float mouseSensitivity = 160f;

    public Transform player;

    void Start()
    {
        //Hide Mouse Cursor
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        yaw += mouseX;
        transform.localEulerAngles = new Vector3(pitch, yaw, 0f);

        //player.Rotate(Vector3.up * mouseX);
    }
}
