using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public int damage = -5;
    public GameObject bullet; //for enemy 
    public Transform target; //for enemy
    public int detectRadus = 5;

    private bool detected = false;

    private void Start()
    {
       
            
    }

    private void Update()
    {
        if( !detected && Vector3.Distance( PlayerManager.i.playerHead.position, transform.position) < detectRadus)
        {
            Debug.Log("detected");
            detected = true;
            OnDetectPlayer();
        }else if (detected)
        {
            transform.LookAt(PlayerManager.i.playerHead);
        }
        
    }

    public virtual void OnDetectPlayer()
    {
        StartCoroutine(StartAttack());
      

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
