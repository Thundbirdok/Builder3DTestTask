using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField]    
    private Builder builder;

    [SerializeField]
    private BuildingWindowController buildingWindowController = null;

    [SerializeField]
    private UpgradeWindowController upgradeWindowContrtoller = null;

    private bool isRaycastBlock = false;

    private enum OpenedWindow
    {

        BuildingWindow,
        UpgradeWindow,
        None

    }

    private OpenedWindow state = OpenedWindow.None;

    public void OpenBuildingWindow(GameObject tile)
    {

        if (isRaycastBlock)
        {

            return;

        }

        if (state == OpenedWindow.UpgradeWindow)
        {

            upgradeWindowContrtoller.Close();

        } else if (state == OpenedWindow.BuildingWindow)
        {

            buildingWindowController.Close();

        }

        buildingWindowController.Open(tile);

        state = OpenedWindow.BuildingWindow;

    }

    public void OpenUpgradeWindow(GameObject building)
    {

        if (isRaycastBlock)
        {

            return;

        }

        if (state == OpenedWindow.UpgradeWindow)
        {

            upgradeWindowContrtoller.Close();

        }
        else if (state == OpenedWindow.BuildingWindow)
        {

            buildingWindowController.Close();

        }

        upgradeWindowContrtoller.Open(building);

        state = OpenedWindow.UpgradeWindow;

    }

    public void CloseWindow()
    {

        state = OpenedWindow.None;

    }

    public void BlockRaycast()
    {

        isRaycastBlock = true;

    }

    public void UnblockRaycast()
    {

        isRaycastBlock = false;

    }

}
