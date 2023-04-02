using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpadContract : MonoBehaviour
{
    private IPadButton ipadbutton;
    public Contract contract;
    public Place place;

    public enum Place
    {
        place1,
        place2,
        place3,
    }

    public enum Contract
    {
        contarct1,
        contarct2,
        contarct3,
    }
    // Start is called before the first frame update
    void Start()
    {
        ipadbutton = this.gameObject.GetComponent<IPadButton>();
        switch (place)
        {
            case Place.place1:
                break;
            case Place.place2:
                break;
            case Place.place3:
                break;
        }
        switch (contract)
        {
            case Contract.contarct1:
                break;
            case Contract.contarct2:
                break;
            case Contract.contarct3:
                break;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ipadbutton.chooseContract_)
        {
            SelectContract();
        }
    }

    void SelectContract()
    {
        IPadManager.instance.currentPage = IPadManager.Page.Contract;
    }

    void AutoGenerateQuest()
    {

    }
}
