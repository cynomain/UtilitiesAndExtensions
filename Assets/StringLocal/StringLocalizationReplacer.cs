using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StringLocalizationReplacer : MonoBehaviour
{
    public string translatedTextPrefix = "$";
    public bool DestroyAfter = true;
    public bool ReFindTexts = false;
    TMP_Text[] tmptexts;
    Text[] texts;

    private void Awake()
    {
        if (!ReFindTexts)
        {
            tmptexts = FindObjectsOfType<TMP_Text>();
            texts = FindObjectsOfType<Text>();
        }

        UpdateTexts();

        if (DestroyAfter) Destroy(this);
    }

    public void UpdateTexts()
    {
        if (ReFindTexts)
        {
            tmptexts = FindObjectsOfType<TMP_Text>();
            texts = FindObjectsOfType<Text>();
        }

        if (tmptexts != null && tmptexts.Length > 0)
        {
            for (int i = 0; i < tmptexts.Length; i++)
            {
                if (tmptexts[i].text.StartsWith(translatedTextPrefix))
                {
                    tmptexts[i].SetText(removeFirst(tmptexts[i].text));
                }
            }
        }

        if (texts != null && texts.Length > 0)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].text.StartsWith(translatedTextPrefix))
                {
                    texts[i].text = removeFirst(texts[i].text);
                }
            }
        }
    }

    string removeFirst(string str)
    {
        return str.Substring(1);
    }
}
