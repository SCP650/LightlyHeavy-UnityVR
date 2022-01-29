using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tutorialLevel;
    public GameObject currTransition;
    public GameObject battleGroundPrefab;    //
    public GameObject transitionPrefab; //
    public static GameManager i;

    public int currLevel = 0;
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
            TutorialSetActive(false);
        }
        
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

        currTransition = nextTransition;
        preTransition = currTransition;


    }

    public void TutorialSetActive(bool beActive)
    {
        tutorialLevel.SetActive(beActive);
    }

}
