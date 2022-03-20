using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompagnonManager : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();


    }

    private void OnEnable()
    {
        _animator.SetFloat("Blend", 1);
    }
}
