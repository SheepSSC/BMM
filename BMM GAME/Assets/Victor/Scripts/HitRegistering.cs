using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRegistering : MonoBehaviour
{
    public GameObject daddy;
    public GameObject Player;
    private Animator m_Animator;
    private Rigidbody m_rb;
    public float pushPower;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = daddy.GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody>();
    }


    

            public void OnHit()
    { 
        Vector3 myPos = transform.position;
        Vector3 PlayerPos = Player.transform.position;
        print("touched");
        m_Animator.enabled = false;

        m_rb.AddForce((myPos - PlayerPos).normalized * pushPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
