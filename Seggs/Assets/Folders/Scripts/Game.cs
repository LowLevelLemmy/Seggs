using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EasyButtons;

// STRUCTURE:
// Game == controlls all the seggs sequences
//      Seggs == controls what you see here:


public class Game : MonoBehaviour
{
    int score;
    int highScore;

    GameObject canvas;
    public GameObject seggsSequence;



    void OnEnable()
    {
        canvas = GameObject.Find("Canvas");
    }

    [Button]
    void SpawnSegg()
    {
        Instantiate(seggsSequence, canvas.transform);
    }
}
