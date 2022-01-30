using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager i;
    public GameObject player;
    public Rigidbody playerRigid;
    public Transform playerHead;
    public int maxHealth = 100;
    public int currHealth;
    public Text text;
    public AudioSource audio;
    public AudioSource bgmAudio;
    public AudioClip hurtSound;

    public float VibrateFrequency = 0.3f;
    public float VibrateAmplitude = 1f;
    public float VibrateDuration = 0.2f;

    private Vector3 _initialPosition;
    private AudioClip bgm;

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
        bgm = Resources.Load("Space_Jam") as AudioClip;
    }

    public void TakeDamage(int damage)
    {
        currHealth += damage;
        audio.PlayOneShot(hurtSound);
        InputBridge.Instance.VibrateController(VibrateFrequency, VibrateAmplitude, VibrateDuration,0);
        InputBridge.Instance.VibrateController(VibrateFrequency, VibrateAmplitude, VibrateDuration, ControllerHand.Right);
        if (currHealth <=0)
        {
            StartCoroutine(OnDeath());
        }
    }
    private IEnumerator OnDeath()
    {
        GameManager.i.ResetGame();
        yield return null;
        text.text = "Another Try?";
        playerRigid.transform.position = _initialPosition;
        playerRigid.velocity = Vector3.zero;
        currHealth = maxHealth;

    } 

    public void PushPlayer(Vector3 Direction, int force)
    {
        playerRigid.AddForce(Direction * force, ForceMode.Impulse);
    }
    public void PlayMusic() {
        bgmAudio.clip = bgm;
        bgmAudio.Play();
    }
    public void StopMusic()
    {
        bgmAudio.Stop();
    }

}
