using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] Sprite preThrust;
    [SerializeField] Sprite thrust;
    [SerializeField] Sprite thankYou;
    [SerializeField] Sprite fail;

    SpriteRenderer sr;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        ChangeSeggSprite(0);
    }

    public void ThrustAnimation()
    {
        ChangeSeggSprite(1);
        DOVirtual.DelayedCall(0.15f, () => ChangeSeggSprite(0));
    }

    void ChangeSeggSprite(int i)
    {
        switch (i)
        {
            case 0:
                sr.sprite = preThrust;
                break;
            case 1:
                sr.sprite = thrust;
                break;
            case 2:
                sr.sprite = fail;
                break;
            case 3:
                sr.sprite = thankYou;
                break;
        }
    }

    public void FailAnimation()
    {
        ChangeSeggSprite(2);
    }
}
