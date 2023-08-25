using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activateState;

    public void Initialise()
    {
        ChangeState(new PatrolState());
    }

    // Update is called once per frame
    void Update()
    {
        if(activateState != null)
        {
            activateState.Perform();
        }
        
    }

    public void ChangeState(BaseState newState)
    {
        if(activateState != null)
        {
            activateState.Exit();
        }

        activateState = newState;

        if(activateState != null)
        {
            activateState.stateMachine = this;
            activateState.enemy = GetComponent<Enemy>();
            activateState.Enter();
        }
    }
}
