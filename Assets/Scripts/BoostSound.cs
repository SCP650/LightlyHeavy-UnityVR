using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class BoostSound : MonoBehaviour
{
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance( InputBridge.Instance.LeftThumbstickAxis, Vector2.zero) > 0.1f) //movmeent 
        {
            if (!audioSource.isPlaying)
            {

                audioSource.time = Random.value * audioSource.clip.length;
                audioSource.pitch = Time.timeScale;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
       

    }
}
