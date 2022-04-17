using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserPointer : MonoBehaviour
{
    public LayerMask layerMask;
    public LineRenderer lr;
    public GameObject light;

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
            lr.enabled = true;
            lr.SetPosition(1, hit.point);
            light.SetActive(true);
            light.transform.position = hit.point;
        }
        else
        {
            lr.enabled = false;
            //lr.SetPosition(1, (transform.forward) * 50f);
            light.SetActive(false);
        }
    }

    // ======================================================================
    // PUBLIC METHODS
    // ======================================================================

    public void SetSightActive(bool value)
    {
        lr.enabled = value;
        light.SetActive(value);
    }

    // ======================================================================
    // PRIVATE METHODS
    // ======================================================================
}
