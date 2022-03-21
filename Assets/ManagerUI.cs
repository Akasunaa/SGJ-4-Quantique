using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] GameObject[] cartes;
    [SerializeField] GameObject _backButton;
    [SerializeField] GameObject _nerdButton;
    [SerializeField] GameObject _happyButton;

    private GameObject _currentGameplay;
    private GameObject _currentSavoir;

    private void OnEnable()
    {
        _backButton.SetActive(false);
        foreach (GameObject carte in cartes)
        {
            carte.SetActive(false);
        }
    }

    public void CloseAll()
    {
        _backButton.SetActive(false);
        _nerdButton.SetActive(false);
        _happyButton.SetActive(false);
        foreach (GameObject carte in cartes)
        {
            carte.SetActive(false);
        }
    }

    public void GameplayButton()
    {
        _currentSavoir.SetActive(false);
        _currentGameplay.SetActive(true);
    }

    public void SavoirButton()
    {
        _currentSavoir.SetActive(true);
        _currentGameplay.SetActive(false);
    }

    public void OpenCard(int i)
    {
        _nerdButton.SetActive(true);
        _happyButton.SetActive(true);
        cartes[i].SetActive(true);
        LargeCard card = cartes[i].GetComponent<LargeCard>();
        _currentGameplay = card.Gameplay;
        _currentSavoir = card.Savoir;
        _backButton.SetActive(true);
    }
}
