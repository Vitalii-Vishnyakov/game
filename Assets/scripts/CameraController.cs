using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;
    private Transform perent;
    

    private void Start()
    {
        perent = transform.parent;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Ratate();
    }
    private void Ratate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        perent.Rotate(Vector3.up, mouseX);
    }
}
