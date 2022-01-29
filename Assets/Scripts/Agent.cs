using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public int damage = -5;
    public GameObject bullet; //for enemy 
    public Transform target; //for enemy


    private void Start()
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
