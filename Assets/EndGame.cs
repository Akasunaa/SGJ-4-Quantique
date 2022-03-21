using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject _card;

    public void PutCard()
    {
        _card.SetActive(true);
    }
}
