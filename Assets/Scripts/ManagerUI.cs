using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] GameObject[] cartes;
    [SerializeField] GameObject[] _miniCartes;
    [SerializeField] GameObject[] _miniCartesButton;
    [SerializeField] GameObject _backButton;
    [SerializeField] GameObject _nerdButton;
    [SerializeField] GameObject _happyButton;
    [SerializeField] AudioSource audio;


    private GameObject _currentGameplay;
    private GameObject _currentSavoir;
    private bool _bigCardOpen = false;



    public bool BigCardOpen { get {  return (_bigCardOpen); } set { Debug.Log("Jechange vers " + value); _bigCardOpen = value; } }

    private void Awake()
    {
        //Zone.NewZone += NewZoneEvent;
        Zone.CardGainEnergie += GainEnergie;
        Zone.CardWin += Win;
        Zone.CardWin += Mesure;
    }

    private void OnDestroy()
    {
        Zone.CardGainEnergie -= GainEnergie;
        Zone.CardWin -= Win;
        Zone.CardWin -= Mesure;
    }

    private void Mesure()
    {
        _miniCartes[2].SetActive(true);//base de mesure
        _miniCartesButton[2].GetComponent<Button>().interactable = true;
    }
    private void Win()
    {
        _miniCartes[3].SetActive(true); //la meca quantique
        _miniCartesButton[3].GetComponent<Button>().interactable = true;
    }

    private void GainEnergie()
    {
        audio.Play();
        _miniCartes[0].SetActive(true); //gain denergie
        _miniCartes[1].SetActive(true); //mesure
        _miniCartesButton[0].GetComponent<Button>().interactable = true;
        _miniCartesButton[1].GetComponent<Button>().interactable = true;
    }

    private void OnEnable()
    {
        _backButton.SetActive(false);
        foreach (GameObject carte in cartes)
        {
            carte.SetActive(false);
        }
    }
    /*
    public void NewZoneEvent(int nbZone)
    {
        //audio.Play();
        print("a");
        if (nbZone == 2)
        {
            _miniCartes[0].SetActive(true);
            _miniCartes[1].SetActive(true);
            _miniCartesButton[0].GetComponent<Button>().interactable = true;
            _miniCartesButton[1].GetComponent<Button>().interactable = true;
        }
        else if (nbZone == 3)
        {
            _miniCartes[2].SetActive(true);
            _miniCartesButton[2].GetComponent<Button>().interactable = true;
        }
        else if (nbZone == 4)
        {
            _miniCartes[3].SetActive(true);
            _miniCartesButton[3].GetComponent<Button>().interactable = true;
        }

    }
    */

    public void CloseAll()
    {
        BigCardOpen = false;
        _backButton.SetActive(false);
        _nerdButton.SetActive(false);
        _happyButton.SetActive(false);
        foreach (GameObject carte in cartes)
        {
            carte.SetActive(false);
        }
    }

    public void GameplayButton(bool active)
    {
        ColorBlock block = ColorBlock.defaultColorBlock;

        if (_currentGameplay != null)
            _currentGameplay.SetActive(active);
        if (active)
        {
            block.disabledColor = new Color(0.7f, 0.7f, 0.7f);
            block.highlightedColor = new Color(0.7f, 0.7f, 0.7f);
            block.normalColor = new Color(0.7f, 0.7f, 0.7f);
            block.pressedColor = new Color(0.7f, 0.7f, 0.7f);
            block.selectedColor = new Color(0.7f, 0.7f, 0.7f);
            _happyButton.GetComponent<Toggle>().colors = block;
        }
        else
        {
            block.disabledColor = new Color(1f, 1f, 1f);
            block.highlightedColor = new Color(1f, 1f, 1f);
            block.normalColor = new Color(1f, 1f, 1f);
            block.pressedColor = new Color(1f, 1f, 1f);
            block.selectedColor = new Color(1f, 1f, 1f);
            _happyButton.GetComponent<Toggle>().colors = block;
        }
    }

    public void SavoirButton(bool active)
    {
        ColorBlock block = ColorBlock.defaultColorBlock;

        if (_currentSavoir != null)
           _currentSavoir.SetActive(active);
        if (active)
        {
            block.disabledColor = new Color(0.7f, 0.7f, 0.7f);
            block.highlightedColor = new Color(0.7f, 0.7f, 0.7f);
            block.normalColor = new Color(0.7f, 0.7f, 0.7f);
            block.pressedColor = new Color(0.7f, 0.7f, 0.7f);
            block.selectedColor = new Color(0.7f, 0.7f, 0.7f);
            _nerdButton.GetComponent<Toggle>().colors = block;
        }
        else
        {
            block.disabledColor = new Color(1f, 1f, 1f);
            block.highlightedColor = new Color(1f, 1f, 1f);
            block.normalColor = new Color(1f, 1f, 1f);
            block.pressedColor = new Color(1f, 1f, 1f);
            block.selectedColor = new Color(1f, 1f, 1f);
            _nerdButton.GetComponent<Toggle>().colors = block;
        }
    }

    public void OpenCard(int i)
    {
        BigCardOpen = true;
        _happyButton.GetComponent<Toggle>().isOn = true;
        _nerdButton.GetComponent<Toggle>().isOn = false;
        _nerdButton.SetActive(true);
        _happyButton.SetActive(true);

        cartes[i].SetActive(true);
        LargeCard card = cartes[i].GetComponent<LargeCard>();
        _currentGameplay = card.Gameplay;
        _currentSavoir = card.Savoir;
        _backButton.SetActive(true);
    }
}
