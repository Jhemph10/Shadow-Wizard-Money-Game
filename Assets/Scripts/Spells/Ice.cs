using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class Ice : Player
{
    // Create a Method for impact effect on enemy 
    public TextMeshProUGUI ammoDisplay;
    public Image iceIcon;
    public float range = 100f;
    public NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Enemy enemy;
    private bool onIce = false;
    public GameObject ice;
    
    public Camera Fpscam;
    //public ParticleSystem muzzleFlash;


    // Update is called once per frame
    void Update()
    {
        
        if (manaBar.slider.value > 0){

            if (Input.GetButtonDown("Fire") && onIce == false)
            {
                CastSpell(35);
                ShootIce();
                StartCoroutine(IceCoolDown());
            }


        } else {

        }

        
    }

    IEnumerator IceCoolDown()
    {
        onIce = true;
        iceIcon.enabled = false;
        yield return new WaitForSeconds(5);
        iceIcon.enabled = true;
        onIce = false;
        Debug.Log("Spells is back");
    }


    public void ShootIce ()
    {
        //Element for target

        RaycastHit hit;
        if (Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //enable ice effect
            ice.SetActive(true);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(35);
                agent.speed = 0;          

            }
        }
    }

}
