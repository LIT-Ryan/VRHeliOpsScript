using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPadManager : MonoBehaviour
{
    public static IPadManager instance;
    public Page currentPage;
    [Header("UI Obj")]
    public GameObject mainMenu;
    public GameObject FlightTraning1;
    public GameObject FlightTraning2;
    public GameObject FlightTraning3;
    public GameObject FlightTraning4;
    public GameObject homeScreen;
    public GameObject contractHomePage;
    public GameObject contract;
    public GameObject map;
    public GameObject finance;
    public GameObject marketPlace;
    public GameObject contractComplete;
    public GameObject contractFailed;

    [Space]
    [Header("TriggerCollider")]
    public GameObject mainMenuCol;
    public GameObject FlightTraning1Col;
    public GameObject FlightTraning2Col;
    public GameObject FlightTraning3Col;
    public GameObject FlightTraning4Col;
    public GameObject homeScreenCol;
    public GameObject contractHomePageCol;
    public GameObject contractCol;
    public GameObject mapCol;
    public GameObject financeCol;
    public GameObject marketPlaceCol;
    public GameObject contractCompleteCol;
    public GameObject contractFailedCol;

    public List<GameObject> objectList;
    public List<GameObject> colliderList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public enum Page
    {
        MainMenu,
        FlightTraningPage1,
        FlightTraningPage2,
        FlightTraningPage3,
        FlightTraningPage4,
        HomeScreen,
        ContractHomePage,
        Contract,
        Finance,
        Map,
        MarketPlace,
        ContractComplete,
        ContractFailed,


    }

    public void Start()
    {
        objectList.Add(mainMenu);               //1
        objectList.Add(FlightTraning1);         //2
        objectList.Add(FlightTraning2);         //4                      
        objectList.Add(FlightTraning3);         //3
        objectList.Add(FlightTraning4);         //5
        objectList.Add(homeScreen);             //6
        objectList.Add(contractHomePage);       //7
        objectList.Add(contract);               //8
        objectList.Add(map);                    //9
        objectList.Add(finance);                //10
        objectList.Add(marketPlace);            //11
        objectList.Add(contractComplete);       //12
        objectList.Add(contractFailed);         //13

        colliderList.Add(mainMenuCol);
        colliderList.Add(FlightTraning1Col);
        colliderList.Add(FlightTraning2Col);
        colliderList.Add(FlightTraning3Col);
        colliderList.Add(FlightTraning4Col);
        colliderList.Add(homeScreenCol);
        colliderList.Add(contractHomePageCol);
        colliderList.Add(contractCol);
        colliderList.Add(mapCol);
        colliderList.Add(financeCol);
        colliderList.Add(marketPlaceCol);
        colliderList.Add(contractCompleteCol);
        colliderList.Add(contractFailedCol);
        
    }


    public void FixedUpdate()
    {
        ChangePage();
    }
    public void ChangePage()
    {
        switch (currentPage)
        {
            case Page.MainMenu:
                ActivateObject(1);
                ActivateCollider(1);
                break;
            case Page.FlightTraningPage1:
                ActivateObject(2);
                ActivateCollider(2);
                break;
            case Page.FlightTraningPage2 :
                ActivateObject(3);
                ActivateCollider(3);
                break;
            case Page.FlightTraningPage3 : 
                ActivateObject(4);
                ActivateCollider(4);
                break;
            case Page.FlightTraningPage4 :
                ActivateObject(5);
                ActivateCollider(5);
                break;
            case Page.HomeScreen :
                ActivateObject(6);
                ActivateCollider(6);
                break;
            case Page.ContractHomePage :
                ActivateObject(7);
                ActivateCollider(7);
                break;
            case Page.Contract : 
                ActivateObject(8);
                ActivateCollider(8);
                break;
            case Page.Map :
                ActivateObject(9);
                ActivateCollider(9);
                break;
            case Page.Finance :
                ActivateObject(10);
                ActivateCollider(10);
                break;
            case Page.MarketPlace :
                ActivateObject(11);
                ActivateCollider(11);
                break;
            case Page.ContractComplete :
                ActivateObject(12);
                ActivateCollider(12);
                break;
            case Page.ContractFailed : 
                ActivateObject(13);
                ActivateCollider(13);
                break;
        }
    }
    public void ActivateObject(int index)
    {
        index-=1;
        Debug.Log("Index" + index);
        for (int i = 0; i < objectList.Count; i++)
        {
            if (i != index)
            {
                objectList[i].SetActive(false); // disable all other objects
            }
            else
            {
                objectList[i].SetActive(true); // activate the specified object             
            }
        }
        
    }

    public void ActivateCollider(int index)
    {
        index -= 1;
        Debug.Log("colliderIndex" + index);
        for (int i = 0; i < colliderList.Count; i++)
        {
            if (i == index)
            {
                colliderList[i].SetActive(true); // activate the specified object
            }
            else
            {
                colliderList[i].SetActive(false); // disable all other objects
            }
        }
    }
}
