using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscapeAnime : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _text2;

    private void Awake()
    {
        Zone.NewZone += EventZone;
    }

    public void EventZone(int nbZone)
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

    private IEnumerator FadeOut2()
    {
        _text2.gameObject.SetActive(true);
        while (_text2.color.a > 0)
        {

            _text2.color = new Color(_text2.color.r, _text2.color.g, _text2.color.b, _text2.color.a - Time.unscaledDeltaTime / 4f);
            yield return null;
        }
        _text2.gameObject.SetActive(false);
        _text2.color = new Color(_text2.color.r, _text2.color.g, _text2.color.b, 1f);
    }
}
