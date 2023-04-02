using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticleSpeed : MonoBehaviour
{
    public Transform verticleNeedle;
    float z;

    void FixedUpdate()
    {
        z = SpeedCalculate.liftSpeedInput * 150f;
        verticleNeedle.transform.localRotation = Quaternion.Euler(0, 0, z);
    }
}
