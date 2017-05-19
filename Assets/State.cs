using UnityEngine;
using System.Collections;

public abstract class State
{
    public GameObject gameObject;

    public State(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();
}
