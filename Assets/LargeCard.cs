using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCard : MonoBehaviour
{
    [SerializeField] GameObject _gamePlay;
    [SerializeField] GameObject _savoir;

    public GameObject Gameplay { get { return (_gamePlay); } }
    public GameObject Savoir { get { return (_savoir); } }
}
