using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GracityIndicator : MonoBehaviour
{
    public Vector3 gravityDirection;


    private Quaternion _facing;
    private void Start()
    {
        GameManager.i.onChangeGravity.AddListener(OnGravityUpdate);
        gravityDirection = Physics.gravity.normalized;

        _facing = transform.rotation;
        OnGravityUpdate();
    }

    private void OnGravityUpdate()
    {
        if(!GameManager.i.hasGravity)
        {
            Debug.Log("no gravity");
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            gravityDirection = Physics.gravity.normalized;
        }
        
    }

    private void Update()
    {

       
        var rotation = Quaternion.LookRotation(gravityDirection);
        rotation *= _facing;
        transform.rotation = rotation;

    }
}
