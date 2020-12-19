using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] 
    private Vector3 target = Vector3.zero;
    [SerializeField] 
    private float minDistanceToTarget = 5;
    [SerializeField]
    private float maxDistanceToTarget = 10;
    [SerializeField]
    private float distanceToTarget = 8;
    [SerializeField]
    private float aroundYSpeed = 5;
    [SerializeField]
    private float aroundXSpeed = 5;
    [SerializeField]
    private float ZoomSpeed = 1;

    private float rotationAroundYAxis;
    private float rotationAroundXAxis;

    void Update()
    {

        distanceToTarget += Input.GetAxis("Mouse ScrollWheel")
            * ZoomSpeed;

        distanceToTarget = Mathf.Clamp(distanceToTarget, 
            minDistanceToTarget, maxDistanceToTarget);

        rotationAroundYAxis += Input.GetAxis("Horizontal") * -aroundXSpeed; 
        rotationAroundXAxis += Input.GetAxis("Vertical") * aroundYSpeed;

        rotationAroundXAxis = Mathf.Clamp(rotationAroundXAxis, -85f, 85f);

        transform.position = target;

        transform.localRotation = Quaternion.Euler(rotationAroundXAxis, 
            rotationAroundYAxis, 0);

        transform.Translate(new Vector3(0, 0, -distanceToTarget));        

    }

}