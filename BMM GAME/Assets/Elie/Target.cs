using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int number;
    public float shootForce = 200;
    public TargetHandler handler;
    bool canBeShooted = true;

    private void Start()
    {
        handler.AddToHandler(this);
    }

    public void IsShooted(Transform gun)
    {
        if (!canBeShooted) return;

        handler.CheckTargetOrder(number);
        canBeShooted = false;

        GetComponent<Rigidbody>().AddForce(gun.forward * shootForce, ForceMode.Impulse);
    }

    public void ResetTarget()
    {
        canBeShooted = true;
    }
}
