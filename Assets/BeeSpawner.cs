using UnityEngine;
using System.Collections;

public class BeeSpawner : MonoBehaviour
{
    public GameObject beePrefab;

    private int numBees = 0;
    public float pollenCount = 10.0f;

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
                GameObject bee = Instantiate(beePrefab);
                bee.transform.parent = transform;
                bee.GetComponent<StateMachine>().SwitchState(new ExploreState(bee));

                pollenCount -= 5.0f;
            }

            yield return new WaitForSeconds(2.0f);
        }
    }
}
