using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EasyButtons;
using TMPro;

public class IphoneClock : MonoBehaviour
{
    TextMeshProUGUI txt;
    void OnEnable()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = GetTimeStr();
    }

    [Button]
    string GetTimeStr()
    {
        DateTime now = DateTime.Now;
        string time = String.Format("{0:h:mm}", now);
        return time;
    }
}
