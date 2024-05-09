using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class AttackState : BaseState
{

    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    AudioManager audioManager;

    //public float waitForSearch;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime; 
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
                stateMachine.player.TakeDamage(20);
            }

            if(moveTimer > Random.Range(3,7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            
            losePlayerTimer += Time.deltaTime;
            //Add waitForSearch
            if(losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {
        //audioManager.PlaySFX(audioManager.RifleShot);
        enemy.muzzleFlash.Play();
        Debug.Log("shoot");
        shotTimer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
