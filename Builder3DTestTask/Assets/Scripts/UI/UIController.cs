using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField]    
    private Builder builder;

    [SerializeField]
    private GameObject BuildingWindow = null;

    [SerializeField]
    private GameObject UpgradeWindow = null;

    private GameObject target;
    private int selectedObjectToBuild;

    public void SelectObjectToBuild(int value)
    {

        selectedObjectToBuild = value;        

    }

    public void OpenBuildingWindow(GameObject tile)
    {

        target = tile;
        selectedObjectToBuild = 0;

        BuildingWindow.SetActive(true);

    }

    public void Build()
    {
        
        builder.Build(target, selectedObjectToBuild);

        CloseBuildingWindow();

    }

    public void CloseBuildingWindow()
    {

        BuildingWindow.SetActive(false);

    }

    public void OpenUpgradeWindow(GameObject building)
    {

        target = building;

        UpgradeWindow.SetActive(true);

    }

    public void Upgrade()
    {

        builder.Upgrade(target);

    }

    public void CloseUpgradeWindow()
    {

        UpgradeWindow.SetActive(false);

    }

}
