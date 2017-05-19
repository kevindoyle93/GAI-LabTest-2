using UnityEngine;

public class ReturnToHiveState : State
{
    Arrive arrive;

    public ReturnToHiveState(GameObject gameObject) : base(gameObject)
    {
        this.gameObject = gameObject;
    }

    public override void Enter()
    {
        arrive = gameObject.GetComponent<Arrive>();
        arrive.targetGameObject = gameObject.transform.parent.gameObject;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, gameObject.transform.parent.transform.position) < 1.0f)
        {
            gameObject.transform.parent.GetComponent<BeeSpawner>().pollenCount += gameObject.GetComponent<Bee>().collectedPollen;
            gameObject.GetComponent<Bee>().collectedPollen = 0.0f;
            gameObject.GetComponent<StateMachine>().SwitchState(new ExploreState(gameObject));
        }
    }
}
