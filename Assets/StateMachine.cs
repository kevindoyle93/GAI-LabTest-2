using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour
{
    [HideInInspector]
    public State currentState;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
	}

    public void SwitchState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }
}
