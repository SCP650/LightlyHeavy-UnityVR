using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    
    public GameObject[] stuff;
    public GameObject[] enemy;
    public Vector3 sphereOrig = new Vector3(-7.93f, -0.27f, -62.23f);

    private int numEnemy;
    private void Start()
    {
       
        numEnemy = GameManager.i.currLevel * 5 + 5;
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
            yield return null;
        }
    }
}
