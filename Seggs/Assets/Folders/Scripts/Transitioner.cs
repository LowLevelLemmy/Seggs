using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Transitioner : MonoBehaviour
{
    static public void AnimateIn(Transform tran, float transitionSpeed)
    {
        tran.localPosition = new Vector3(1920, 0, 0);
        tran.DOLocalMoveX(0, transitionSpeed);
    }

    static public void AnimateOut(Transform tran, float transitionSpeed)
    {
        tran.DOLocalMoveX(-1920, transitionSpeed).OnComplete(() => Destroy(tran.gameObject));
    }
}
