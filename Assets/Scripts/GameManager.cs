using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public LevelController levelController;
	public ModalController modalController;

	public Text homePopulation;
	public Text stardate;
	public Text populationLabel;
	public Text identificationLabel;

	private int timer;
	private int populationCount;

	private bool growthHintShown = false;

	public static GameObject planetFrom;
	public static GameObject planetTo;

	void Start () {
		levelController.GenerateWorld();
		modalController.showModal("Your world, sire.");
	}
	
	void Update () {
		// pause time when showing a modal
		if(!modalController.showingModal){
			stardate.text = "Stardate: " + getStardate();
			homePopulation.text = "Home Population: " + getHomePopulation();
		}

		if(populationCount > 50000000){
			if(!growthHintShown){
				modalController.showModal("It's time to move some of your peeps, sire.");
			}
			growthHintShown = true;
		}
	}

	// public void PlanetClicked(GameObject planet) {
	// 	if(!planetFrom){
	// 		planetFrom = planet;
	// 	} else {
	// 		planetTo = planet;
	// 		TransferPopulation();
	// 	}
	// 	print("population: " + planet.GetComponent<PlanetController>().population.ToString());
	// 	print("identifier: " + planet.GetComponent<PlanetController>().identifier.ToString());

	// 	populationLabel.text = "Population: " + planet.GetComponent<PlanetController>().population.ToString();
	// 	identificationLabel.text = "Planet Identification" + planet.GetComponent<PlanetController>().identifier.ToString();
	// }

	public static void TransferPopulation() {
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

	int getHomePopulation() {
		return populationCount = populationCount + Random.Range(100000,250000);
	}
}
