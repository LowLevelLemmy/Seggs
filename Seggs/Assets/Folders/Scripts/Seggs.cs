using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Seggs : MonoBehaviour
{
    // Events:
    public UnityEvent SeggsSuccess;
    public UnityEvent SeggsFailure;

    bool seggsDone = false;
    int seggStage = 0;
    public GameObject qtePrefab;
    SpriteUpdater spriteUpdater;


    void OnEnable()
    {
        spriteUpdater = GetComponent<SpriteUpdater>();
        DOVirtual.DelayedCall(2, SpawnQTE);
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
        float randSpawnDelay = Random.Range(0.5f, 1f);
        Invoke("SpawnQTE", randSpawnDelay);
        spriteUpdater.ThrustAnimation();
    }

    void OnQTEFail()
    {
        spriteUpdater.FailAnimation();
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
        spriteUpdater.ThankAnimation();
        seggsDone = true;
        Destroy(gameObject, 1.0f);
        DOVirtual.DelayedCall(1.0f, () => SeggsSuccess?.Invoke());
    }
}
