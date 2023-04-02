using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    public static HookScript instance;
    public static bool drop = false;
    public GameObject cargoObj;
    public Transform cargoHold;
    public AudioSource hookAudio;
    Rigidbody rb;
    HingeJoint cargoHinge;
    //Rigidbody cargoRb;

    bool carry = false;
    // Start is called before the first frame update
    void Start()
    {
        if (cargoObj == null)
        {
            return;
        }
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //cargoObj.AddComponent<HingeJoint>();
       // cargoObj.AddComponent<Rigidbody>();
       // cargoRb = cargoObj.GetComponent<Rigidbody>();
       // cargoRb.drag = 1f;
        //cargoHinge = cargoObj.GetComponent<HingeJoint>();
      //  rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cargoObj == null)
        {
            return;
        }
        if (drop)
        {
            Drop();
        }
        if (carry)
        {
            Carry();
        }
   
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cargo")
        {
            GameManager.cargoOn_ = true;
            hookAudio.Play();
            Debug.Log("hit Cargo");
            cargoObj = other.gameObject;
            carry = true;
            
        }
    }

    public void Carry()
    {
        cargoObj.transform.position = cargoHold.position;
        cargoObj.transform.rotation = cargoHold.rotation;
        //cargoHinge.connectedBody = rb;
        //touch = true;
    }
    public void Drop()
    {
        GameManager.cargoOn_ = false;
        cargoObj = null;
        hookAudio.Play();
        //Destroy(cargoHinge);
        //cargoObj.transform.position = cargoHold.position;
        //cargoObj.transform.rotation = cargoHold.rotation;
        
        carry = false;
        drop = false;
    }
}
