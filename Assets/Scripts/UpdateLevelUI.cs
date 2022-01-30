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
       
        GameManager.i.onResetGame.AddListener(updateText);
        updateText();
    }
    private void OnDestroy()
    {
        GameManager.i.onResetGame.RemoveListener(updateText);
    }

    private void updateText()
    {
        text.text = $"Level: {GameManager.i.currLevel}";
    }
}
