using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMotor : InputManager
{

    //Stamina Variables
    public Image StaminaBar;
    public float Stamina, maxStamina;
    public float AttackCost;
    public float runCost;
    public float chargeRate;
    AudioManager audioManager;

    private Coroutine recharge;

    //Regulare Movement Variables
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float sprintSpeed;

    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    private bool crouching = false;
    public float crouchTimer = 1;
    private bool lerpCrouch = false;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else 
                controller.height = Mathf.Lerp(controller.height, 2, p);  

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0;
            } 
        }

        if(isSprinting){
             speed = sprintSpeed;
             Stamina -= runCost * Time.deltaTime;
             if(Stamina < 0) Stamina = 0;
             StaminaBar.fillAmount = Stamina / maxStamina;

             if(recharge != null) StopCoroutine(recharge);
             recharge = StartCoroutine(RechargeStamina());

        } else {  
            speed = 5;
        }

        if (Stamina == 0){
            speed = 5;
        }

        // if(Input.GetButtonDown("f")){
        //     Debug.Log("Attack!");

        //     Stamina -= AttackCost;
        //     if(Stamina < 0) Stamina = 0;
        //     StaminaBar.fillAmount = Stamina / maxStamina;
        // }

    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void ProcessMove (Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0){
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
      
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    private IEnumerator RechargeStamina(){
        yield return new WaitForSeconds(1f);

        while(Stamina < maxStamina){
            Stamina += chargeRate / 10f;
            if(Stamina > maxStamina) Stamina = maxStamina;
            StaminaBar.fillAmount = Stamina / maxStamina;
            yield return new WaitForSeconds(.1f);
        }



    }

}
