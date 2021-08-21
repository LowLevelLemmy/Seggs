using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using EasyButtons;


public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] List<SeggFacesSO> seggFaces;
    List<GameObject> children;
    int score;

    void Awake()
    {
        children = new List<GameObject>();
        foreach (Transform child in transform)  // get all children
            children.Add(child.gameObject);
    }

    void OnEnable()
    {
        score = GameObject.FindObjectOfType<Game>().score;
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


            print("BOUTA SET FACES... SCORE: " + score);
            femaleImg.sprite = seggFaces[score].femaleImg;
            maleImg.sprite = seggFaces[score].maleImg;
        }
    }


    public void ChangeSeggSprite(int i)
    {
        SetActiveAllChildren(transform, false);
        children[i].SetActive(true);
    }
}
