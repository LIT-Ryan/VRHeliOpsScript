using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangScript : MonoBehaviour
{
    HingeJoint cargoHinge;
    Rigidbody rb;
    public Transform ringPosition;
    public GameObject cargoPosition;
    private bool touch = false;
    private bool drop = false;
    // Update is called once per frame

    void Start()
    {
        cargoPosition.AddComponent<HingeJoint>();
        cargoHinge = cargoPosition.GetComponent<HingeJoint>();
        rb = this.GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ring")
        {
            
            cargoHinge.connectedBody = rb;
            //touch = true;
        }
    }
    private void Update()
    {
        if (touch && !drop)
        {
            //cargoPosition.transform.position = this.transform.position;
        }
    }

    public void Drop()
    {
        Destroy(cargoHinge);
        //drop = true;
    }
}