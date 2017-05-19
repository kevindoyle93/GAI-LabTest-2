using UnityEngine;

public class MoveToFlowerState : State
{
    Arrive arrive;

    GameObject flower;

    public MoveToFlowerState(GameObject gameObject) : base(gameObject)
    {
        this.gameObject = gameObject;
    }

    public MoveToFlowerState(GameObject gameObject, GameObject flower) : base(gameObject)
    {
        this.gameObject = gameObject;
        this.flower = flower;
    }

    public override void Enter()
    {
        arrive = gameObject.GetComponent<Arrive>();
        arrive.targetGameObject = flower;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, flower.transform.position) < 1.0f)
        {
            gameObject.GetComponent<StateMachine>().SwitchState(new CollectPollenState(gameObject, flower.GetComponent<Flower>()));
        }
    }
}
