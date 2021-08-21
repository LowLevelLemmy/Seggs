using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using EasyButtons;


public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] SeggFacesSO seggFaces;
    List<GameObject> children;

    Image img;

    void Awake()
    {
        children = new List<GameObject>();
        foreach (Transform child in transform)  // get all children
            children.Add(child.gameObject);
    }

    void OnEnable()
    {
        SetAllFaces();
        ChangeSeggSprite(0);
    }

    void SetActiveAllChildren(Transform transform, bool value)  // TODO: MAKE INTO UTIL FUNCTION LATER!
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
        children[i].SetActive(true);
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
