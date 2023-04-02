using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliPedal : MonoBehaviour
{
    public InputManager inputManagerScript;
    public Rigidbody rb;
    public GameObject heli;
    public float TailMaxForce;
    public float autoRotateForce;
    public float TailForceSpeed=1;
    public float smoothTime = 5f;
    private float lastSpeedInput;
    private float rotation;
    private float horizontalVelocity;
    private float currentInput;
    private float targetJoyInput = 0;
    public float slowingFactor = 10f;

    public GameObject leftPedalObj;
    public GameObject rightPedalObj;

    private float pedalTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        inputManagerScript = GameObject.Find("InputManagerObj").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TutorialScript.pedalInputEnable_)
        {
            PedalMove();
            if (inputManagerScript.rJoystickInput < 0)
            {

                //leftPedalObj.transform.localRotation = Quaternion.Euler( ((Mathf.Abs(inputManagerScript.rJoystickInput)) * 50 ), 0,0 );
            }
            else
            {

                //rightPedalObj.transform.localRotation = Quaternion.Euler(((Mathf.Abs(inputManagerScript.rJoystickInput)) * 50), 0, 0);
            }

            if (inputManagerScript.rJoystickInput > 0.1f && !TutorialScript.pedalUsed_)
            {
                pedalTime += Time.deltaTime;
            }
            else if (inputManagerScript.rJoystickInput < -0.1f && !TutorialScript.pedalUsed_)
            {
                pedalTime += Time.deltaTime;
            }
            else
            {
                pedalTime = 0;
            }
            
            if (pedalTime >= 2f)
            {
                TutorialScript.pedalUsed_ = true;
            }

            targetJoyInput = Mathf.Lerp(targetJoyInput, inputManagerScript.rJoystickInput, Time.deltaTime * TailForceSpeed);
            rb.AddTorque(Vector3.up * targetJoyInput * TailMaxForce, ForceMode.Acceleration);
            Vector3 angularVelocity = rb.angularVelocity;
            angularVelocity = Vector3.Lerp(angularVelocity, Vector3.zero, slowingFactor * Time.fixedDeltaTime);
            rb.angularVelocity = angularVelocity;
            /*float rotation = Mathf.SmoothDamp(0, TailMaxForce * inputManagerScript.rJoystickInput * 20f, ref horizontalVelocity, smoothTime);
            transform.Rotate(Vector3.up, rotation * Time.deltaTime);*/
            // heli.transform.Rotate(Vector3.up, TailMaxForce * inputManagerScript.rJoystickInput * Time.deltaTime);
            if (float.IsNaN(SpeedCalculate.speedInput))
            {
                rb.AddTorque(Vector3.up * (CyclicTesting.currentInputZ / 2) * lastSpeedInput * autoRotateForce, ForceMode.Acceleration);
            }
            else
            {
                rb.AddTorque(Vector3.up * (CyclicTesting.currentInputZ / 2) * SpeedCalculate.speedInput * autoRotateForce, ForceMode.Acceleration);
                lastSpeedInput = SpeedCalculate.speedInput;
                //
            }
            //lastSpeedInput = currentInput;
            //}

        }


    }

    void PedalMove()
    {
        leftPedalObj.transform.localPosition = new Vector3(leftPedalObj.transform.localPosition.x, leftPedalObj.transform.localPosition.y, (inputManagerScript.rJoystickInput * 0.07f / 1f *( -1)));
        rightPedalObj.transform.localPosition = new Vector3(rightPedalObj.transform.localPosition.x, rightPedalObj.transform.localPosition.y, ((inputManagerScript.rJoystickInput * 0.07f / 1f)));
    }
}
