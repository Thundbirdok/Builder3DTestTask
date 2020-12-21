using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    [SerializeField]
    private Builder builder;

    [SerializeField]
    private GridGenerator gridGenerator;

    public struct GridData
    {

        public int XGridSize;
        public int ZGridSize;
        public int XCellSize;
        public int ZCellSize;

    }

    private struct SaveObject
    {

        public int XGridSize;
        public int ZGridSize;
        public int XCellSize;
        public int ZCellSize;
        
        public float[] X;
        public float[] Y;
        public float[] Z;
        public int[] Index;
        public int[] Rate;

    }

    void Awake()
    {
        
    }

    public void Save()
    {        

        SaveObject saveObject;

        saveObject.Index = new int[builder.ObjectsPool.childCount];        
        saveObject.X = new float[builder.ObjectsPool.childCount];
        saveObject.Y = new float[builder.ObjectsPool.childCount];
        saveObject.Z = new float[builder.ObjectsPool.childCount];
        saveObject.Rate = new int[builder.ObjectsPool.childCount];

        for (int i = 0; i < builder.ObjectsPool.childCount; ++i)
        {

            GameObject obj = builder.ObjectsPool.GetChild(i).gameObject;            

            saveObject.Index[i] = obj.GetComponent<SaveData>().Index;
            
            saveObject.X[i] = obj.transform.position.x;
            saveObject.Y[i] = obj.transform.position.y - 0.5f;
            saveObject.Z[i] = obj.transform.position.z;

            Upgradable upgradable = obj.GetComponent<Upgradable>();

            if (upgradable != null)
            {

                saveObject.Rate[i] = upgradable.Rate;

            }
            else
            {

                saveObject.Rate[i] = 0;

            }

        }

        GridData gridData = gridGenerator.GetGridData();           

        saveObject.XGridSize = gridData.XGridSize;
        saveObject.ZGridSize = gridData.ZGridSize;
        saveObject.XCellSize = gridData.XCellSize;
        saveObject.ZCellSize = gridData.ZCellSize;

        string json = JsonUtility.ToJson(saveObject);                

        SaveSystem.Save(json);

    }

    public void Load()
    {

        string json = SaveSystem.Load();        

        if (json == "")
        {

            return;

        }

        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(json);

        GridData gridData;

        gridData.XGridSize = saveObject.XGridSize;
        gridData.ZGridSize = saveObject.ZGridSize;
        gridData.XCellSize = saveObject.XCellSize;
        gridData.ZCellSize = saveObject.ZCellSize;

        gridGenerator.SetGrid(gridData);        

        builder.Clear();        

        for (int i = 0; i < saveObject.Index.Length; ++i)
        {

            Vector3 place = new Vector3(saveObject.X[i], saveObject.Y[i], saveObject.Z[i]);

            builder.Build(place, saveObject.Index[i], saveObject.Rate[i]);

        }

    }

}
