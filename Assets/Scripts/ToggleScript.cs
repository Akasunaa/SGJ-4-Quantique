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
            block.disabledColor = new Color(0.4528302f, 0f, 0f);
            block.highlightedColor = new Color(0.4528302f, 0f, 0f);
            block.normalColor = new Color(0.4528302f, 0f, 0f);
            block.pressedColor = new Color(0.4528302f, 0f, 0f);
            block.selectedColor = new Color(0.4528302f, 0f, 0f);
            _toggle.colors = block;
        }
        else
        {
            block.disabledColor = new Color(1f, 0f, 0f);
            block.highlightedColor = new Color(1f, 0f, 0f);
            block.normalColor = new Color(1f, 0f, 0f);
            block.pressedColor = new Color(1f, 0f, 0f);
            block.selectedColor = new Color(1f, 0f, 0f);
            _toggle.colors = block;
        }

    }
}
