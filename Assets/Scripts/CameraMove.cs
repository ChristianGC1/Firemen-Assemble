using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float rotationX;
    float mouseSens = 160f;

    public Transform player;

    void Start()
    {
        //Hide Mouse Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        float m_X = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX, 0f, 0f);

        player.Rotate(Vector3.up * m_X);
    }
}
