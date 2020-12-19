using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{

    [SerializeField]
    private GameObject _UIController = null;
    private UIController _uiController;

    // Start is called before the first frame update
    void Start()
    {

        _uiController = _UIController.GetComponent<UIController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {                

                if (hit.transform.gameObject.tag == "Tile")
                {

                    Debug.Log("Tile");

                    _uiController.OpenBuildingWindow(hit.transform.gameObject);

                }

                if (hit.transform.gameObject.tag == "Building")
                {

                    _uiController.OpenUpgradeWindow(hit.transform.gameObject);

                }

            }

        }

    }

}
