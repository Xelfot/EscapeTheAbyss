using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialButtonAnim : MonoBehaviour
{
    public GameObject panelDial;
    public GameObject DialButton;
   
    public void CloseButton()
    {
        DialButton.SetActive(false);

    }
    public void StartDial()
    {
        panelDial.SetActive(true);
        Time.timeScale = 0;

    }
    public Animator startAnim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            startAnim.SetBool("ButtonOpen", true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
            startAnim.SetBool("ButtonOpen", false);
    }
   





}
