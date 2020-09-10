using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore") + "";

    }
}
