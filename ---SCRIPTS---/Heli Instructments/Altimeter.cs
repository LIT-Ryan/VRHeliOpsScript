using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altimeter : MonoBehaviour
{
    public Transform heliTran;
    public GameObject altimeter100;
    public GameObject altimeter1000;
    public GameObject altimeter10000;
    public float heightMultiplyer = 10f;
    public static float height;
    float r100;
    float r1000;
    float r10000;

    void FixedUpdate()
    {
        height = heliTran.transform.position.y;
        if (height >= 0)
        {
            r100 = ((height * heightMultiplyer)/ 1000f) * -360f;
            r1000 = ((height * heightMultiplyer) / 10000f) * -360f;
            r10000 = ((height * heightMultiplyer) / 100000f) * -360f;
            altimeter100.transform.localRotation = Quaternion.Euler(0, 0, r100);
            altimeter1000.transform.localRotation = Quaternion.Euler(0, 0, r1000);
            altimeter10000.transform.localRotation = Quaternion.Euler(0, 0, r10000);
        }
        
        
    }
}
