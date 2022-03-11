using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    private float horizontalRotation;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = (Cursor.lockState==CursorLockMode.Locked)?CursorLockMode.None: CursorLockMode.Locked;
        }


        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        horizontalRotation = Input.GetAxis("Mouse X");

        transform.Translate(new Vector3(horizontalInput,0,verticalInput) * speed * Time.deltaTime);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            transform.Rotate(Vector3.up * horizontalRotation * rotationSpeed * Time.deltaTime);
        }
    }
}
