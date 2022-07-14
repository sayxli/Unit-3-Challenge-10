using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefactoredCharacterController : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private float maxXRotation = 30f;
    [SerializeField]
    private float minXRotation = 10f;

    [SerializeField]
    private Transform mainCameraTransform;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        characterMovement();
        characterRotation();
        
    }

    private void characterRotation()
    {
        float newRotation = mainCameraTransform.localRotation.eulerAngles.x - rotationSpeed * Input.GetAxis("Mouse Y");
        newRotation = Mathf.Clamp(newRotation, minXRotation, maxXRotation);
        mainCameraTransform.localRotation = Quaternion.Euler(newRotation, 0, 0);
    }

    private void characterMovement()
    {
        var moveForward = Input.GetAxis("Vertical") * speed * transform.forward * Time.deltaTime;
        var moveRight = Input.GetAxis("Horizontal") * speed * transform.right * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
            GetComponent<Rigidbody>().velocity = Vector3.up * 10;
    }
}
