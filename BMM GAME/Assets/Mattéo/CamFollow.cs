using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public Transform toFollow;
    void LateUpdate()
    {
        Vector3 newPosition = toFollow.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
