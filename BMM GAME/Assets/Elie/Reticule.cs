using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Reticule : MonoBehaviour
{
    // ======================================================================
    // MONOBEHAVIOUR
    // ======================================================================

    private void Start()
    {
        GetComponent<RectTransform>().position = new Vector3(
            Screen.width/2,
            Screen.height/2,
            0);
    }

    // ======================================================================
    // PUBLIC METHODS
    // ======================================================================

    // ======================================================================
    // PRIVATE METHODS
    // ======================================================================
}
