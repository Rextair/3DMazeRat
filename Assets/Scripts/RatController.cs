using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RatController : MonoBehaviour
{
   
    public Transform viewPoint;
    
    public float mouseSensitivity = 25f;
    private float verticalRotStore;
    private Vector2 mouseInput;
    public bool invertLook;
    
    public float moveSpeed = 5f, runSpeed = 8f;
    public float activateMoveSpeed;
    private Vector3 moveDir, movement;
    public CharacterController charCon;
    
    private Camera cam;
    
    public int maxSpawnCount = 3; 
    private int currentSpawnCount = -1; 
    
    [SerializeField] GameObject spawnedObjectPrefab; 
    private AudioSource breakGlassSound;
    public GameObject finishObject; 
    public Transform pointerObject; 
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        finishObject = GameObject.FindGameObjectWithTag("Fridge");
        breakGlassSound = GetComponent<AudioSource>();
        // Transform newTrans = SpawnManager.instance.GetRatSpawnPoint();
        // transform.position = newTrans.position; transform.rotation = newTrans.rotation;
        
    }
    void Update()
    {

        Rotation();
        Movement();
        CursorSettings();
        ObjectSpawning();
        Vector3 direction = finishObject.transform.position - pointerObject.position;
        pointerObject.rotation = Quaternion.LookRotation(direction);
    }
    void LateUpdate()
    {
        cam.transform.position = viewPoint.position;
        cam.transform.position = new Vector3(cam.transform.position.x, cam. transform.position.y + Mathf.Sin(Time.time*(activateMoveSpeed*2.5f)) * (0.1f*(Input.GetAxis("Horizontal")-Input.GetAxis("Vertical"))), cam.transform.position.z);
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
        //Debug.Log(Input.GetAxisRaw("Horizontal")-Input.GetAxisRaw("Vertical"));
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
    private void ObjectSpawning()
    {
       if (Input.GetButtonDown("Jump"))
        {
            currentSpawnCount++;
            if (currentSpawnCount < maxSpawnCount)
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {
        breakGlassSound.Play();
        GameObject spawnedObject = Instantiate(spawnedObjectPrefab, transform.position, Quaternion.identity);
        Destroy(spawnedObject, 10f); 
    }
}

