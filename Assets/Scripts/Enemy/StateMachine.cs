using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public Player player;
    public ParticleSystem muzzleFlash;

    public void Initialize()
    {
        ChangeState(new PatrolState());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState){

        if(activeState != null){
            activeState.Exit();
        }

        activeState = newState;

        if(activeState != null){
            //Setup new state.
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
