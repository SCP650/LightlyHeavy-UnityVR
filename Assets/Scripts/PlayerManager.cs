using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager i;
    public GameObject player;
    public Rigidbody playerRigid;
    public Transform playerHead;
    public int maxHealth = 100;
    public int currHealth;
 

    private void Awake()
    {
        if (i != null && i != this)
        {
            Destroy(this);
        }
        else
        {
            i = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currHealth = maxHealth;
        playerRigid = player.GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        currHealth += damage;
        if(currHealth <=0)
        {
            StartCoroutine(OnDeath());
        }
    }
    private IEnumerator OnDeath()
    {
        yield return null;
    } 

    public void PushPlayer(Vector3 Direction, int force)
    {
        playerRigid.AddForce(Direction * force, ForceMode.Impulse);
    }
}
