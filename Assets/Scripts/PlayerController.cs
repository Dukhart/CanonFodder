using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Camera
    [SerializeField] Camera playerCamera;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 2.5f, -2.5f);
    [SerializeField] Vector3 cameraRotation = new Vector3(10, 0, 0);
    // Input
    private float horizontalAxis;
    private float verticalAxis;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void FixedUpdate()
    {
        // get input
        GetInput();
        LookAtMouse();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        // update camera
        playerCamera.transform.SetPositionAndRotation(transform.position + cameraOffset, Quaternion.Euler(cameraRotation));
    }
    void GetInput ()
    {
        // Get Input
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
    }
    void LookAtMouse ()
    {
        transform.LookAt(Input.mousePosition);
        Debug.Log(Input.mousePosition);
    }
    
}
