using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public GameObject planetPrefab;
	public GameObject homeWorld;
	public int numberOfPlanets;
	public GameObject planetContainer;

	public void GenerateWorld() {
		GenerateSystem(homeWorld.transform.position, 45.0f, 60.0f);
	}

	public void GenerateSystem(Vector3 basePosition, float minDist, float maxDist) {
		float lastDistance = 0.0f;

		for (int i = 0; i < numberOfPlanets; ++i) {
			GameObject new_planet = Instantiate(planetPrefab, planetContainer.transform);
			new_planet.transform.parent = planetContainer.transform;

            float randScaleFactor = Random.Range(10.0f, 40.0f);

            new_planet.transform.localScale *= randScaleFactor;
			new_planet.transform.position = RandomPositionAtDistance(minDist + lastDistance, maxDist + lastDistance);
			lastDistance = Vector3.Distance(new_planet.transform.position, basePosition);
		}

	}

	public Vector3 RandomPositionAtDistance(float minDist, float maxDist) {
		float distance = Random.Range(minDist, maxDist);
		float angle = Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad;
		return new Vector3(distance * Mathf.Cos(angle), 0.0f, distance * Mathf.Sin(angle));
	}
}
