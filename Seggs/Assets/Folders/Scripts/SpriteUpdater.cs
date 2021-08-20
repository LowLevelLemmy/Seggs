using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] Sprite seg0;
    [SerializeField] Sprite seg1;
    [SerializeField] Sprite seg2;

    SpriteRenderer sr;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Thrust()
    {
        ChangeSeggSprite(1);
        DOVirtual.DelayedCall(0.2f, () => ChangeSeggSprite(0));
    }

    void ChangeSeggSprite(int i)
    {
        switch (i)
        {
            case 0:
                sr.sprite = seg0;
                break;
            case 1:
                sr.sprite = seg1;
                break;
            case 2:
                sr.sprite = seg2;
                break;
        }
    }
}
