using UnityEngine;

public class Arrive : SteeringBehaviour
{
    public GameObject targetGameObject;
    public Vector3 targetPosition;

    public float slowingDistance = 5.0f;

    public override Vector3 Calculate()
    {
        return boid.ArriveForce(targetPosition, slowingDistance);
    }

    void Update()
    {
        if (targetGameObject != null)
        {
            targetPosition = targetGameObject.transform.position;
        }
    }
}
