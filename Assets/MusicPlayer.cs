using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance = null;

	void Awake() {
		if(instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Start() {

	}
}
