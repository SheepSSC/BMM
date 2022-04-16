using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserPointer : MonoBehaviour
{
    public LayerMask layerMask;
    private LineRenderer lr;

    // ======================================================================
    // MONOBEHAVIOUR
    // ======================================================================

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Vector3 fwd = transform.TransformVector(Vector3.forward);

        if (Physics.Raycast(transform.localPosition, fwd, out RaycastHit hit, layerMask))
        {
            lr.enabled = true;
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.enabled = false;
        }
    }

    // ======================================================================
    // PUBLIC METHODS
    // ======================================================================

    // ======================================================================
    // PRIVATE METHODS
    // ======================================================================
}
