using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using EasyButtons;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] GameObject preThrust;
    [SerializeField] GameObject thrust;
    [SerializeField] GameObject fail;
    [SerializeField] GameObject thankYou;

    [SerializeField] SeggFacesSO seggFaces;

    Image img;

    private void OnEnable()
    {
        preThrust = transform.GetChild(0).gameObject;
        thrust= transform.GetChild(1).gameObject;
        fail = transform.GetChild(2).gameObject;
        thankYou= transform.GetChild(3).gameObject;

        SetAllFaces();
        ChangeSeggSprite(0);
    }

    void SetActiveAllChildren(Transform transform, bool value)  // MAKE INTO UTIL FUNCTION LATER!
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(value);
    }

    [Button]
    void SetAllFaces()  // MAKE INTO UTIL FUNCTION LATER!
    {
        foreach (Transform seggAction in transform)
        {
            Transform mask = seggAction.GetChild(0);
            Image femaleImg = mask.GetChild(0).GetComponent<Image>();
            Image maleImg = mask.GetChild(1).GetComponent<Image>();

            femaleImg.sprite = seggFaces.femaleImg;
            maleImg.sprite = seggFaces.maleImg;
        }
    }


    void ChangeSeggSprite(int i)
    {
        SetActiveAllChildren(transform, false);
        switch (i)
        {
            case 0:
                preThrust.SetActive(true);
                break;
            case 1:
                thrust.SetActive(true);
                break;
            case 2:
                fail.SetActive(true);
                break;
            case 3:
                thankYou.SetActive(true);
                break;
        }
    }

    public void ThrustAnimation()
    {
        ChangeSeggSprite(1);
        DOVirtual.DelayedCall(0.15f, () => ChangeSeggSprite(0));
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
