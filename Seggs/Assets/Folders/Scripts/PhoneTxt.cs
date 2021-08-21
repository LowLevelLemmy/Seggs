using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneTxt : MonoBehaviour
{
    public List<TextsSO> txts;
    void OnEnable()
    {
        SetTxts();
    }

    void SetTxts()
    {
        foreach (Transform child in transform)
        {
            for (int i = 0; i < child.childCount; ++i)
            {
                switch (i)
                {
                    case 0:
                        if (child.name != "FAIL6")
                            child.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = txts[0].contactName;
                        break;
                    case 1:
                        child.GetChild(i).GetComponent<TextMeshProUGUI>().text = txts[0].txts[i - 1];
                        break;
                    case 2:
                        child.GetChild(i).GetComponent<TextMeshProUGUI>().text = txts[0].txts[i - 1];
                        break;
                    case 3:
                        child.GetChild(i).GetComponent<TextMeshProUGUI>().text = txts[0].txts[i - 1];
                        break;
                    case 4:
                        child.GetChild(i).GetComponent<Image>().sprite = txts[0].lastImg;
                        break;
                }
            }
        }
    }
}
