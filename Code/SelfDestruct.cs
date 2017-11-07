using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float time = 1.0f;

	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			Destroy(gameObject);
		}

	}
}
