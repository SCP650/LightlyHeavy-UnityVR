using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnter : MonoBehaviour
{
    private bool hasEntered = false;
   
     
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !hasEntered)
        {
            GameManager.i.LoadNextBattle();
            hasEntered = true;
        }
    }
}
