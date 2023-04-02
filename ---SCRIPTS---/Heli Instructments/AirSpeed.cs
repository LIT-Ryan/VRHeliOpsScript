using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpeed : MonoBehaviour
{
    public Transform airSpeedNeedle;
    float z;

    void FixedUpdate()
    {
        z = SpeedCalculate.speedInput * 125f;
        airSpeedNeedle.transform.localRotation = Quaternion.Euler(0, 0, -z);
    }
}
