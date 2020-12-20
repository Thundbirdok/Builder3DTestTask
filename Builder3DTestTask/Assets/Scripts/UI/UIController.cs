using System;
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

    [SerializeField]
    private NoteWindowController noteWindowContrtoller = null;

    private bool isRaycastBlock = false;

    private enum OpenedWindow
    {

        BuildingWindow,
        UpgradeWindow,
        NoteWindow,
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

        CloseWindow();

        upgradeWindowContrtoller.Open(building);

        state = OpenedWindow.UpgradeWindow;

    }

    internal void OpenNoteWindow(GameObject note)
    {

        if (isRaycastBlock)
        {

            return;

        }

        CloseWindow();

        noteWindowContrtoller.Open(note);

        state = OpenedWindow.NoteWindow;

    }

    public void CloseWindow()
    {

        switch (state)
        {

            case OpenedWindow.UpgradeWindow:

                upgradeWindowContrtoller.Close();

                break;

            case OpenedWindow.BuildingWindow:

                buildingWindowController.Close();

                break;

            case OpenedWindow.NoteWindow:



                break;

        }

    }

    public void SetWindowClosed()
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
