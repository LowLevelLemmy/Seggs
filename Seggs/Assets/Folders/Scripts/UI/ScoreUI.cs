using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI txt;

    void OnEnable()
    {
        txt = GetComponent<TextMeshProUGUI>();
        int score = GameObject.FindObjectOfType<Game>().score;
        UpdateScore(score);
    }

    public void UpdateScore(int i)
    {
        txt.text = i.ToString();
    }
}
