using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class Spells : Player
{
    // Create a Method for impact effect on enemy 
    public TextMeshProUGUI ammoDisplay;
    public float range = 100f;
    public NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Enemy enemy;
    private bool onFire = false;
    private bool onIce = false;
    private bool onLightning = false;
    
    public Camera Fpscam;
    public ParticleSystem muzzleFlash;


    // Update is called once per frame
    void Update()
    {
        
        if (manaBar.slider.value > 0){

            if (Input.GetButtonDown("Fire") && onLightning == false)
            {
                CastSpell(40);
                ShootLighting();
                StartCoroutine(LightningCoolDown());
            }

            if (Input.GetButtonDown("Fire") && onFire == false)
            {
                CastSpell(25);
                ShootFire();
                StartCoroutine(FireCoolDown());
            }

            if (Input.GetButtonDown("Fire") && onIce == false)
            {
                CastSpell(35);
                ShootIce();
                StartCoroutine(IceCoolDown());
            }


        } else {

        }

        
    }

    IEnumerator FireCoolDown()
    {
        onFire = true;
        yield return new WaitForSeconds(3);
        onFire = false;
        Debug.Log("Spells is back");
    }

    IEnumerator IceCoolDown()
    {
        onIce = true;
        yield return new WaitForSeconds(5);
        onIce = false;
        Debug.Log("Spells is back");
    }

    IEnumerator LightningCoolDown()
    {
        onLightning = true;
        yield return new WaitForSeconds(7);
        onLightning = false;
        Debug.Log("Spells is back");
    }

    // A method created to shoot out a ray that gains the objects information
    // , checks to see if its an object then applies damage to that object
    public void ShootFire ()
    {
        //muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

                IEnumerator damageOverTime()
               {
                    target.TakeDamage(10);
                    yield return new WaitForSeconds(1);
                    target.TakeDamage(5);
                    yield return new WaitForSeconds(1);
                    target.TakeDamage(5);
                    yield return new WaitForSeconds(1);
                    target.TakeDamage(5);
               }
            if (target != null)
            {
                StartCoroutine(damageOverTime());
            }
        }
    }

    public void ShootIce ()
    {
        //muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(35);
                agent.speed = 0;          

            }
        }
    }

    public void ShootLighting ()
    {
        //muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(45);
                enemy.fireRate = 100000;
            }
        }
    }

}
