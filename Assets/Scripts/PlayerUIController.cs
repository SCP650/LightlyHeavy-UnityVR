using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    private Rigidbody PlayerRigid;
    private void Start()
    {
        PlayerRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       speedText.text = $"{System.Math.Round(PlayerRigid.velocity.magnitude,2)} m/s";
       healthText.text = $"Health: {PlayerManager.i.currHealth}/{PlayerManager.i.maxHealth}";
    }

}
