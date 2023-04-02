using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeli : MonoBehaviour
{
    Transform parentTransform;
    Transform childTransform;
    public bool isTrigger = false;
    public bool buttonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        parentTransform = gameObject.GetComponent<Transform>();
        childTransform = parentTransform.GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            childTransform.position = new Vector3(childTransform.position.x, childTransform.position.y,- 0.005f);
            Trigger();
        }
        else
        {
            childTransform.position = new Vector3(childTransform.position.x, childTransform.position.y, 0f);
        }
    }

    public void Trigger()
    {
        buttonPressed = true;
    }
}
