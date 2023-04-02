using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTest : MonoBehaviour
{
    public float MaxLiftForce;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxLiftForce = LiftInput.currentLiftInput * 30f;
        Vector3 cyclicForce = transform.up *
                (UnityEngine.Physics.gravity.magnitude + MaxLiftForce) * rb.mass;

        cyclicForce *= Mathf.Pow(6, 0);

        rb.AddForce(cyclicForce, ForceMode.Force);
        Debug.Log("Lift");



    }
}
