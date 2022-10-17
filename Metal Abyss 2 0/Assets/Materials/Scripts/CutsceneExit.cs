using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneExit : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CutEx());
    }
    IEnumerator CutEx()
    {
        yield return new WaitForSeconds(28.5f);
        SceneManager.LoadScene(6);

    }
}
