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

            if (Stars[i] == null)
            {

                Debug.Log("WTF " + i);

            }

            Stars[i].SetActive(true);

        }

        for (; i < 5; ++i)
        {

            if (Stars[i] == null)
            {

                Debug.Log("WTF " + i);

            }

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
}
