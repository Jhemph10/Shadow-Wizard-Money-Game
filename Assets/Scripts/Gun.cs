using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Gun : MonoBehaviour
{
    // Create a Method for impact effect on enemy 
    public TextMeshProUGUI ammoDisplay;
    public Image shellOne;
    public Image shellTwo;
    public Image shellThree;
    public Image shellFour;
    public Image shellFive;
    public Image shellSix;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    AudioManager audioManager;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    public int bullets;
    private bool isReloading = false;
    public Camera Fpscam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    // Update is called once per frame
    void Update()
    {

        ammoDisplay.text = bullets.ToString();
        if (isReloading)
        {
            return;
        } 

        if (currentAmmo <= 0 || Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reload());
            audioManager.PlaySFX(audioManager.ReloadSound);
            bullets = maxAmmo;

            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            StartCoroutine(Waiting());
        }

        if (bullets == 5){
            shellOne.enabled = false;
        } else if (bullets == 4){
            shellTwo.enabled = false;
        } else if (bullets == 3){
            shellThree.enabled = false;
        } else if (bullets == 2){
            shellFour.enabled = false;
        } else if (bullets == 1){
            shellFive.enabled = false;
        } 

    }

    void OnEnable()
    {
        isReloading = false;
    }

    void Start()
    {
        currentAmmo = maxAmmo;
        bullets = currentAmmo;
    }

    IEnumerator Reload()
    {
        Debug.Log("YA");
        isReloading = true;

        shellOne.enabled = true;
        shellTwo.enabled = true;
        shellThree.enabled = true;
        shellFour.enabled = true;
        shellFive.enabled = true;

        yield return new WaitForSeconds(reloadTime - .25f);
        yield return new WaitForSeconds(1f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    IEnumerator Waiting()
    {
        audioManager.PlaySFX(audioManager.ShotgunShot);
        yield return new WaitForSeconds(.75f);
        audioManager.PlaySFX(audioManager.ShotgunShell);
    }

    // A method created to shoot out a ray that gains the objects information
    // , checks to see if its an object then applies damage to that object
    public void Shoot ()
    {
        muzzleFlash.Play();

        currentAmmo--;
        bullets--;

        RaycastHit hit;
        if (Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
