using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Camera Settings")]
    [SerializeField] private float mouseSensitivity = 10f;
    float aroundXRotation = 0f;
    float aroundYRotation = 0f;

    [Header("Transform")]
    [SerializeField] private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        aroundYRotation += mouseX;

        aroundXRotation -= mouseY;

        aroundXRotation = Mathf.Clamp(aroundXRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, aroundYRotation, 0f);
        //orientation.rotation = Quaternion.Euler(0f, 0, aroundYRotation);

        //playerTransform.Rotate(Vector3.up * mouseX);// Vector3.up = y-axis, rotating around y-axis -> looking right/left
    }

}
