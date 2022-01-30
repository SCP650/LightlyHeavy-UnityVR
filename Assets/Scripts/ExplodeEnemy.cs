using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ExplodeEnemy : Agent
{
 
    public AudioSource source;
    public AudioClip explodeSound;
    public AudioClip detectSound;
   

    private int level;
    private int force;
    private Rigidbody rigidbody;
    private int explodeRadius;

    private void Start()
    {
        level = GameManager.i.currLevel;
        damage = damage - level; //increase damange linearlly 
        force = level * 5 +25; 
        GetComponent<Damageable>().onDestroyed.AddListener(StopAllCoroutines);
        rigidbody = GetComponent<Rigidbody>();
        Detected = false;
        explodeRadius = level * 2 + 3;
        detectRadus = detectRadus + level * 3;
    }
    public override IEnumerator StartAttack()
    {
    
        while (true)
        {
            if (Vector3.Distance(PlayerManager.i.playerHead.position, transform.position) < explodeRadius)
            {
                source.PlayOneShot(explodeSound);
                PlayerManager.i.TakeDamage(damage);
                GetComponent<Damageable>().DestroyThis();
            }
            yield return null;
        }
    }
    public override void OnDetectPlayer()
    {
        source.PlayOneShot(detectSound);
        base.OnDetectPlayer();
        
    }


    public override IEnumerator CloseIn()
    {
        while (true)
        {
             
            rigidbody.AddRelativeForce(Vector3.forward * force, ForceMode.Force);
            yield return null;
        }
    }

    public override IEnumerator Patrol()
    {
        while (true)
        {
       
            rigidbody.AddForce(new Vector3(Random.value * 100 -50, Random.value * 100 -50, Random.value * 100 - 50), ForceMode.Force);

            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }


    void OnDrawGizmos()
    {
         
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position,detectRadus);
    }
}
