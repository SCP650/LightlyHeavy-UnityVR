using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class TogglePropel : MonoBehaviour
{
    public GameObject LeftHandModel;
    public GameObject RightHandModel;
    public GameObject PropellerPrefab_L;
    public GameObject PropellerPrefab_R;

    // Update is called once per frame
    void Update()
    {
        if (InputBridge.Instance.XButton) //left hand
        {
            ToggleActive(LeftHandModel);
            ToggleActive(PropellerPrefab_L);
        }
        else if (InputBridge.Instance.AButton) //right hand
        {
            ToggleActive(RightHandModel);
            ToggleActive(PropellerPrefab_R);
        }
    }
    private void ToggleActive(GameObject thing)
    {
        thing.SetActive(!thing.activeSelf);
    }
     
}
