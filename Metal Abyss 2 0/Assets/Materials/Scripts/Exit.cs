using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject DoorU;
    public GameObject DoorD;
    public GameObject DoorL;
    public GameObject DoorR;
    public void DoorOpen()
    {
        DoorU.SetActive(false); 
        DoorD.SetActive(false);
        DoorL.SetActive(false);
        DoorR.SetActive(false);

    }
}
