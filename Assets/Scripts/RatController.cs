using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
   
    public Transform viewPoint;
    public float mouseSensitivity = 25f;
    private float verticalRotStore;
    private Vector2 mouseInput;
    public bool invertLook;
    public float moveSpeed = 5f, runSpeed = 8f;
    private float activateMoveSpeed;
    private Vector3 moveDir, movement;
    public CharacterController charCon;
    private Camera cam;

    private int selectedGun;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }
    void Update()
    {
        Rotation();
        Movement();
        CursorSettings();
    }
    void LateUpdate()
    {
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }
    void CursorSettings()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Cursor.lockState == CursorLockMode.None)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    void Movement()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        if (Input.GetButton("Fire3"))
        {
            activateMoveSpeed = runSpeed;
        }
        else
        {
            activateMoveSpeed = moveSpeed;
        }

        float yVel = movement.y;
        movement = ((transform.forward * moveDir.z) + (transform.right * moveDir.x)).normalized * activateMoveSpeed;

        movement.y = yVel;
        if(charCon.isGrounded)
        {
            movement.y = 0f;
        }
        charCon.Move(movement * Time.deltaTime);
    }
    void Rotation()
    {
        mouseInput = new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity, 0);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x,
        transform.rotation.eulerAngles.z);

        verticalRotStore += verticalRotStore = Mathf.Clamp(verticalRotStore, -60f, 60f);
        if (invertLook)
        {
            viewPoint.transform.rotation = Quaternion.Euler(verticalRotStore,
            viewPoint.transform.rotation.eulerAngles.y, viewPoint.transform.rotation.eulerAngles.z);
        }
        else
        {
            viewPoint.transform.rotation = Quaternion.Euler(-verticalRotStore,
            viewPoint.transform.rotation.eulerAngles.y, viewPoint.transform.rotation.eulerAngles.z);
        }
    }
}
