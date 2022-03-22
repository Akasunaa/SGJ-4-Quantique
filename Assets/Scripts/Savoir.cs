using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Savoir : MonoBehaviour
{
    private TMP_Text[] _texts;
    private Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();
        _texts = GetComponentsInChildren<TMP_Text>();
        _buttons[0].onClick.AddListener(FirstButton);
        _buttons[1].onClick.AddListener(SecondButton);
    }

    public void SecondButton()
    {
        _texts[0].gameObject.SetActive(false);
        _texts[1].gameObject.SetActive(true);
    }

    public void FirstButton()
    {
        _texts[0].gameObject.SetActive(true);
        _texts[1].gameObject.SetActive(false);
    }
}
