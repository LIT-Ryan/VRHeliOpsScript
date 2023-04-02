using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class IpadButton : MonoBehaviour , IPointerClickHandler
{


    [Header("On when button Pressed")]
    public List<GameObject> onList_;
    [Header("Off when button Pressed")]
    public List<GameObject> offList_;

    // Start is called before the first frame update
    public GameObject cube; // Drag your 3D object with the collider attached to this field in the Inspector

    public void OnPointerClick(PointerEventData eventData)
    {
        // Simulate a mouse click on the 3D object with the collider
        ExecuteEvents.Execute(cube, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
    }
    // Update is called once per frame


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finger"))
        {
            Debug.Log("hand touch");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            Debug.Log("test3");
        }
    }



}
