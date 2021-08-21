using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using EasyButtons;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI txt;

    void OnEnable()
    {
        txt = GetComponent<TextMeshProUGUI>();
        int score = GameObject.FindObjectOfType<Game>().score;
        UpdateScore(score);
    }

    [Button]
    public void UpdateScore(int i)
    {
        txt.text = i.ToString();
        transform.DOPunchScale(Vector3.one * .15f, 0.3f);
    }
}
