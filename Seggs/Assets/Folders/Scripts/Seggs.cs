using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Seggs : MonoBehaviour
{
    // Settings:
    public float transitionSpeed = 1.5f;
    public Vector2 spawnDelayMinMax;

    // Events:
    public UnityEvent SeggsSuccess;
    public UnityEvent SeggsFailure;

    bool seggsDone = false;
    int seggStage = 0;
    public GameObject qtePrefab;
    SpriteUpdater spriteUpdater;


    void OnEnable()
    {
        Transitioner.AnimateIn(transform, transitionSpeed);
        spriteUpdater = GetComponent<SpriteUpdater>();
        DOVirtual.DelayedCall(transitionSpeed + 0.15f, SpawnQTE);
    }

    void SpawnQTE()
    {
        float randDur = Random.Range(0.4f, 1f);

        QTE qteScript = Instantiate(qtePrefab, GameObject.Find("Canvas").transform).GetComponent<QTE>();
        qteScript.OnWon.AddListener(OnQTEWon);
        qteScript.OnFailed.AddListener(OnQTEFail);

        qteScript.dur = randDur;
        qteScript.StartQTE();
    }

    void OnQTEWon()
    {
        IncrementSeggStage();

        if (seggsDone) return;
        float randSpawnDelay = Random.Range(spawnDelayMinMax.x, spawnDelayMinMax.y);
        Invoke("SpawnQTE", randSpawnDelay);
        ThrustAnimation();
    }

    void OnQTEFail()
    {
        SeggsFailed();
    }

    void SeggsFailed()
    {
        spriteUpdater.ChangeSeggSprite(2);
        SeggsFailure?.Invoke();
    }

    void IncrementSeggStage()
    {
        ++seggStage;
        switch (seggStage)
        {
            case 1:
                print("BAM");
                break;

            case 2:
                print("BAM");
                break;

            case 3:
                ThankYou();
                break;
        }
    }

    void ThankYou()
    {
        print("Thank You Ma'am");
        ThankAnimation();
        seggsDone = true;
        SeggsSuccess?.Invoke();
        DOVirtual.DelayedCall(0.5f, () => Transitioner.AnimateOut(transform, transitionSpeed));
    }

    void ThrustAnimation()
    {
        spriteUpdater.ChangeSeggSprite(1);
        DOVirtual.DelayedCall(0.15f, () => spriteUpdater.ChangeSeggSprite(0));
    }
    void FailAnimation()
    {
        spriteUpdater.ChangeSeggSprite(2);
    }

    void ThankAnimation()
    {
        spriteUpdater.ChangeSeggSprite(3);
    }
}
