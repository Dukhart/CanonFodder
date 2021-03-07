using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideToSide : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float amount;
    [SerializeField] float speed;
    Vector3 startPos;
    Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        // get start position
        startPos = transform.position;
        // get second end position
        endPos = startPos + (direction * -amount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move in dir at speed
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
    private void LateUpdate()
    {
        // check against last end position to prevent getting stuck
        if (Vector3.Distance(startPos, transform.position) > amount && Vector3.Distance(endPos, transform.position) > amount)
        {
            // new end is current end
            endPos = transform.position;
            // switch dir
            speed = -speed;
        }
    }
    // changes speed by amount
    public void ChangeSpeed (float amount)
    {
        // change amount based on direction of speed
        amount = speed < 0 ? -amount : amount;
        speed += amount;
    }
}
