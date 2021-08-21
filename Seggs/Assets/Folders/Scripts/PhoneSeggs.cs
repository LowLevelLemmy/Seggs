using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PhoneSeggs : MonoBehaviour, ISegg
{
    // Settings:
    public float transitionSpeed { get; set; }
    public float spawnDelay { get; set; }
    public float qteDur { get; set; }


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
        Invoke("SpawnQTE", spawnDelay);
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
        if (done)
            return;
        print("PHONE FAILED");
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
