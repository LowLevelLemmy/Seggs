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
    int score = 0;
    int stage = 1;
    int highScore;

    public GameObject seggsSequence;

    GameObject canvas;
    Seggs curSeg;

    void OnEnable()
    {
        canvas = GameObject.Find("Canvas");
    }

    void SpawnNewStage()    // replace SpawnSegg
    {
        switch (stage)
        {
            case 1:
                // SpawnPhoneStage();
                break;
            case 2:
                SpawnSegg();
                break;
            default:
                stage = 1;
                SpawnNewStage();
                break;
        }
    }

    [Button]
    void SpawnSegg()
    {
        curSeg = Instantiate(seggsSequence, canvas.transform).GetComponent<Seggs>();
        curSeg.SeggsSuccess.AddListener(OnSeggsSuccess);
    }

    void OnSeggsSuccess()
    {
        ++score;
        ++stage;
        DOVirtual.DelayedCall(curSeg.transitionSpeed * 0.5f, SpawnSegg);    // TODO: replace with SpawnNewStage()
        print(score);
    }
}
