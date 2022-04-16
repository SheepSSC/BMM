using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRegistering : MonoBehaviour
{
    public GameObject daddy;
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = daddy.GetComponent<Animator>();
    }


    

            public void OnHit()
    {
        print("touched");
        m_Animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
