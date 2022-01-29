using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy : Agent
{
    public int numBullet = 3;
    public AudioSource source;
    public AudioClip shootSound;
    public AudioClip detectSound;

    
    public override IEnumerator StartAttack()
    {
    
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(3);
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


    void OnDrawGizmos()
    {
         
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position,detectRadus);
    }
}
