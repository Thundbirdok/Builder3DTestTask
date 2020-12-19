using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsListController : MonoBehaviour
{

    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private Builder builder;
    [SerializeField]
    private UIController uiController;

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

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked(int index)
    {
        
        uiController.SelectObjectToBuild(index);

    }

}
