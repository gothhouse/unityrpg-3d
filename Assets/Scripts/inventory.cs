using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    //Variables
    bool inventoryEnabled;

    public GameObject Inventory;
    public GameObject playerCamera;

    //Functions
    void Start()
    {
        
    }

    void Update()
    {
        //Enabling the Inventory
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;

        }

        if (inventoryEnabled)
        {
            Inventory.SetActive(true);
            playerCamera.GetComponent<Camera>().orthographic = true;

        } else {
            Inventory.SetActive(false);
            playerCamera.GetComponent<Camera>().orthographic = false;
        }


    }
}
