using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonInpulse : MonoBehaviour
{
    private Rigidbody m_Rb;
    private GameObject gun;
    // Start is called before the first frame update

    private void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        gun = GameObject.Find("Gun ballon");
    }
    void Start()
    {
      
        

        m_Rb.AddForce(gun.transform.forward*500, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<HitRegistering>().OnHit();
    }
    

      

  
}
