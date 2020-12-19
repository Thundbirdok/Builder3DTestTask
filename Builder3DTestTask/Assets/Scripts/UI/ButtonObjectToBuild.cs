using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonObjectToBuild : MonoBehaviour
{

    [SerializeField]
    private BuildingWindowController controller;

    [SerializeField]
    private TextMeshProUGUI buttonText;

    private int _index;

    public void SetText(string text)
    {

        buttonText.text = text;

    }

    public void SetIndex(int index)
    {

        _index = index;

    }

    public void OnClick()
    {
        
        controller.ButtonClicked(_index);

    }

}
