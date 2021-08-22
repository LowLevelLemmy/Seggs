using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneTxt : MonoBehaviour
{
    public List<TextsSO> txts;
    int score;
    void OnEnable()
    {
        score = GameObject.FindObjectOfType<Game>().score;
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
                            child.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = txts[score].contactName;
                        break;
                    case 1:
                        child.GetChild(i).GetComponent<TextMeshProUGUI>().text = txts[score].txts[i - 1];
                        break;
                    case 2:
                        child.GetChild(i).GetComponent<TextMeshProUGUI>().text = txts[score].txts[i - 1];
                        break;
                    case 3:
                        child.GetChild(i).GetComponent<TextMeshProUGUI>().text = txts[score].txts[i - 1];
                        break;
                    case 4:
                        child.GetChild(i).GetComponent<Image>().sprite = txts[score].lastImg;
                        break;
                }
            }
        }
    }
}
