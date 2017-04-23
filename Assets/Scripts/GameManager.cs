using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public LevelController levelController;
	public ModalController modalController;
	public LevelManager levelManager;

	public Text homePopulation;
	public Text stardate;
	public Text populationLabel;
	public Text identificationLabel;
	public Text galacticPopulationLabel;
	
	public float growthSpeed = 5.0f;
	public ulong homeStartingPopulation = 2;
	public ulong homeTargetPopulation = 12000000000;
	public ulong moveHintPopulation = 5000000000;
	public ulong closeToDeathPopulation = 10000000000;
	public ulong galacticPopulation = 0;

	private int timer;
	private ulong populationCount;

	private bool growthHintShown = false;
	private bool triggered = false;

	public static GameObject planetFrom;
	public static GameObject planetTo;
	public GameObject homePlanet;
	public GameObject planetContainer;

	void Awake() {
		if(instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
		}
	}

	void Start () {
		levelController.GenerateWorld();
		modalController.showModal("Your world, sire.");
		homePlanet.GetComponent<PlanetController>().population = homeStartingPopulation;

		InvokeRepeating("UpdateWorld", 0.01f, growthSpeed);
		MusicPlayer.instance.GetComponent<AudioSource>().pitch = 1;
	}

	void UpdateWorld() {
		// pause time when showing a modal
		if(!modalController.showingModal){
			stardate.text = "Stardate: " + getStardate();
			homePopulation.text = "Home Population: " + abbreviateNumber(getHomePopulation());
			galacticPopulationLabel.text = "Galactic Population: " + abbreviateNumber(CalculatePopulation());
		}

		if(populationCount > moveHintPopulation){
			if(!growthHintShown){
				modalController.showModal("It's time to move some of your peeps, sire.");
			}
			growthHintShown = true;
		}

		if((populationCount > closeToDeathPopulation) & !triggered) {
			triggered = true;
			// GetComponent<AudioSource>().Play();
			MusicPlayer.instance.GetComponent<AudioSource>().pitch += 0.1f;
		}

		if(populationCount > homeTargetPopulation) {
			// YOU LOSE
			levelManager.LoadLevel("Lose");
		}
	
	}

	ulong CalculatePopulation() {
		PlanetController[] planets = planetContainer.GetComponentsInChildren<PlanetController>();
		print("planets: " + planets.Length);

		galacticPopulation = 0;

		foreach (PlanetController planet in planets)
		{
			print("population: " + planet.population);
			galacticPopulation += planet.population;
		}

		return galacticPopulation;
	}

	public void TransferPopulation() {
		PlanetController fpc = planetFrom.GetComponent<PlanetController>();
		PlanetController tpc = planetTo.GetComponent<PlanetController>();
		
		fpc.distributePopulation(500000);
		tpc.receivePopulation(500000);

		planetFrom = null;
		planetTo = null;
	}

	int getStardate(){
		return timer++;
	}

	ulong getHomePopulation() {
		homePlanet.GetComponent<PlanetController>().population += (ulong)Mathf.Ceil(homePlanet.GetComponent<PlanetController>().population * 1.11f);
		populationCount = homePlanet.GetComponent<PlanetController>().population;
		return populationCount;
	}

	static string[] denominations = {
		string.Empty,
		"K",
		"M",
		"B",
		"T",
		"Q"
	};

	string abbreviateNumber(ulong num) {
		if (num < 1000) {
			return num.ToString();
		}

		int denomIndex = 0;
		float val = (float)num;

		while (val >= 1000 && denomIndex++ < denominations.Length) {
			val /= 1000;
		}

		return val.ToString("F2") + denominations[denomIndex];
	}
}
