using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalController : MonoBehaviour {

	public static ModalController modal;

	public Text messageText;
	public Button dismiss;
	public CanvasGroup canvasGroup;

	public bool showingModal = false;

	void Awake() {
		modal = this;
	}

	public void showModal(string msg) {
		showingModal = true;
		messageText.text = msg;
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}

	public void dismissModal() {
		showingModal = false;
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}
}
