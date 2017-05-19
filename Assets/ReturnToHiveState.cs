using UnityEngine;
using System.Collections;
using System;

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
            Debug.Log("Home");
        }
    }
}
