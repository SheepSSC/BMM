using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserPointer : MonoBehaviour
{
    public LayerMask layerMask;
    public LineRenderer lr;

    // ======================================================================
    // MONOBEHAVIOUR
    // ======================================================================

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, layerMask))
        {
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.SetPosition(1, transform.forward * 50f);
        }
    }

    // ======================================================================
    // PUBLIC METHODS
    // ======================================================================

    // ======================================================================
    // PRIVATE METHODS
    // ======================================================================
}
