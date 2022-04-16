using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientToCamera : MonoBehaviour
{
    public Transform orientTo;

    void Update()
    {
        transform.LookAt(orientTo);
    }
}
