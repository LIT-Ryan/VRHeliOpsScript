using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicTesting : MonoBehaviour
{
    public Transform cyclicStick;
    public static float currentInputX;
    public static float currentInputZ;
    public float currentInputXDisplay;
    public float currentInputZDisplay;
    public float currentRotationX;
    public float currentRotationZ;
    public float maxRotationX;
    public float maxRotationZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleRestore();
        if (TutorialScript.cyclicInputEnable)
        {
            if (cyclicStick.localRotation.eulerAngles.x < maxRotationX + 50)
            {
                currentRotationX = -cyclicStick.localRotation.eulerAngles.x;
            }
            else
            {
                currentRotationX = 360f - cyclicStick.localRotation.eulerAngles.x;
            }

            if (cyclicStick.localRotation.eulerAngles.z < maxRotationZ + 50)
            {
                currentRotationZ = -cyclicStick.localRotation.eulerAngles.z;
            }
            else
            {
                currentRotationZ = 360f - cyclicStick.localRotation.eulerAngles.z;
            }


            currentInputX = currentRotationX / maxRotationX;
            currentInputZ = currentRotationZ / maxRotationZ;

            //Debug.Log(transform.localRotation.x); ;
            //Debug.Log(transform.rotation.x);


            currentInputXDisplay = currentInputX;
            currentInputZDisplay = currentInputZ;

            if (!TutorialScript.cyclicUsed_ )
            {
                if (currentInputX > 0.3f)
                {
                    TutorialScript.cyclicUsed_ = true;
                }
                else if (currentInputX < -0.3f)
                {
                    TutorialScript.cyclicUsed_ = true;
                }
                else if (currentInputZ > 0.3f)
                {
                    TutorialScript.cyclicUsed_ = true;
                }
                else if (currentInputZ < -0.3f)
                {
                    TutorialScript.cyclicUsed_ = true;
                }
            }
            


        }
    }
        

    void HandleRestore()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), 2.0f * Time.deltaTime);
    }

    
}
