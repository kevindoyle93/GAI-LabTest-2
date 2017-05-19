﻿using UnityEngine;
using System.Collections;

public class BeeSpawner : MonoBehaviour
{
    public GameObject beePrefab;

    private int numBees = 0;
    private float pollenCount = 10.0f;

	void Start ()
    {
        StartCoroutine(SpawnBee());
	}
	
	void Update ()
    {
	
	}

    public IEnumerator SpawnBee()
    {
        while (true)
        {
            if (numBees < 10 && pollenCount >= 5.0f)
            {
                Instantiate(beePrefab);
                pollenCount -= 5.0f;
            }

            yield return new WaitForSeconds(2.0f);
        }
    }
}
