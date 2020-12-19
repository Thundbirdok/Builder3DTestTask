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

    private UpgradeWindowController upgradeWindowContrtoller = null;

    private GameObject target;
    private int selectedObjectToBuild;

    void Start()
    {

        upgradeWindowContrtoller = UpgradeWindow.GetComponent<UpgradeWindowController>();

    }

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

        int rate = target.GetComponent<Upgradable>().Rate;

        UpgradeWindow.SetActive(true);

        upgradeWindowContrtoller.SetRate(rate);        

    }

    public void Upgrade()
    {

        builder.Upgrade(target);

        int rate = target.GetComponent<Upgradable>().Rate;
        upgradeWindowContrtoller.SetRate(rate);

    }

    public void CloseUpgradeWindow()
    {

        UpgradeWindow.SetActive(false);

    }

}
