using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxFactor;
    [SerializeField]
    private Transform _referenceGameObjectTransform;
    private Vector3 _starting_position;
    void Start()
    {
        _starting_position = transform.position;
        _referenceGameObjectTransform = FindObjectOfType<RollingElephant>().transform;
    }

    void Update()
    {
        transform.position = _starting_position + new Vector3(_referenceGameObjectTransform.position.x * parallaxFactor,0,0);
    }
}
