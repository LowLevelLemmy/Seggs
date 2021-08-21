using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Seggs : MonoBehaviour, ISegg
{
    // Settings:
    public float transitionSpeed { get; set; }
    public float spawnDelay { get; set; }
    public float qteDur { get; set; }

    public Vector3 qteSpawnLoc;

    // Events:
    public UnityEvent SeggsSuccess;
    public UnityEvent SeggsFailure;

    bool seggsDone = false;
    int seggStage = 0;
    public GameObject qtePrefab;
    SpriteUpdater spriteUpdater;


    void Start()
    {
        Transitioner.AnimateIn(transform, transitionSpeed);
        spriteUpdater = GetComponent<SpriteUpdater>();
        DOVirtual.DelayedCall(transitionSpeed + 0.15f, SpawnQTE);
    }

    void SpawnQTE()
    {
        QTE qteScript = Instantiate(qtePrefab, GameObject.Find("Canvas").transform).GetComponent<QTE>();
        qteScript.OnWon.AddListener(OnQTEWon);
        qteScript.OnFailed.AddListener(OnQTEFail);

        qteScript.dur = qteDur;
        qteScript.StartQTE();

        if (qteSpawnLoc != Vector3.zero)
            qteScript.transform.localPosition = qteSpawnLoc;
    }

    void OnQTEWon()
    {
        IncrementSeggStage();

        if (seggsDone) return;
        Invoke("SpawnQTE", spawnDelay);
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
                break;

            case 2:
                break;

            case 3:
                ThankYou();
                break;
        }
    }

    void ThankYou()
    {
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

    public UnityEvent GetSuccessEvent()
    {
        return SeggsSuccess;
    }

    public UnityEvent GetFailureEvent()
    {
        return SeggsFailure;
    }
}
