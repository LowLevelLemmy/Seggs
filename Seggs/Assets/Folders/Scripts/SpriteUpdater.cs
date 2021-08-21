using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] Sprite preThrust;
    [SerializeField] Sprite thrust;
    [SerializeField] Sprite thankYou;
    [SerializeField] Sprite fail;

    Image img;

    private void OnEnable()
    {
        img = GetComponent<Image>();
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
                img.sprite = preThrust;
                break;
            case 1:
                img.sprite = thrust;
                break;
            case 2:
                img.sprite = fail;
                break;
            case 3:
                img.sprite = thankYou;
                break;
        }
    }

    public void FailAnimation()
    {
        ChangeSeggSprite(2);
    }
}
