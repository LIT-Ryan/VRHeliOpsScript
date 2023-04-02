using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{

    public List<GameObject> WayPointList = new List<GameObject>();

    public bool autoSelect = false;
    public int maxObject = 0;
    public string objectName;

    private int currentListObj = 0;

    public static WaypointManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (autoSelect)
        {
            for ( int x = 0; x < maxObject; x++)
            {
                string objectFullName = objectName + " (" + x.ToString() + ")";
                GameObject obj = GameObject.Find(objectFullName);
                if (obj != null)
                {
                    obj.AddComponent<WayPoint>();
                    Rigidbody rb = obj.AddComponent<Rigidbody>();
                    rb.useGravity = false;
                    WayPointList.Add(obj);
                    if ( x == 0 )
                    {
                        obj.SetActive(true);
                    }
                    else
                    {
                        obj.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("GameObject not found with name: " + objectFullName);
                }
            }
        }

    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        WayPointList[0].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWayPoint()
    {     
        if (currentListObj + 1 < WayPointList.Count)
        {
            Debug.Log(WayPointList);
            WayPointList[currentListObj].SetActive(false);
            WayPointList[currentListObj + 1].SetActive(true);
            currentListObj++;
        }
        /*else if (currentListObj + 1 == WayPointList.Count)
        {
            WayPointList[0].SetActive(true);
            WayPointList[WayPointList.Count-1].SetActive(false);
            currentListObj = 0;
        }*/
        /*else
        {
            WayPointList[currentListObj].SetActive(false);
            currentListObj = 0;
            WayPointList[currentListObj].SetActive(true);
        }
        */
        Debug.Log(currentListObj);


        /*
        for (int currentListObj = 0; currentListObj < WayPointList.Count; currentListObj++)
        {
            if (currentListObj + 1 < WayPointList.Count)
            {
                Debug.Log(WayPointList);
                WayPointList[currentListObj].SetActive(false);
                WayPointList[currentListObj + 1].SetActive(true);
            }
            else
            {
                WayPointList[currentListObj].SetActive(false);
            }
        }
        */


    }

    
}
