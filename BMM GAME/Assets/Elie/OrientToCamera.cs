using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientToCamera : MonoBehaviour
{
    public Transform orientTo;
    public float offset = 180;

    void Update()
    {
        transform.LookAt(orientTo);
        transform.eulerAngles = new Vector3(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y *-1,
            transform.rotation.eulerAngles.z);
    }
}
