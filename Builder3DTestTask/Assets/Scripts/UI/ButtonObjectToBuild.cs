using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonObjectToBuild : MonoBehaviour
{

    [SerializeField]
    private ObjectsListController controller;

    [SerializeField]
    private TextMeshProUGUI buttonText;

    private int _index;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
