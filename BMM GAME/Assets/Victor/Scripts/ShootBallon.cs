using System.Collections;
using UnityEngine;

public class ShootBallon : MonoBehaviour
{
    [Header("TWEAKABLE")]

    public LayerMask shootMask;
    public float slowMotionTime = 2;
    public AnimationCurve slowMotionCurve;
    public enum ShootMode { ShootOnce, ShootMultiple }
    public ShootMode shootMode = ShootMode.ShootOnce;
    public float unscaledTimeShootCooldown = .5f;

    [Header("REFERENCES")]

    public Transform canon;
    public GameObject gunPos;
    public LaserPointer pointer;
    public GameObject prefab;
    private Animator myAnimator;

    //[Header("REFERENCES")]

    //public AudioSource music;

    private bool canShoot = true;


    private void Awake()
    {
        myAnimator = gunPos.GetComponent<Animator>();
    }

    public void Shooting()
    {
        if (!canShoot) return; // EXIT : Can't shoot;
        Instantiate(prefab, transform.position, transform.rotation);
        myAnimator.SetTrigger("Shoot");

       

        //instantiate le ballon avec de la velocity


        if (shootMode == ShootMode.ShootOnce)
            {
                canShoot = false;
                pointer.SetSightActive(canShoot);
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

   
}