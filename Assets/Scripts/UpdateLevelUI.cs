using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevelUI : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = $"Level: {GameManager.i.currLevel}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
