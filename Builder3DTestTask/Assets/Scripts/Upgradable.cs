using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradable : MonoBehaviour
{

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Color[] RateColors;

    private int rate = 1;

    public int Rate { get => rate; }

    void Start()
    {

        meshRenderer.material.color = RateColors[rate - 1];

    }

    public void Upgrade()
    {

        if (rate < 5)
        {

            ++rate;
            meshRenderer.material.color = RateColors[rate - 1];

        }

    }

}
