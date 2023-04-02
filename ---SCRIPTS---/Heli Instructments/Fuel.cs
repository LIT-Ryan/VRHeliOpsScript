using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private bool first;
    public GameObject fuelLight;
    public GameObject fuelNeedle;
    float fuelDecreaseSpeed = 1f/10f; // fuel decrease speed per second
    float z;
    public void Start()
    {
        fuelLight.SetActive(false);
        GameManager.Fuel = 0;
        first = true;
    }
    void FixedUpdate()
    {
        if (GameManager.fuelOn_)
        {
            if (first)
            {
                if (GameManager.Fuel <= 75)
                {
                    GameManager.Fuel += 7f * Time.deltaTime;
                }
                if (GameManager.Fuel >= 74)
                {
                    first = false;
                }
            }
            GameManager.Fuel -= fuelDecreaseSpeed * Time.deltaTime;
            GameManager.Fuel = Mathf.Max(GameManager.Fuel, 0f); // prevent fuel from going below 0
            z = -212f * (GameManager.Fuel / 75f);
            fuelNeedle.transform.localRotation = Quaternion.Euler(0, 0, z);
            if (GameManager.Fuel <= 25f)
            {
                fuelLight.SetActive(true);
            }
            else
            {
                fuelLight.SetActive(false);
            }
        }
        else
        {

        }
        

    }
}
