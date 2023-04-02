using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PullTesting : MonoBehaviour
{
    public Transform pull;
    public float startRotation;
    public float currentRotation;
    public float currentInput;
    public float maxRotation = 90f;

    private void Start()
    {
        startRotation = pull.localEulerAngles.x;
    }
    void Update()
    {
        if (pull.localEulerAngles.x < maxRotation + 50f)
        {
            currentRotation = pull.localEulerAngles.x;        
        }
        else
        {
            currentRotation = 360f - pull.localEulerAngles.x;
        }

        currentInput = (startRotation - currentRotation) / maxRotation;


    }

    public void OnInspectorGUI ()
    {

    }

    
}
