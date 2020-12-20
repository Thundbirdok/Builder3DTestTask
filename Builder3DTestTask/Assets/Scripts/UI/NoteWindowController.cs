using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteWindowController : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private UIController uiController;

    private GameObject _target;    

    public void Open(GameObject note)
    {

        _target = note;        
        text.text = _target.GetComponent<Note>().NoteString;

        gameObject.SetActive(true);

    }

    public void Close()
    {

        gameObject.SetActive(false);
        uiController.SetWindowClosed();

    }

}
