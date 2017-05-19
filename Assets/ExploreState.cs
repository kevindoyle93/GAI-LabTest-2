using UnityEngine;

public class ExploreState : State
{
    Arrive arrive;
    
    private float searchRadius = 20.0f;

    private float searchUpdateRate = 0.2f;
    private float searchUpdateAcc = 0.0f;

    public ExploreState(GameObject gameObject) : base(gameObject)
    {
        this.gameObject = gameObject;
    }

    public override void Enter()
    {
        arrive = gameObject.GetComponent<Arrive>();

        if (arrive == null)
        {
            arrive = gameObject.AddComponent<Arrive>();
        }

        ChooseNewTarget();

        gameObject.GetComponent<Boid>().behaviours.Add(arrive);
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        // Would do on co-routine rather than with accumulator, but State does not extend MonoBehaviour
        searchUpdateAcc += Time.deltaTime;
        if (searchUpdateAcc > searchUpdateRate)
        {
            CheckForFlowers();
            searchUpdateAcc = 0.0f;
        }

        if (arrive != null)
        {
            if (Vector3.Distance(gameObject.transform.position, arrive.targetPosition) < 1.0f)
            {
                ChooseNewTarget();
            }
        }
    }

    void ChooseNewTarget()
    {
        arrive.targetPosition = new Vector3(Random.Range(-FlowerSpawner.radius, FlowerSpawner.radius), 0, Random.Range(-FlowerSpawner.radius, FlowerSpawner.radius));
    }

    void CheckForFlowers()
    {
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, searchRadius);

        foreach (Collider c in colliders)
        {
            if (c.gameObject.tag.Equals("flower"))
            {
                gameObject.GetComponent<StateMachine>().SwitchState(new MoveToFlowerState(gameObject, c.gameObject));
            }
        }
    }
}
