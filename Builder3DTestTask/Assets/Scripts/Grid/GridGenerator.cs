using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class GridGenerator : MonoBehaviour
{

    [SerializeField]
    private int xGridSize = 5;
    [SerializeField]
    private int zGridSize = 5;

    [SerializeField]
    private int xCellSize = 1;
    [SerializeField]
    private int zCellSize = 1;

    [SerializeField]
    private GameObject Tile = null;

    [SerializeField]
    private List<List<GameObject>> Tiles = null;

    public void GenerateGrid()
    {

        if (Tiles != null)
        {

            for (int x = Tiles.Count - 1; x >= 0; --x)
            {

                for (int z = Tiles[x].Count - 1; z >= 0; --z)
                {

#if UNITY_EDITOR

                    DestroyImmediate(Tiles[x][z]);

#else

                    Destroy(Tiles[x][z]);

#endif

                    Tiles[x].RemoveAt(z);

                }

                Tiles.RemoveAt(x);

            }

        }
        else
        {

            Tiles = new List<List<GameObject>>();

        }

        for (int x = 0; x < xGridSize; ++x)
        {

            Tiles.Add(new List<GameObject>());

            for (int z = 0; z < zGridSize; ++z)
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