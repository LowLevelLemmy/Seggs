using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// STRUCTURE:
// Game == controlls all the seggs sequences
//      Seggs == controls what you see here:


public class Game : MonoBehaviour
{
    public GameObject qtePrefab;

    SpriteUpdater spriteUpdater;
    void OnEnable()
    {
        spriteUpdater = GetComponent<SpriteUpdater>();
        SpawnQTE();
    }

    void SpawnQTE()
    {
        float randDur = Random.Range(0.7f, 2.5f);

        QTE qteScript = Instantiate(qtePrefab).GetComponent<QTE>();
        qteScript.OnWon.AddListener(OnQTEWon);
        qteScript.dur = randDur;
        qteScript.StartQTE();
    }

    void OnQTEWon()
    {
        float randSpawnDelay = Random.Range(0.7f, 2.5f);
        Invoke("SpawnQTE", randSpawnDelay);
        spriteUpdater.Thrust();
    }
}
