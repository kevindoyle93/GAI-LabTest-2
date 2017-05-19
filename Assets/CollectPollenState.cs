using UnityEngine;

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
        // Check if other bee got this flower first
        if (flower == null)
        {
            gameObject.GetComponent<Arrive>().targetGameObject = null;
            gameObject.GetComponent<StateMachine>().SwitchState(new ExploreState(gameObject));
        }

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
