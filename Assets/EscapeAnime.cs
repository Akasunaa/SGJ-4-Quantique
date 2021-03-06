using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscapeAnime : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _text2;

    bool _alreadyPrinted = false;

    private void Awake()
    {
        
        Zone.CardGainEnergie += EventZone;
        Zone.CardWin += EventZone;
        Zone.CardBase += EventZone;
    }

    private void OnDestroy()
    {
        Zone.CardGainEnergie -= EventZone;
        Zone.CardWin -= EventZone;
        Zone.CardBase -= EventZone;
    }

    public void EventZone()
    {
        StartCoroutine(FadeOut(_text, 4f));
    }



    private IEnumerator FadeOut(TMP_Text text, float time)
    {
        text.gameObject.SetActive(true);
        while (text.color.a > 0)
        {
            
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.unscaledDeltaTime / time);
            yield return null;
        }
        text.gameObject.SetActive(false);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
    }

}
