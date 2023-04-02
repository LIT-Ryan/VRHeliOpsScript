using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPM : MonoBehaviour
{
    public Transform heliTran;
    public GameObject rotor;
    public GameObject engine;
    public GameObject rpmLight;
    private float value = 0;
    private float value2 = 0;
    private float rotorAngle;
    private float engineAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        rpmLight.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.engineOn_)
        {
            rpmLight.SetActive(true);
        }
        if (value < 1f && GameManager.engineOn_)
        {
            value += Time.deltaTime / 6.7f;
        }
        if (value > 0.4f && value2 <1f)
        {
            value2 += Time.deltaTime / 8.2f;
        }
        rotorAngle = value * -279f;
        engineAngle = value2 * -278f;
        rotor.transform.localRotation = Quaternion.Euler(0, 0, rotorAngle);
        engine.transform.localRotation = Quaternion.Euler(0, 0, engineAngle);
        if (value2 >= 0.95f)
        {
            GameManager.RMP100On_ = true;
            rpmLight.SetActive(false);
        }

    }

    void StartEngine()
    {

    }
}
