using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    // Camera
    [SerializeField] Camera playerCamera;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 2.5f, -2.5f);
    [SerializeField] Vector3 cameraRotation = new Vector3(10, 0, 0);
    // Input
    private float horizontalAxis;
    private float verticalAxis;

    [SerializeField] float speedTilt;
    [SerializeField] float speedTurn;
    [SerializeField] float speedStrafe;


    // Start is called before the first frame update
    void Start()
    {
        weapon = Instantiate(weapon, transform);
    }
    private void FixedUpdate()
    {
        // get input
        GetInput();
        //LookAtMouse();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        // calculate position
        Vector3 pos = transform.forward * cameraOffset.z + transform.right * cameraOffset.x;
        pos.y = cameraOffset.y;
        pos = transform.position + pos;
        // calculate rotation
        Vector3 rot = transform.rotation.eulerAngles + cameraRotation;
        rot.x -= transform.rotation.eulerAngles.x;
        playerCamera.transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));
    }
    void GetInput ()
    {
        // Get Input
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down");
            weapon.GetComponent<Weapon>().Fire();
        }
        transform.Translate(Vector3.forward * horizontalAxis * speedStrafe * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * verticalAxis * speedTilt * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -speedTurn * Time.deltaTime, Space.World);
        } else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * speedTurn * Time.deltaTime, Space.World);
        }
        
    }
    void LookAtMouse ()
    {
        transform.LookAt(Input.mousePosition);
        Debug.Log(Input.mousePosition);
    }
    
}
