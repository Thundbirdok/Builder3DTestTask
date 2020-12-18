using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GridController : MonoBehaviour
{    

    [SerializeField]
    private uint xGridSize = 5;
    [SerializeField]
    private uint zGridSize = 5;

    [SerializeField]
    private uint xCellSize = 1;
    [SerializeField]
    private uint zCellSize = 1;

    [SerializeField]
    private GameObject Tile = null;

    [SerializeField]
    private List<List<GameObject>> Tiles = null;

    [SerializeField]
    private bool isApply = false;

    void Start()
    {
        
    }

    void Update()
    {
        
        if (isApply)
        {

            isApply = false;

            CreateGrid();

        }

    }

    private void CreateGrid()
    {

        Tiles = new List<List<GameObject>>();

        for (int x = 0; x < xGridSize; ++x)
        {

            Tiles.Add(new List<GameObject>());

            for (int z = 0; z < xGridSize; ++z)
            {

                Vector3 position = new Vector3(transform.position.x + (-(xGridSize / 2) + x) * xCellSize, 
                    0, transform.position.z + (-(zGridSize / 2) + z) * zCellSize);

                GameObject t = Instantiate(Tile, position, Quaternion.identity, transform);

                t.transform.localScale = new Vector3(xCellSize, 1, zCellSize);

                Tiles[x].Add(t);

            }

        }

    }
}
