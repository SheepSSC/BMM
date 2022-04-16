using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetObjectCam : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

   

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, 0.05f,transform.position.z);
    }
}
