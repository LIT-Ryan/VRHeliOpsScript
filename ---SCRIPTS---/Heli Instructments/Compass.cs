using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform heliTran;
    public Transform compass;
    public float z;
    void FixedUpdate()
    {
        z = heliTran.eulerAngles.y;
        compass.transform.localRotation = Quaternion.Euler(0, 0, z);
    }
}
