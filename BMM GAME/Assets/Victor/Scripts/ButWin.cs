using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButWin : MonoBehaviour
{

    private GameObject lvManager;
    public GameObject Fxgoal;
    // Start is called before the first frame update
    void Start()
    {
        lvManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == ("Ballon")|| collision.gameObject.name == ("B-head"))
        {
            lvManager.GetComponent<Level1>().win();
            Debug.Log("olalalatfort");
            Fxgoal.SetActive(true);

        }
    }
}
