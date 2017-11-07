using UnityEngine;
using System.Collections;

public class BotSpawn : MonoBehaviour {

	// Use this for initialization

	HellSpawnSpot[] hellspots;
	ZomBearSpawnSpot[] bearspots;
	GameObject myHellephant,myBear,myBunny;
	float spawnTime_H = 25f;
	float spawnTime_Z = 10f;
	float spawnTime_B = 14f;
	bool calledOnce=false;

	void Start () {
		hellspots = GameObject.FindObjectsOfType<HellSpawnSpot> ();
		bearspots = GameObject.FindObjectsOfType<ZomBearSpawnSpot> ();
	}
	
	// Update is called once per frame

	void SpawnHellephants()
	{
		HellSpawnSpot mySpawnSpot = hellspots [Random.Range (0, hellspots.Length)];
		myHellephant = PhotonNetwork.Instantiate ("Hellephant_F", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		//myHellephant.transform.FindChild ("AI").GetComponent<AIRig> ().enabled = true;

	}
	void SpawnBear()
	{
		ZomBearSpawnSpot mySpawnSpot2 = bearspots [Random.Range (0, bearspots.Length)];
		myBear = PhotonNetwork.Instantiate ("ZomBear_F", mySpawnSpot2.transform.position, mySpawnSpot2.transform.rotation, 0);
		//myBear.transform.FindChild ("AI").
	}
	void SpawnBunny()
	{
		ZomBearSpawnSpot mySpawnSpot3 = bearspots [Random.Range (0, bearspots.Length)];
		myBunny = PhotonNetwork.Instantiate ("ZomBunny_F", mySpawnSpot3.transform.position, mySpawnSpot3.transform.rotation, 0);
		//myBunny.transform.FindChild ("AI").GetComponent<AIRig> ().enabled = true;
	}


	void Update () {
	
		if (PhotonNetwork.isMasterClient && !calledOnce) {
			InvokeRepeating ("SpawnBear", spawnTime_Z, spawnTime_Z);
			InvokeRepeating ("SpawnBunny", spawnTime_B, spawnTime_B);
			InvokeRepeating ("SpawnHellephants", spawnTime_H, spawnTime_H);
			calledOnce=true;
		}
	}

}
