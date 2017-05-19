using UnityEngine;
using System.Collections;
using System;

public class ExploreState : State
{
    Arrive arrive;

    private bool searching = true;
    private float searchRadius = 20.0f;

    public ExploreState(GameObject gameObject) : base(gameObject)
    {
        this.gameObject = gameObject;
    }

    public override void Enter()
    {
        Vector3 target = ChooseNewTarget();

        arrive = gameObject.AddComponent<Arrive>();
        arrive.targetPosition = target;

        gameObject.GetComponent<Boid>().behaviours.Add(arrive);
    }

    public override void Exit()
    {
        gameObject.GetComponent<Boid>().behaviours.Remove(arrive);
        GameObject.Destroy(arrive);
    }

    public override void Update()
    {
        if (arrive != null)
        {
            if (Vector3.Distance(gameObject.transform.position, arrive.targetPosition) < 1.0f)
            {
                ChooseNewTarget();
            }
        }
    }

    Vector3 ChooseNewTarget()
    {
        return Vector3.zero;
    }

    IEnumerator CheckForFlowers()
    {
        while (searching)
        {
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, searchRadius);

            foreach (Collider c in colliders)
            {
                if (c.gameObject.tag.Equals("flower"))
                {
                    // gameObject.GetComponent<StateMachine>().SwitchState(new ExploreState(gameObject));
                    Debug.Log("Found one");
                }

                yield return new WaitForSeconds(5.0f);
            }
        }
    }
}
