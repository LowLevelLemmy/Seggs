using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EasyButtons;
using System;

// STRUCTURE:
// Game == controlls all the seggs sequences
//      Seggs == controls what you see here:


public class Game : MonoBehaviour
{
    int score = 0;
    int stage = 1;
    int highScore;

    public GameObject seggsSequence;
    public GameObject phoneSeggs;
    public GameObject dinnerSeggs;

    GameObject canvas;
    ISegg curSeg;

    void OnEnable()
    {
        canvas = GameObject.Find("Canvas");
        SpawnNewStage();
    }

    [Button]
    void SpawnNewStage()    // replace SpawnSegg
    {
        switch (stage)
        {
            case 1:
                SpawnPhoneStage();
                break;
            case 2:
                SpawnDinner();
                break;
            case 3:
                SpawnSegg();
                break;
            default:
                stage = 1;
                SpawnNewStage();
                break;
        }
    }

    private void SpawnDinner()
    {
        curSeg = Instantiate(dinnerSeggs, canvas.transform).GetComponent<Seggs>();
        curSeg.GetSuccessEvent().AddListener(OnSeggsSuccess);
    }

    void SpawnPhoneStage()
    {
        curSeg = Instantiate(phoneSeggs, canvas.transform).GetComponent<ISegg>();
        curSeg.GetSuccessEvent().AddListener(OnSeggsSuccess);
    }

    [Button]
    void SpawnSegg()
    {
        curSeg = Instantiate(seggsSequence, canvas.transform).GetComponent<Seggs>();
        curSeg.GetSuccessEvent().AddListener(OnSeggsSuccess);
    }

    void OnSeggsSuccess()
    {
        ++score;
        ++stage;
        DOVirtual.DelayedCall(curSeg.transitionSpeed * 0.5f, SpawnNewStage);    // TODO: replace with SpawnNewStage()
        print(score);
    }
}
