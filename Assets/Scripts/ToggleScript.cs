using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        ChangeState(_toggle.isOn);
    }

    public void ChangeState(bool isOn)
    {
        ColorBlock block = ColorBlock.defaultColorBlock;

        if (isOn)
        {
            block.disabledColor = new Color(0f, 0.9215686f, 1f);
            block.highlightedColor = new Color(0f, 0.9215686f, 1f);
            block.normalColor = new Color(0f, 0.9215686f, 1f);
            block.pressedColor = new Color(0f, 0.9215686f, 1f);
            block.selectedColor = new Color(0f, 0.9215686f, 1f);
            _toggle.colors = block;
        }
        else
        {
            block.disabledColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
            block.highlightedColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
            block.normalColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
            block.pressedColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
            block.selectedColor = new Color(0.1658063f, 0.4055467f, 0.509434f);
            _toggle.colors = block;

        }

    }
}
