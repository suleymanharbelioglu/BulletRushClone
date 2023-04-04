using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - target.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position + _offset;
        transform.position = pos;
        
    }
}
