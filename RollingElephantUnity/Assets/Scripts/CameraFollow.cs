using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    private float cameraY;
    private float cameraZ;

    private void Start()
    {
        cameraY = transform.position.y;
        cameraZ = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;
        transform.position = new Vector3(objectToFollow.position.x, cameraY, cameraZ);
    }
}
