using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    public Vector3 direction;
    public float speed;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = speed * direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            PlayerManager.i.TakeDamage(damage);
            PlayerManager.i.PushPlayer(-direction, damage);
        }
    }

}
