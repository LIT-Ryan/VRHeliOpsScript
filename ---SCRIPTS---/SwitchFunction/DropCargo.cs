using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Switch))]
public class DropCargo : MonoBehaviour
{
    public GameObject ropeHang;
    private Switch switchScript;
    private HangScript hangScript;
    // Start is called before the first frame update
    void Start()
    {
        hangScript = ropeHang.GetComponent<HangScript>();
        switchScript = this.gameObject.GetComponent<Switch>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (switchScript.isON)
        {
                hangScript.Drop();
            
        }
        
    }
}
