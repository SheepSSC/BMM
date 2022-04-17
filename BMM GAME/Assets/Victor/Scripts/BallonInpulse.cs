using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonInpulse : MonoBehaviour
{
    private Rigidbody m_Rb;
    private GameObject gun;
    public float force = 500;
    // Start is called before the first frame update

    private void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        gun = GameObject.Find("Gun ballon");
    }
    void Start()
    {

        Vector3 torque;


        m_Rb.AddForce(gun.transform.forward*force, ForceMode.Impulse);
        torque.x = Random.Range(-200, 200);
        torque.y = Random.Range(-200, 200);
        torque.z = Random.Range(-200, 200);

        m_Rb.AddTorque ( torque ) ;
    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<HitRegistering>().OnHit();
    }
    

      

  
}
