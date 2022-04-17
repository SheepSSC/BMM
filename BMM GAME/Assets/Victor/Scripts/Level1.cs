using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public float timebtwnCam = 0.3f;
    public Image Crossfade;
    public string Scene_Name = "SceneX";
    public GameObject end;

    // Start is called before the first frame update
    void Start()
    {
       Crossfade.CrossFadeAlpha(0, 2f, false);
    }
    private void Update()
    {
        
    }
    public void win()
    {
        if (end)
        {
            end.SetActive(true);
            Time.timeScale = 0;
            return;
        }

        StartCoroutine(ExampleCoroutine());


        IEnumerator ExampleCoroutine()
        {
            yield return new WaitForSeconds(timebtwnCam);
            cam1.SetActive(false);
            yield return new WaitForSeconds(timebtwnCam);

            cam2.SetActive(false);
            yield return new WaitForSeconds(timebtwnCam);

            yield return new WaitForSeconds(1);
            Crossfade.CrossFadeAlpha(1, 2.0f, false);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(Scene_Name);
            
        }
    }

   


    }
