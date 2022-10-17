using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
   public void menuback()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
