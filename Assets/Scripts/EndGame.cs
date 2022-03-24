using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject _card;
    [SerializeField] ManagerUI _myUIManager;
    private bool _isCard = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            if (_isCard && _myUIManager.BigCardOpen)
            {
                _myUIManager.CloseAll();
            }
            else if (_isCard)
            {
                CloseCard();
            }
        }
    }

    public void CloseCard()
    {
        _isCard = false;
        _card.SetActive(false);
    }

    public void PutCard()
    {
        _isCard = true;
        _card.SetActive(true);
    }
}
