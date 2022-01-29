using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.UI;
public class SphereManager : MonoBehaviour
{
    
    public GameObject[] stuff;
    public GameObject[] enemy;
    public Vector3 sphereOrig = new Vector3(-7.93f, -0.27f, -62.23f);
    public Text text;

    private int numEnemy;
    private int numAlive;
    private void Start()
    {
       
        numEnemy = GameManager.i.currLevel * 2 + 5;
        numAlive = numEnemy;
        StartCoroutine(Spawn());

    }
    private IEnumerator Spawn()
    {
        for(int i = 0; i < numEnemy; i++)
        {
            GameObject e = Instantiate(enemy[0]);
            GameObject s = Instantiate(stuff[Random.Range(0,stuff.Length)]);

            e.transform.position = Random.insideUnitSphere * 35 + sphereOrig;
            s.transform.position = Random.insideUnitSphere * 35 + sphereOrig;

            e.transform.parent = transform;
            s.transform.parent = transform;

            e.GetComponent<Damageable>().onDestroyed.AddListener(DecreaseCount);

            yield return null;
        }
        text.text = $"{numAlive} Enemies Left";
    }

    private void DecreaseCount()
    {
        numAlive--;
        if(numAlive == 0)
        {
            text.text = "Next Level Unlocked, I Expect You to Die.";
        }
        else
        {
            text.text = $"{numAlive} Enemies Left";
        }
        
    }
    public bool ShouldUnlockDoor()
    { 
        return numAlive == 0;
    }
}
