using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradable : MonoBehaviour
{

    private int rate = 1;

    public int Rate { get => rate; }

    public void Upgrade()
    {

        if (rate < 5)
        {

            ++rate;

        }

    }

}
