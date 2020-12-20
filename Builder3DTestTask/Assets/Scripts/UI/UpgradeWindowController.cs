using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWindowController : MonoBehaviour
{

    [SerializeField]
    private GameObject Rate;

    [SerializeField]
    private GameObject StarTemplate;

    [SerializeField]
    private Builder builder;

    [SerializeField]
    private UIController uiController;

    private GameObject _target;
    private Upgradable _targetUpgradable;

    private List<GameObject> Stars;

    public void SetRate(int rate)
    {

        if (Stars == null)
        {

            Init();

        }

        int i = 0;

        for (; i < rate; ++i)
        {

            Stars[i].SetActive(true);

        }

        for (; i < 5; ++i)
        {

            Stars[i].SetActive(false);

        }

    }

    private void Init()
    {

        Stars = new List<GameObject>();

        for (int i = 0; i < 5; ++i)
        {

            Stars.Add(Instantiate(StarTemplate));

            Stars[i].transform.SetParent(Rate.transform, false);

            Stars[i].SetActive(true);

        }

    }

    public void Open(GameObject building)
    {

        _target = building;
        _targetUpgradable = _target.GetComponent<Upgradable>();

        int rate = _targetUpgradable.Rate;

        SetRate(rate);

        gameObject.SetActive(true);

    }

    public void Close()
    {

        gameObject.SetActive(false);
        uiController.SetWindowClosed();

    }

    public void Upgrade()
    {

        builder.Upgrade(_target);

        int rate = _targetUpgradable.Rate;

        SetRate(rate);

    }

}
