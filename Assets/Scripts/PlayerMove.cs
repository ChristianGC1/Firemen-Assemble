using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
    }
}
