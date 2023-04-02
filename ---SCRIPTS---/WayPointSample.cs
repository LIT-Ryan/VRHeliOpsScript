using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSample : MonoBehaviour
{
    public GameObject nextWaypoint;
    public AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        audios.Play();
        nextWaypoint.SetActive(true);
        Destroy(gameObject);
    }
}
