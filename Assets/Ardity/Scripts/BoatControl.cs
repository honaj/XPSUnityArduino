using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public float turnSpeed = 5;
    Light boatLight;
    Rigidbody myBody;
    bool dead = false;
    void Start()
    {
        //Get lignt
        boatLight = GetComponentInChildren<Light>();
        //Get rigidbody
        myBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead) {
            //Always move forward
            transform.Translate (new Vector3 (0, speed * Time.deltaTime));
            //Rotate with arrow keys
            transform.Rotate (new Vector3 (0, 0, -1 * Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime));
        }
    }

    //Receive serial message from Arduino
    void OnMessageArrived(string msg) {
        boatLight.range = float.Parse(msg) / 80;
    }

    //Check if Arduino is connected
     void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }

    //Detect collision and kill
     void OnCollisionEnter (Collision col)
    {
        Debug.Log("You died!");
        dead = true;
    }
}
