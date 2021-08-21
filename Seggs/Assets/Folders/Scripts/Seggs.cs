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
        AnimateIn();
        spriteUpdater = GetComponent<SpriteUpdater>();
        DOVirtual.DelayedCall(transitionSpeed + 0.3f, SpawnQTE);
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
        spriteUpdater.ThrustAnimation();
    }

    void OnQTEFail()
    {
        SeggsFailed();
    }

    void SeggsFailed()
    {
        spriteUpdater.FailAnimation();
        SeggsFailure?.Invoke();
        Destroy(gameObject, 1.0f);
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
        spriteUpdater.ThankAnimation();
        seggsDone = true;
        SeggsSuccess?.Invoke();
        DOVirtual.DelayedCall(0.5f, AnimateOut);
    }

    void AnimateIn()
    {
        transform.localPosition = new Vector3(1920, 0, 0);
        transform.DOLocalMoveX(0, transitionSpeed);
    }

    void AnimateOut()
    {
        transform.DOLocalMoveX(-1920, transitionSpeed).OnComplete(() => Destroy(gameObject));
    }
}
