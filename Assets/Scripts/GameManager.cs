using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject tutorialLevel;
    public GameObject currTransition;
    public GameObject battleGroundPrefab;    //
    public GameObject transitionPrefab; //
    public static GameManager i;
    public UnityEvent onChangeGravity;
    public bool hasGravity = false;

    public int currLevel = 0;
    public bool isTesting = false;
    private GameObject currBattleGround;
    private Vector3 battleOffset = new Vector3(-7.93f, -0.27f, -62.23f);
    private Vector3 transitOffset = new Vector3(-4.13f, -0.11f, -102.52f);
    private GameObject preTransition;
    private Vector3 origPosition;
    private GameObject nextTransition;

    private void Awake()
    {
        if(i != null && i != this)
        {
            Debug.LogError("More Game Mamager!!");
            Destroy(this);
        }
        else
        {
            i = this;
        }
    }
    private void Start()
    {
        origPosition = currTransition.transform.position;
    }

    public void LoadNextBattle()
    {
        if(currLevel == 0)
        {
            tutorialLevel.SetActive(false);
        }
        currLevel += 1;
        
        if (currBattleGround != null)
        {
            Destroy(currBattleGround);
        }
        if(preTransition != null)
        {
            Destroy(preTransition);
        }

        PlayerManager.i.player.transform.parent = currTransition.transform;
        currTransition.transform.position = origPosition;
        PlayerManager.i.player.transform.parent = null;

        currBattleGround = Instantiate(battleGroundPrefab);
        currBattleGround.transform.position =  battleOffset;
    

        nextTransition = Instantiate(transitionPrefab);
        nextTransition.transform.position = transitOffset;

        preTransition = currTransition; 
        currTransition = nextTransition;
        

        


    }
     

    public void ResetGame()
    {
        Destroy(nextTransition);
        Destroy(currBattleGround);
        tutorialLevel.SetActive(true);
        currLevel = 0;
    }

    public bool ShouldUnlockNextLevel()
    {
        if (isTesting)
        {
            return true;
        }
        return currBattleGround.GetComponent<SphereManager>().ShouldUnlockDoor();
    }

    public void ChangeGravity()
    {
        hasGravity = true;
        Physics.gravity = new Vector3(Random.value, Random.value, Random.value )* 10 - new Vector3(5,5,5);
    
        onChangeGravity.Invoke();
    }

    public void ResetGravity()
    {
        hasGravity = false;
        Physics.gravity = Vector3.zero;
        onChangeGravity.Invoke();
    }
}
