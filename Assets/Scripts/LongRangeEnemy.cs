using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class LongRangeEnemy : Agent
{
    public int numBullet = 3;
    public AudioSource source;
    public AudioClip shootSound;
    public AudioClip detectSound;
   

    private int level;
    private int consecuShots;
    private float coolDownTime;
    private Rigidbody rigidbody;

    private void Start()
    {
        level = GameManager.i.currLevel;
        damage = damage - level; //increase damange linearlly 
        consecuShots = level * 2+1;
        coolDownTime = 3 - level * 0.5f;
        GetComponent<Damageable>().onDestroyed.AddListener(StopAllCoroutines);
        rigidbody = GetComponent<Rigidbody>();
        Detected = false;

    }
    public override IEnumerator StartAttack()
    {
    
        while (true)
        {
            for(int i =0; i < consecuShots; i++)
            {
                Attack();
                yield return new WaitForSeconds(0.5f);
            }
            
            yield return new WaitForSeconds(coolDownTime >= 1 ? coolDownTime : 1);
        }
    }
    public override void OnDetectPlayer()
    {
        source.PlayOneShot(detectSound);
        base.OnDetectPlayer();
        
    }


    public override void Attack()
    {
        GameObject shot =  Instantiate(bullet);
        source.PlayOneShot(shootSound);
        shot.transform.position = transform.position + transform.forward;
        EnemyBullet bul = shot.GetComponent<EnemyBullet>();
        bul.damage = damage;
        bul.direction =  PlayerManager.i.playerHead.position - transform.position;
        bul.speed = 1;

    }
    public override IEnumerator CloseIn()
    {
        while (true)
        {
        
            rigidbody.AddForce((PlayerManager.i.playerHead.position - transform.position) * 20, ForceMode.Force);

            yield return new WaitForSeconds(Random.Range(3, 5));
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

    public override void OnDie()
    {
        GetComponent<Damageable>().DestroyThis();
    }
    void OnDrawGizmos()
    {
         
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position,detectRadus);
    }
}
