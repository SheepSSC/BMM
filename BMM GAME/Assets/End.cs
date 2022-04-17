using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject endCanvas;
    public Shoot shoot;

    public void TheEnd()
    {
        endCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
