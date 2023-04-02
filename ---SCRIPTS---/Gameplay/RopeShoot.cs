using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeShoot : MonoBehaviour
{
    
    public GameObject pp2;
    public GameObject pp3;
    public GameObject pp4;
    public GameObject ring;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, pp2.transform.position);
        lineRenderer.SetPosition(2, pp3.transform.position);
        lineRenderer.SetPosition(3, pp4.transform.position);
        lineRenderer.SetPosition(4, ring.transform.position);
    }
}
