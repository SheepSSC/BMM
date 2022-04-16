using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void win()
    {
        StartCoroutine(ExampleCoroutine());


        IEnumerator ExampleCoroutine()
        {
            yield return new WaitForSeconds(.3f);
            cam1.SetActive(false);
            yield return new WaitForSeconds(.3f);

            cam2.SetActive(false);
            yield return new WaitForSeconds(.3f);

            



        }
    }

   


    }
