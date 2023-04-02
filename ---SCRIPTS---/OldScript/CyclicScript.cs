using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicScript : MonoBehaviour
{
    public Rigidbody rb;
    public float CyclicForce;
    public Transform heliTran;
    public float currentRotationHeli;
    public float maxRotationHeli;
    public static float movementInput;
    public Transform heliMovementTran;
    public float maxSpeed = 10;
    public float MaxLiftForce;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        float cyclicXForce = -CyclicTesting.currentInputZ * CyclicForce;
        rb.AddRelativeTorque(Vector3.forward * cyclicXForce, ForceMode.Acceleration);


        float cyclicYForce = -CyclicTesting.currentInputX * CyclicForce;
        rb.AddRelativeTorque(Vector3.right * cyclicYForce, ForceMode.Acceleration);

        HandleMovement();
        //HandleLift();
    }


    void HandleMovement()
    {

        if (heliTran.localRotation.eulerAngles.x < maxRotationHeli + 50)
        {
            movementInput = heliTran.localRotation.eulerAngles.x / maxRotationHeli;
        }
        else
        {
            movementInput = ((-360f + heliTran.localRotation.eulerAngles.x) / maxRotationHeli);
        }
        rb.AddRelativeForce(Vector3.forward * (movementSpeed * 100f) * movementInput , ForceMode.Force);

       



    }

    void HandleLift()
    {
        //Vector3 downForce = -(transform.up * Physics.gravity.magnitude);
        MaxLiftForce = LiftInput.currentLiftInput * 20f;
        HandleLift();
        Vector3 cyclicForce = transform.up *
                (UnityEngine.Physics.gravity.magnitude + MaxLiftForce) * rb.mass;

        cyclicForce *= Mathf.Pow(6, 0);
        rb.AddForce(cyclicForce, ForceMode.Force);
    }
}
