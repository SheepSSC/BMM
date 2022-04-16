using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int number;
    public TargetHandler handler;
    bool canBeShooted = true;

    private void Start()
    {
        handler.AddToHandler(this);
    }

    public void IsShooted()
    {
        if (!canBeShooted) return;

        handler.CheckTargetOrder(number);
        canBeShooted = false;
    }

    public void ResetTarget()
    {
        canBeShooted = true;
    }
}
