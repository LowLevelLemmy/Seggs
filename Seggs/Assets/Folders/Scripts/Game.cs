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
    public int score = 0;
    public int stage = 1;
    int highScore;

    public GameObject seggsSequence;
    public GameObject phoneSeggs;
    public GameObject dinnerSeggs;

    // UI
    public GameObject failUIPrefab;
    ScoreUI scoreUI;


    GameObject canvas;
    ISegg curSeg;

    public float startingTransitionSpeed;
    public Vector2 startingSpawnDelayMinMax;
    public Vector2 startingQteDurMinMax;
    [SerializeField] float hardnessFactor = 1.0f;
    [SerializeField] float minHardness = 0.6f;

    void OnEnable()
    {
        canvas = GameObject.Find("Canvas");
        scoreUI = GameObject.Find("Score").GetComponent<ScoreUI>();
        SpawnNewStage();
    }

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
                ++score;
                scoreUI.UpdateScore(score);
                SpawnNewStage();
                break;
        }
    }

    private void SpawnDinner()
    {
        curSeg = Instantiate(dinnerSeggs, canvas.transform).GetComponent<Seggs>();
        curSeg.GetSuccessEvent().AddListener(OnSeggsSuccess);
        curSeg.GetFailureEvent().AddListener(OnSeggsFailure);

        // Settings:
        curSeg.transitionSpeed = startingTransitionSpeed * hardnessFactor;
        curSeg.spawnDelay = UnityEngine.Random.Range(startingSpawnDelayMinMax.x, startingSpawnDelayMinMax.y) * hardnessFactor;
        curSeg.qteDur = UnityEngine.Random.Range(startingQteDurMinMax.x, startingQteDurMinMax.y) * hardnessFactor;
    }

    void SpawnPhoneStage()  // I can refactor these 3 functions so cleanly by passing an INT and using an array But it works so carry on
    {
        curSeg = Instantiate(phoneSeggs, canvas.transform).GetComponent<ISegg>();
        curSeg.GetSuccessEvent().AddListener(OnSeggsSuccess);
        curSeg.GetFailureEvent().AddListener(OnSeggsFailure);

        // Settings:
        curSeg.transitionSpeed = startingTransitionSpeed * hardnessFactor;
        curSeg.spawnDelay = UnityEngine.Random.Range(startingSpawnDelayMinMax.x, startingSpawnDelayMinMax.y) * hardnessFactor;
        curSeg.qteDur = UnityEngine.Random.Range(startingQteDurMinMax.x, startingQteDurMinMax.y) * hardnessFactor;
    }

    [Button]
    void SpawnSegg()
    {
        curSeg = Instantiate(seggsSequence, canvas.transform).GetComponent<Seggs>();
        curSeg.GetSuccessEvent().AddListener(OnSeggsSuccess);
        curSeg.GetFailureEvent().AddListener(OnSeggsFailure);

        // Settings:
        curSeg.transitionSpeed = startingTransitionSpeed * hardnessFactor;
        curSeg.spawnDelay = UnityEngine.Random.Range(startingSpawnDelayMinMax.x, startingSpawnDelayMinMax.y) * hardnessFactor;
        curSeg.qteDur = UnityEngine.Random.Range(startingQteDurMinMax.x, startingQteDurMinMax.y) * hardnessFactor;
    }

    void OnSeggsSuccess()
    {
        if (stage == 3)
            AudioMan.instance.PlaySound(3, .8f);
        ++stage;
        DOVirtual.DelayedCall(curSeg.transitionSpeed * 0.5f, SpawnNewStage);    // TODO: replace with SpawnNewStage()
        UpdateHardness();
    }

    void OnSeggsFailure()
    {
        DOVirtual.DelayedCall(.5f, () => Instantiate(failUIPrefab, canvas.transform));
    }

    int hardnessIterations = 0;
    [Button]
    void UpdateHardness()
    {
        if (score == 10 && stage == 2)  // Dining with Charli
        {
            hardnessFactor = .1f;
            return;
        }
        ++hardnessIterations;
        hardnessFactor = Mathf.Clamp(hardnessFactor * .98f, minHardness, 1);
        print(hardnessIterations + " HARDNESS: " + hardnessFactor);
    }
}
