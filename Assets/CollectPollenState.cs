using UnityEngine;
using System.Collections;
using System;

public class CollectPollenState : State
{
    Flower flower;

    public CollectPollenState(GameObject gameObject) : base(gameObject)
    {
        this.gameObject = gameObject;
    }

    public CollectPollenState(GameObject gameObject, Flower flower) : base(gameObject)
    {
        this.gameObject = gameObject;
        this.flower = flower;
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        float availablePollen;
        if (flower.polen > Time.deltaTime)
        {
            availablePollen = Time.deltaTime;
        }
        else
        {
            availablePollen = flower.polen;
        }

        gameObject.GetComponent<Bee>().collectedPollen += availablePollen;
        flower.polen -= availablePollen;

        if (flower.polen == 0)
        {
            GameObject.Destroy(flower.gameObject);
            gameObject.GetComponent<StateMachine>().SwitchState(new ReturnToHiveState(gameObject));
        }
    }
}
