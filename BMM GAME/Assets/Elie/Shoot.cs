using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [Header("TWEAKABLE")]

    public LayerMask shootMask;
    public float slowMotionTime = 2;
    public AnimationCurve slowMotionCurve;
    public enum ShootMode { ShootOnce, ShootMultiple}
    public ShootMode shootMode = ShootMode.ShootOnce;
    public float unscaledTimeShootCooldown = .5f;
    public Transform cam;

    [Header("REFERENCES")]

    public Transform canon;
    public GameObject gunPos;
    public LaserPointer pointer;
    public List<ParticleSystem> shootFX;
    public GameObject disto;
    private GameObject reticule;
    private Animator myAnimator;

    //[Header("REFERENCES")]

    //public AudioSource music;

    private bool canShoot = true;


    private void Awake()
    {
        myAnimator = gunPos.GetComponent<Animator>();
        cam = GameObject.Find("MainCamera").transform;
        reticule = GameObject.Find("Reticule");
        shootMask = LayerMask.GetMask("Mind");

    }
    private void Update()
    {
     

        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit,1000000, shootMask))
        {
           GameObject objectHit =  hit.transform.transform.gameObject;

            gunPos.transform.LookAt(hit.point);
            reticule.GetComponent<Animator>().SetBool("Aim", true);

        }
        else
        {
          
            reticule.GetComponent<Animator>().SetBool("Aim", false);
        }
    }
    public void Shooting()
    {
        if (!canShoot) return; // EXIT : Can't shoot;

        myAnimator.SetTrigger("Shoot");

        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, 1000000, shootMask))
        {
            Touched(hit.transform.gameObject);
            SlowMotion();
            reticule.SetActive(false);

            foreach (ParticleSystem ps in shootFX)
            {
                ps.gameObject.SetActive(false);
                ps.gameObject.SetActive(true);
                ps.Play();
            }

            disto.SetActive(false);
            disto.SetActive(true);

            if (shootMode == ShootMode.ShootOnce)
            {
                canShoot = false;
                pointer.SetSightActive(canShoot);
            }
        }
    }

    private void SlowMotion()
    {
        StopAllCoroutines();
        StartCoroutine(SlowMoCoroutine());
    }

    IEnumerator SlowMoCoroutine()
    {
        if (shootMode == ShootMode.ShootMultiple)
        {
            canShoot = false;
            pointer.SetSightActive(canShoot);
            StartCoroutine(CooldownCoroutine());
        }

        float currentTime = 0;
        float pct = 0;

        while (pct < 1)
        {
            currentTime += Time.unscaledDeltaTime;
            pct = currentTime / slowMotionTime;
            if (pct < 1)
            {
                Time.timeScale = slowMotionCurve.Evaluate(pct);
            }
            else
            {
                Time.timeScale = 1;
            }
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            //music.pitch = Time.timeScale;

            yield return null;
        }
    }

    IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSecondsRealtime(unscaledTimeShootCooldown);
        canShoot = true;
        pointer.SetSightActive(canShoot);
    }

    private void Touched(GameObject hit)
    {
        if (hit.GetComponent<HitRegistering>())
            hit.GetComponent<HitRegistering>().OnHit();
        else if (hit.GetComponent<Target>())
            hit.GetComponent<Target>().IsShooted(transform);
        else if (hit.GetComponent<End>())
            hit.GetComponent<End>().TheEnd();
    }
}