using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager i;
    public GameObject player;
    public Rigidbody playerRigid;
    public Transform playerHead;
    public int maxHealth = 100;
    public int currHealth;
    public Text text;

    private Vector3 _initialPosition;

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
        _initialPosition = playerRigid.transform.position;
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
        text.text = "Another Try?";
        playerRigid.transform.position = _initialPosition;
        playerRigid.velocity = Vector3.zero;
    } 

    public void PushPlayer(Vector3 Direction, int force)
    {
        playerRigid.AddForce(Direction * force, ForceMode.Impulse);
    }
}
