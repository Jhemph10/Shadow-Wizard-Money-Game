using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class Lightning : Player
{
    // Create a Method for impact effect on enemy 
    public TextMeshProUGUI ammoDisplay;
    public Image lightningIcon;
    public float range = 100f;
    public NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Enemy enemy;
    private bool onLightning = false;
    
    public Camera Fpscam;
    //public ParticleSystem muzzleFlash;


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

        } else {

        }

        
    }

    IEnumerator LightningCoolDown()
    {
        onLightning = true;
        lightningIcon.enabled = false;
        yield return new WaitForSeconds(7);
        lightningIcon.enabled = true;
        onLightning = false;
        Debug.Log("Spells is back");
    }

    // A method created to shoot out a ray that gains the objects information
    // , checks to see if its an object then applies damage to that object

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
