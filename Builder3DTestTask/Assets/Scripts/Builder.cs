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



    }

}
