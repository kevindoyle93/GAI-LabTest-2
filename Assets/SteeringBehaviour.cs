using UnityEngine;
using System.Collections;

public abstract class SteeringBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Boid boid;

    public float weight = 1.0f;

    void Awake()
    {
        boid = GetComponent<Boid>();
    }

    public abstract Vector3 Calculate();
}
