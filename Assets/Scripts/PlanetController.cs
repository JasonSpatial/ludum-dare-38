using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetController : MonoBehaviour {


	public int population;
	public string identifier = "My planet, foo";

	private Vector3 myScale;

	void Start() {
		myScale = transform.localScale;
	}

	void OnMouseDown() {
		if(!GameManager.planetFrom){
			GameManager.planetFrom = gameObject;
			transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, transform.localScale.z * 1.25f);
		} else {
			GameManager.planetTo = gameObject;
			GameManager.TransferPopulation();
		}

		UIController.ui.UpdateSelectedPlanetInfo(this);
	}

	public void receivePopulation(int populationToAdd){
		population = population + populationToAdd;
	}

	public void distributePopulation(int populationToDistribute){
		population = population - populationToDistribute;
		transform.localScale = myScale;
	}
}
