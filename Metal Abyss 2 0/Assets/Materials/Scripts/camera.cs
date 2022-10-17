using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
  
    [SerializeField] private AudioSource LVL1MUSIC;






    void Start()
    {
        LVL1MUSIC.PlayDelayed(2);
        LVL1MUSIC.PlayDelayed(1);
    }

    void Update()
    {
        

    }
}
