using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YouFailPopUp : MonoBehaviour
{
    CanvasGroup cg;
    private void OnEnable()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
        cg.DOFade(.7f, 1f);
    }
}
