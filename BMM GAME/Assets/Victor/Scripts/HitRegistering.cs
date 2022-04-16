using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRegistering : MonoBehaviour
{

    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }


    

            public void OnDebugAction()
    {
        m_Animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
