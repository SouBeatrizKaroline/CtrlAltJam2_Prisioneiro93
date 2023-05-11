using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public float sensibilidade = 2.0f;

    private float mouseX = 0.0f, mouseY = 0.0f;

    private bool LockMouse = true;
    void Start()
    {
        if (!LockMouse)
        {
            return;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()
    {
        Mouse();
    }

    void Mouse()
    {
        mouseX += Input.GetAxis("Mouse X") * sensibilidade;
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
