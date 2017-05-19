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
        arrive = gameObject.AddComponent<Arrive>();
        arrive.targetGameObject = gameObject.transform.parent.gameObject;
        gameObject.GetComponent<Boid>().behaviours.Add(arrive);
    }

    public override void Exit()
    {
        gameObject.GetComponent<Boid>().behaviours.Remove(arrive);
        GameObject.Destroy(arrive);
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
