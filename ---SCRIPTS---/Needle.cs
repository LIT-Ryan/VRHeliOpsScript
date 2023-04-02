using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public GameObject HeliObj;
    public GameObject HeightObj;
    private float heightRotationZ;
    private float maxHeight = 2000f;
    public float feetValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        feetValue = maxHeight / 10f;
        heightRotationZ = maxHeight / 360f ;
        HeightObj.transform.localRotation = Quaternion.Euler(HeightObj.transform.localRotation.x , HeightObj.transform.localRotation.y , HeliObj.transform.position.y/feetValue);
    }
}
