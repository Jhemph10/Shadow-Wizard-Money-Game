using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class Fire : Player
{
    // Create a Method for impact effect on enemy 
    public TextMeshProUGUI ammoDisplay;
    public Image fireIcon;
    public float range = 100f;
    public NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Enemy enemy;
    public Player player;
    private bool onFire = false;
    
    public Camera Fpscam;
    //public ParticleSystem fireEffect;


    // Update is called once per frame
    void Update()
    {
        
        if (manaBar.slider.value > 0){

            if (Input.GetButtonDown("Fire") && onFire == false)
            {
                CastSpell(20);
                Debug.Log(manaBar.slider.value);
                ShootFire();
                StartCoroutine(FireCoolDown());
            }


        } else {

        }

        
    }

    IEnumerator FireCoolDown()
    {
        onFire = true;
        fireIcon.enabled = false;
        yield return new WaitForSeconds(3);
        fireIcon.enabled = true;
        onFire = false;
        Debug.Log("Spells is back");
    }

    // A method created to shoot out a ray that gains the objects information
    // , checks to see if its an object then applies damage to that object
    public void ShootFire ()
    {
       //Element for target

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

}
