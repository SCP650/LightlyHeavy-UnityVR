using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy : Agent
{
    public int numBullet = 3;
   

    
    public override IEnumerator StartAttack()
    {
    
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
    }
    

    public override void Attack()
    {
        GameObject shot =  Instantiate(bullet);
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
