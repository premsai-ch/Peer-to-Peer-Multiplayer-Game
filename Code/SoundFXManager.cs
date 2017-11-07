using UnityEngine;
using System.Collections;

public class SoundFXManager : MonoBehaviour {


	public GameObject GunSoundFXPrefab;
	float timer;
	float CoolDownTime;
	float effectsTime;
	LineRenderer gunLine;
	AudioSource gunAudio;
	Light gunLight;
	ParticleSystem gunParticles;
	GameObject GunSoundFxObj;
	[RPC]
	void GunSoundFX (Vector3 StartPos, Vector3 EndPos, float effectsTime,float CoolDownTime,float timer ) {

		GunSoundFxObj = (GameObject)Instantiate (GunSoundFXPrefab, StartPos, Quaternion.LookRotation (EndPos-StartPos));


		if (GunSoundFxObj != null) {


			gunLine = GunSoundFxObj.GetComponent<LineRenderer> ();
			gunAudio = GunSoundFxObj.GetComponent<AudioSource> ();                           // Reference to the audio source.
			gunLight = GunSoundFxObj.GetComponent<Light> ();
			gunParticles = GunSoundFxObj.GetComponent<ParticleSystem> ();

			gunAudio.Play ();
		
			// Enable the light.
			gunLight.enabled = true;
		
			// Stop the particles from playing if they were, then start the particles.
			gunParticles.Stop ();
			gunParticles.Play ();
		
			// Enable the line renderer and set it's first position to be the end of the gun.
			gunLine.enabled = true;
			gunLine.SetPosition (0, StartPos);
			gunLine.SetPosition (1, EndPos);
		}

	
	}

	void Update(){
		if(timer >= CoolDownTime * effectsTime)
		{
			if (GunSoundFxObj != null) {
				gunLine.enabled = false;
				gunLight.enabled = false;
			}
		}

	}


}
