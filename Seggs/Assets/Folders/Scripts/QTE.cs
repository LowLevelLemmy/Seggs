using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using EasyButtons;

public class QTE : MonoBehaviour
{
    [Header("Settings: ")]
    public float dur = 4;
    public Direction correctDir;

    [Header("Events")]
    public UnityEvent OnWon;
    public UnityEvent OnFailed;


    InputManager inputManager;
    GameObject arrow;
    bool activated = false;

    void OnEnable()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        arrow = GameObject.Find("Arrow");
        correctDir = GetRandDir();
    }

    Direction GetRandDir()
    {
        return (Direction)Random.Range(1, 4);
    }

    [Button]
    public void StartQTE()
    {
        activated = true;
        arrow.transform.localScale = Vector3.one;
        PointArrow();
    }

    void Update()
    {
        if (!activated) return;

        dur -= Time.deltaTime;

        if (inputManager.curDirection == correctDir)
        {
            Win();
        }
        else if (inputManager.curDirection != Direction.NONE)   // hit a key that wasn't the correct one
        {
            Fail();
        }

        if (dur <= 0)
        {
            Fail();
        }
    }

    void PointArrow()
    {
        float zRot = 0;
        switch (correctDir)
        {
            case (Direction.UP):
                zRot = 0;
                break;
            case (Direction.DOWN):
                zRot = 180;
                break;
            case (Direction.LEFT):
                zRot = 90;
                break;

            case (Direction.RIGHT):
                zRot = -90;
                break;
        }

        Vector3 rot = arrow.transform.localEulerAngles;
        rot.z = zRot;
        arrow.transform.localEulerAngles = rot;
    }

    void Fail()
    {
        print("LOST QTE");
        OnFailed?.Invoke();
        arrow.transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }

    void Win()
    {
        print("WON QTE");
        OnWon?.Invoke();
        arrow.transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }
}
