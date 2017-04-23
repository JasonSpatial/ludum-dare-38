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
	
	public int homeStartingPopulation = 0;
	public long homeTargetPopulation = 12000000000;
	public long moveHintPopulation = 5000000000;

	private int timer;
	private int populationCount;

	private bool growthHintShown = false;

	public static GameObject planetFrom;
	public static GameObject planetTo;

	void Start () {
		levelController.GenerateWorld();
		modalController.showModal("Your world, sire.");

		InvokeRepeating("UpdateWorld", 0.01f, 1.0f);

	}

	void UpdateWorld() {
		// pause time when showing a modal
		if(!modalController.showingModal){
			stardate.text = "Stardate: " + getStardate();
			homePopulation.text = "Home Population: " + getHomePopulation();
		}

		if(populationCount > moveHintPopulation){
			if(!growthHintShown){
				modalController.showModal("It's time to move some of your peeps, sire.");
			}
			growthHintShown = true;
		}
	}

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
