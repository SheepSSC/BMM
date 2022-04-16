using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public float timebtwnCam = 0.3f;

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
            yield return new WaitForSeconds(timebtwnCam);
            cam1.SetActive(false);
            yield return new WaitForSeconds(timebtwnCam);

            cam2.SetActive(false);
            yield return new WaitForSeconds(timebtwnCam);

            



        }
    }

   


    }
