using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInput : MonoBehaviour
{
    public Transform pull;
    public float startRotation;
    public float currentRotation;
    public static float currentLiftInput;
    public float maxRotation = 90f;

    private void Start()
    {
        startRotation = pull.localEulerAngles.x;
    }
    void FixedUpdate()
    {
        if (TutorialScript.collectiveInputEnable_)
        {
            if (pull.localEulerAngles.x < maxRotation + 89f)
            {
                currentRotation = pull.localEulerAngles.x;
            }
            else
            {
                currentRotation = 360f - pull.localEulerAngles.x;
            }

            currentLiftInput = (((startRotation - currentRotation) / maxRotation) - 0.2f);

        }

        if (currentLiftInput >= 0.2f)
        {
            TutorialScript.collectivePulled_ = true;
        }


    }
}
