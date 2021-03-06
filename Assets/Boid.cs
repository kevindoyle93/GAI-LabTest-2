﻿using UnityEngine;
using System.Collections.Generic;

public class Boid : MonoBehaviour
{
    public Vector3 force;
    public Vector3 acceleration;
    public Vector3 velocity;

    public float mass = 1.0f;
    public float maxSpeed = 5.0f;

    [HideInInspector]
    public List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

	void Start ()
    {
        foreach (SteeringBehaviour b in GetComponents<SteeringBehaviour>())
        {
            behaviours.Add(b);
        }
	}

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;

        return desired - velocity;
    }

    public Vector3 ArriveForce(Vector3 target, float slowingDistance)
    {
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;

        if (distance == 0)
        {
            return Vector3.zero;
        }

        float ramped = maxSpeed * (distance / slowingDistance);
        float clamped = Mathf.Min(ramped, maxSpeed);

        Vector3 desiredVelocity = clamped * (toTarget / distance);
        return desiredVelocity - velocity;
    }

    Vector3 Calculate()
    {
        force = Vector3.zero;

        foreach (SteeringBehaviour b in behaviours)
        {
            force += b.Calculate() * b.weight;
            Debug.Log(b);
        }

        return force;
    }
	
	void Update ()
    {
        force = Calculate();
        Vector3 newAcceleration = force / mass;

        float smoothRate = Mathf.Clamp(9.0f * Time.deltaTime, 0.15f, 0.4f) / 2.0f;
        acceleration = Vector3.Lerp(acceleration, newAcceleration, smoothRate);

        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 globalUp = new Vector3(0, 0.2f, 0);
        Vector3 accelUp = acceleration * 0.05f;
        Vector3 bankUp = accelUp + globalUp;
        smoothRate = Time.deltaTime * 3.0f;
        Vector3 tempUp = transform.up;
        tempUp = Vector3.Lerp(tempUp, bankUp, smoothRate);

        if (velocity.magnitude > 0.0001f)
        {
            transform.LookAt(transform.position + velocity, tempUp);
            velocity *= 0.99f;
        }
        transform.position += velocity * Time.deltaTime;
    }
}
