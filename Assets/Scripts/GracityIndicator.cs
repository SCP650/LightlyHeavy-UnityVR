using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GracityIndicator : MonoBehaviour
{
    public Vector3 gravityDirection;

    private bool hasGravity;
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
        hasGravity = GameManager.i.hasGravity;
        if (!hasGravity)
        {
        
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

        if (hasGravity)
        {
            var rotation = Quaternion.LookRotation(gravityDirection);
            rotation *= _facing;
            transform.rotation = rotation;
        }
       

    }
}
