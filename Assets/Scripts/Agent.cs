using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public int damage = -5;
    public GameObject bullet; //for enemy 
    public int detectRadus = 20;

    private Coroutine attack;
    private Coroutine patrol;
    private Coroutine closein;

    private bool detected;

    public bool Detected { get { return detected; }
        set
        {
            detected = value;
            if (detected)
            {
                OnDetectPlayer();
            }
            else
            {
                OnLosePlayer();
            }
        }

    }
    

    private void Update()
    {
        if( Vector3.Distance( PlayerManager.i.playerHead.position, transform.position) < detectRadus)
        {
            if (Detected)
            {
                transform.LookAt(PlayerManager.i.playerHead);
            }else
            {
                Detected = true;
            }
         
           
        }
        else
        {
            if (Detected)
            {
                Detected = false;
            }
            
            
        }
        
       
        
    }

    public virtual void OnLosePlayer()
    {
        patrol =  StartCoroutine(Patrol());
        if(attack!=null) StopCoroutine(attack);
        if (closein != null) StopCoroutine(closein);
        
    }

    public virtual void OnDetectPlayer()
    {
        attack = StartCoroutine(StartAttack());
        StopCoroutine(patrol);
        closein = StartCoroutine(CloseIn());

    }
    public virtual IEnumerator CloseIn()
    {
        yield return null;
    }

   public virtual IEnumerator Patrol()
    {
        yield return null;
    }


    public virtual IEnumerator StartAttack()
    {
   
        yield return null;
    }


    public virtual void Attack() //for enemy
    {
        Instantiate(bullet, gameObject.transform);
    }


}
