using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back: MonoBehaviour
{
    public GameObject panelDial;
    public GameObject DialButton;
    public void Button()
    {
        DialButton.SetActive(true);

    }
    public void CloseDial()
    {
        panelDial.SetActive(false);
        Time.timeScale = 1;

    }
}
