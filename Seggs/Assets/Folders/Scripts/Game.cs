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

    Seggs curSeg;

    void OnEnable()
    {
        canvas = GameObject.Find("Canvas");
    }

    [Button]
    void SpawnSegg()
    {
        curSeg = Instantiate(seggsSequence, canvas.transform).GetComponent<Seggs>();
        curSeg.SeggsSuccess.AddListener(OnSeggsSuccess);
    }

    void OnSeggsSuccess()
    {
        DOVirtual.DelayedCall(curSeg.transitionSpeed * 0.5f, SpawnSegg);
    }
}
