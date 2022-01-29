using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Animator animator;
    public bool isEntry;
    public bool isLocked;
   
  
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.tag == "Player")
        {
            if (isEntry)
            {
                if (GameManager.i.ShouldUnlockNextLevel())
                {
                    animator.SetBool("character_nearby", true);
                }
            }
            else
            {
                animator.SetBool("character_nearby", true);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("character_nearby", false);
        
        }
    }
}
