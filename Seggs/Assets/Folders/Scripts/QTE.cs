using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    float curDur;
    InputManager inputManager;
    Slider slider;
    GameObject arrow;
    bool activated = false;

    void OnEnable()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        arrow = GameObject.Find("Arrow");
        slider = GetComponentInChildren<Slider>();
        correctDir = GetRandDir();

        // make arrow a child of the slider bc we need to rotate the arrow differently from slider
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
        curDur = dur;
    }

    void Update()
    {
        if (!activated) return;

        curDur -= Time.deltaTime;

        if (inputManager.curDirection == correctDir)
        {
            Win();
        }
        else if (inputManager.curDirection != Direction.NONE)   // hit a key that wasn't the correct one
        {
            Fail();
        }

        if (curDur <= 0)
        {
            Fail();
        }

        UpdateSlider();
    }

    void UpdateSlider()
    {
        float factor = 1 - (curDur / dur);
        factor = Mathf.Clamp01(factor);

        slider.value = (factor);
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
        //print("LOST QTE");
        OnFailed?.Invoke();
        arrow.transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }

    void Win()
    {
        //print("WON QTE");
        OnWon?.Invoke();
        arrow.transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }
}
