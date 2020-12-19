using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] 
    private Vector3 target;
    [SerializeField] 
    private float distanceToTarget = 5;
    [SerializeField]
    private float aroundYSpeed = 5;
    [SerializeField]
    private float aroundXSpeed = 5;

    private float rotationAroundYAxis;
    private float rotationAroundXAxis;

    void Update()
    {

        rotationAroundYAxis += Input.GetAxis("Horizontal") * -aroundXSpeed; 
        rotationAroundXAxis += Input.GetAxis("Vertical") * aroundYSpeed;

        rotationAroundXAxis = Mathf.Clamp(rotationAroundXAxis, -85f, 85f);

        transform.position = target;

        transform.localRotation = Quaternion.Euler(rotationAroundXAxis, rotationAroundYAxis, 0);

        transform.Translate(new Vector3(0, 0, -distanceToTarget));        

    }

}
