using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public Transform toFollow;

    public float height;

    void LateUpdate()
    {
        Vector3 newPosition = toFollow.position;
        newPosition.y = height;
        transform.position = newPosition;
    }
}
