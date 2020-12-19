using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWindowController : MonoBehaviour
{

    [SerializeField]
    private GameObject buttonTemplate = null;

    [SerializeField]
    private Builder builder = null;    
    
    private GameObject _target;

    private int selectedObjectToBuild;

    [SerializeField]
    private UIController uiController;

    [SerializeField]
    private GameObject buttonBuild = null;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < builder.ObjectsToBuild.Length; ++i)
        {

            GameObject button = Instantiate(buttonTemplate);                       

            button.transform.SetParent(buttonTemplate.transform.parent, false);

            var script = button.GetComponent<ButtonObjectToBuild>();
            script.SetText(builder.ObjectsToBuild[i].name);
            script.SetIndex(i);

            button.SetActive(true);

        }

    }

    public void ButtonClicked(int index)
    {

        uiController.BlockRaycast();
        selectedObjectToBuild = index;
        buttonBuild.SetActive(true);

    }

    public void Open(GameObject target)
    {

        _target = target;
        gameObject.SetActive(true);
        uiController.UnblockRaycast();
        buttonBuild.SetActive(false);

    }

    public void Close()
    {

        uiController.UnblockRaycast();
        gameObject.SetActive(false);
        uiController.CloseWindow();

    }

    public void Build()
    {
        
        builder.Build(_target, selectedObjectToBuild);
        Close();

    }

}