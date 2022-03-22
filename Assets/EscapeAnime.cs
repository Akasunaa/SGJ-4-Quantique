using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscapeAnime : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private void Awake()
    {
        
        Zone.CardGainEnergie += EventZone;
        Zone.CardWin += EventZone;
        Zone.CardWin += EventZone;
    }

    private void OnDestroy()
    {
        Zone.CardGainEnergie -= EventZone;
        Zone.CardWin -= EventZone;
        Zone.CardWin -= EventZone;
    }

    public void EventZone()
    {
        StartCoroutine(FadeOut());

    }

    private IEnumerator FadeOut()
    {
        _text.gameObject.SetActive(true);
        while (_text.color.a > 0)
        {
            
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a - Time.unscaledDeltaTime / 4f);
            yield return null;
        }
        _text.gameObject.SetActive(false);
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1f);
    }

}
