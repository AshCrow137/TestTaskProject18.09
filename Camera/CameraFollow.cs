using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform TargetTransform;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position- TargetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset+ TargetTransform.position;
    }
}
