using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController ui;

	public Text populationLabel;
	public Text planetIdentifier;

	void Awake() {
		ui = this;
	}

	public void UpdateSelectedPlanetInfo(PlanetController planet) {
		populationLabel.text = "Population: " + planet.population.ToString();
		planetIdentifier.text = "Planet Identification: " + planet.identifier.ToString();
	}
}
