using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ApparitionProgressive : MonoBehaviour
{
    private GameObject solMur;
    private GameObject plusMoins;
    private Toggle _plusMoinsButton;
    private bool flash = false;

    private void Awake()
    {
        solMur = transform.Find("Sol_Mur").gameObject;
        plusMoins = transform.Find("Plus_Moins").gameObject;

        _plusMoinsButton = plusMoins.GetComponent<Toggle>();
        solMur.SetActive(false);
        plusMoins.SetActive(false);
        Zone.NewZone += ZoneChange;
    }
     
    public void ZoneChange(int value)
    {
        if (value == 2)
            solMur.SetActive(true);
        if (value == 3)
        {
            plusMoins.SetActive(true);
            StartCoroutine(Flashes());
        }
            

    }


    public IEnumerator Flashes()
    {
        float timeElapsed = 0f;
        float tempo = 1f / 3f;

        while (true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= tempo)
            {
                timeElapsed -= tempo; 
                ColorBlock block = ColorBlock.defaultColorBlock;
                if (flash)
                {
                    block.disabledColor = new Color(0f, 0.9215686f, 1f);
                    block.highlightedColor = new Color(0f, 1f, 1f);
                    block.normalColor = new Color(0f, 0.9215686f, 1f);
                    block.pressedColor = new Color(0f, 0.9215686f, 1f);
                    block.selectedColor = new Color(0f, 0.9215686f, 1f);
                    flash = false;
                }
                else
                {
                    block.disabledColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
                    block.highlightedColor = new Color(0f, 1f, 1f);
                    block.normalColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
                    block.pressedColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
                    block.selectedColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
                    flash = true;
                }
                _plusMoinsButton.colors = block;
            }
            yield return null;  
        }
    }
}
