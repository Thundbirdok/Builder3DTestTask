using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    [SerializeField]
    private Transform ObjectsPool;

    [SerializeField]
    private GameObject[] objectsToBuild;

    public GameObject[] ObjectsToBuild { get => objectsToBuild; }

    public void Build(GameObject place, int index)
    {
        
        Instantiate(objectsToBuild[index], 
            place.transform.position + new Vector3(0, 0.5f, 0), 
            Quaternion.identity, ObjectsPool);

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
