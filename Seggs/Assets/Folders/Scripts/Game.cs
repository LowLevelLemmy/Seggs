using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// STRUCTURE:
// Game == controlls all the seggs sequences
//      Seggs == controls what you see here:


public class Game : MonoBehaviour
{
    int seggStage = 0;
    public GameObject qtePrefab;
    SpriteUpdater spriteUpdater;

    void OnEnable()
    {
        spriteUpdater = GetComponent<SpriteUpdater>();
        SpawnQTE();
    }

    void SpawnQTE()
    {
        float randDur = Random.Range(0.4f, 2.5f);

        QTE qteScript = Instantiate(qtePrefab).GetComponent<QTE>();
        qteScript.OnWon.AddListener(OnQTEWon);
        qteScript.OnFailed.AddListener(OnQTEFail);

        qteScript.dur = randDur;
        qteScript.StartQTE();
    }

    void OnQTEWon()
    {
        float randSpawnDelay = Random.Range(0.5f, 1f);
        Invoke("SpawnQTE", randSpawnDelay);
        spriteUpdater.ThrustAnimation();

        IncrementSeggStage();
    }

    void OnQTEFail()
    {
        spriteUpdater.FailAnimation();
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
                print("Thank You Ma'am");
                break;
        }
    }
}
