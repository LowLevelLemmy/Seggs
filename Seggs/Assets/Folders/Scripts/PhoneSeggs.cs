using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PhoneSeggs : MonoBehaviour, ISegg
{
    // Settings:
    public float transitionSpeed { get; set; }
    public Vector2 spawnDelayMinMax;
    public GameObject qtePrefab;
    public Vector3 qtePos;

    // Events:
    public UnityEvent Failure;
    public UnityEvent Success;

    bool done = false;
    int phoneStage = 0;
    SpriteUpdater spriteUpdater;
    int curSprite = 0;

    bool qteFlipper;

    void OnEnable()
    {
        transitionSpeed = 1.5f;
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

        if (qteFlipper)
        {
            Vector3 qteFlippedPos = qtePos;
            qteFlippedPos.x = -qtePos.x;
            qteScript.transform.localPosition = qteFlippedPos;
        }
        else
            qteScript.transform.localPosition = qtePos;
        qteFlipper = !qteFlipper;
    }

    void OnQTEWon()
    {
        IncrementSprite();
        IncrementPhoneStage();

        if (done) return;
        float randSpawnDelay = Random.Range(spawnDelayMinMax.x, spawnDelayMinMax.y);
        Invoke("SpawnQTE", randSpawnDelay);
    }

    void IncrementSprite()
    {
        ++curSprite;
        spriteUpdater.ChangeSeggSprite(curSprite);
    }

    void IncrementPhoneStage()
    {
        ++phoneStage;
        if (phoneStage >= 4)
            PhoneEnd();
    }

    void PhoneEnd()
    {
        done = true;
        Success?.Invoke();
        DOVirtual.DelayedCall(0.5f, () => Transitioner.AnimateOut(transform, transitionSpeed));
    }

    void OnQTEFail()
    {
        SeggsFailed();
    }

    void SeggsFailed()
    {
        print("FAILED");
        spriteUpdater.ChangeSeggSprite(6);
        Failure?.Invoke();
    }

    public UnityEvent GetSuccessEvent()
    {
        return Success;
    }

    public UnityEvent GetFailureEvent()
    {
        return Failure;
    }
}
