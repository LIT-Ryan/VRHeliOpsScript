using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialHorizon : MonoBehaviour
{
    public Transform heliTran;
    public Transform artificationNeedle;
    float z;
    float x;
    public float zMultuplier = 1.5f;
    public float xMultuplier = 1f;
    void FixedUpdate()
    {
        z = (heliTran.eulerAngles.z * zMultuplier);
        x = (heliTran.eulerAngles.x * -xMultuplier);

        artificationNeedle.transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y, 0);
        artificationNeedle.transform.localRotation = Quaternion.Euler(x, 0, transform.localRotation.z);

    }
}
