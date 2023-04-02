using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AltitudeHoldTesting : MonoBehaviour
{
    Rigidbody rb;
    public float freezeY = 0f;
    public float smoothTime = 1f;
    public bool enable = false;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * 5f , ForceMode.Force );
        if (enable)
        {
            /*Vector3 newPosition = transform.position;
            newPosition.y = Mathf.SmoothDamp(transform.position.y, freezeY, ref velocity.y, smoothTime);
            transform.position = newPosition;
            */
            rb.velocity = Vector3.zero;
        }
        else if(Input.GetKeyDown(KeyCode.Z))
        {
            enable = true;
        }
    }
}
