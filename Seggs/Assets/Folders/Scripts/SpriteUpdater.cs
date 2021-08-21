using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] SeggGraphicSO seggGraphic;

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
                img.sprite = seggGraphic.preThrust;
                break;
            case 1:
                img.sprite = seggGraphic.thrust;
                break;
            case 2:
                img.sprite = seggGraphic.fail;
                break;
            case 3:
                img.sprite = seggGraphic.thankYou;
                break;
        }
    }

    public void FailAnimation()
    {
        ChangeSeggSprite(2);
    }

    public void ThankAnimation()
    {
        ChangeSeggSprite(3);
    }
}
