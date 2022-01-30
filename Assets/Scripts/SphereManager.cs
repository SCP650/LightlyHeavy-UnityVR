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
        StartCoroutine(ChangeGravity());
    }
    private IEnumerator Spawn()
    {
        for(int i = 0; i < numEnemy; i++)
        {
            GameObject e = Instantiate(enemy[0]);
            e.transform.position = Random.insideUnitSphere * 35 + sphereOrig;
            e.transform.parent = transform;
            e.GetComponent<Damageable>().onDestroyed.AddListener(DecreaseCount);

            SpawnObject();
            SpawnObject();

            yield return null;
        }


        text.text = $"{numAlive} Enemies Left";
    }

    private void SpawnObject()
    {
        GameObject s = Instantiate(stuff[Random.Range(0, stuff.Length)]);
        s.transform.position = Random.insideUnitSphere * 35 + sphereOrig;
        s.transform.parent = transform;
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

    private IEnumerator ChangeGravity()
    {
        int freq = 10;
        int dura = 10;
       
        

        while (true)
        {
            if (!GameManager.i.isTesting)
            {
                freq = Random.Range(5, 50 - 2* GameManager.i.currLevel);
                freq = Random.Range(15, 100 - 2 * GameManager.i.currLevel);
            }
            yield return new WaitForSeconds(freq);
            GameManager.i.ChangeGravity();
            yield return new WaitForSeconds(dura);
            GameManager.i.ResetGravity();
        }
    }
}
