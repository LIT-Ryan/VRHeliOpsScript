using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelRefill : MonoBehaviour
{
    private AudioSource fuelAudio;
    private void Start()
    {
        fuelAudio = this.gameObject.GetComponent<AudioSource>();
    }
    public void OnTriggerStay(Collider other)
    {
        if ((other.CompareTag("Heli")) && GameManager.Fuel <=75 )
        {
            GameManager.Fuel += 7f  * Time.deltaTime;
        }
        if (GameManager.Fuel >= 70)
        {
            fuelAudio.volume -= Time.deltaTime;
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Heli")) && GameManager.Fuel <= 75)
        {
            fuelAudio.volume = 1;
            fuelAudio.Play();
            GameManager.Fuel += 3 * Time.deltaTime;
        }

    }
}
