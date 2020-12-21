using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    [SerializeField]
    private Transform objectsPool;

    [SerializeField]
    private GameObject[] objectsToBuild;

    public Transform ObjectsPool { get => objectsPool; }
    public GameObject[] ObjectsToBuild { get => objectsToBuild; }

    public void Build(GameObject place, int index)
    {

        GameObject obj = Instantiate(objectsToBuild[index],
            place.transform.position + new Vector3(0, 0.5f, 0),
            Quaternion.identity, ObjectsPool);

        SaveData saveData = obj.GetComponent<SaveData>();

        saveData.Index = index;        

    }

    public void Build(Vector3 place, int index, int rate)
    {

        GameObject obj = Instantiate(objectsToBuild[index],
            place + new Vector3(0, 0.5f, 0),
            Quaternion.identity, ObjectsPool);

        SaveData saveData = obj.GetComponent<SaveData>();

        saveData.Index = index;        

        if (rate > 1)
        {

            obj.GetComponent<Upgradable>().Upgrade(rate);

        }

    }

    public void Upgrade(GameObject building)
    {

        building.GetComponent<Upgradable>().Upgrade();

    }

    public void Clear()
    {

        for (int i = ObjectsPool.childCount - 1; i >= 0; --i)
        {

            Destroy(ObjectsPool.GetChild(i).gameObject);

        }

    }

}
