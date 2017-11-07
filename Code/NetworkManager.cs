using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject{

public class NetworkManager : MonoBehaviour {
	
		public GameObject Mainmenu;
		//public GameObject HUDmenu;
		public Text username;
		public Text score;
		public static int scoreVal=0;
		public Text health;
		SpawnSpot[] spawnSpots;
		int cnt=0;
		int cnt2=0;
		//public InputField inputField; 
		string user;
	//public GameObject endcam;
		public GameObject Maincamera;           
		// The position that that camera will be following.
		public float smoothing = 5f;
		Vector3 offSet;
		GameObject myPlayerGO=null;
		bool connecting=false;
		//public GameObject HUDCanvas;
	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		offSet = Maincamera.transform.position;
		}

	void connect(){
		PhotonNetwork.ConnectUsingSettings ("v1.0");
		}
	public void setUserName(string inputString)
		{
			user = inputString;
		}
	public void singlePlayerMode()
		{
			PhotonNetwork.offlineMode=true;
			OnJoinedLobby();
		}
	public void MultiPlayerMode()
		{
			connect ();
		}

	void OnJoinedLobby(){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
		}
	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
		}
	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer ();
		}
	
	void SpawnMyPlayer(){
			Debug.Log ("Spawning My Player");
			SpawnSpot mySpawnSpot = spawnSpots [Random.Range (0, spawnSpots.Length)];
			//SpawnSpot mySpawnSpot = spawnSpots [PhotonNetwork.countOfPlayersInRooms ()];
			myPlayerGO = PhotonNetwork.Instantiate ("Player_Final_F", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
			myPlayerGO.GetComponent<PlayerHealth> ().enabled = true;
			myPlayerGO.GetComponent<PlayerMovement> ().enabled = true;
			myPlayerGO.transform.FindChild ("GunBarrelEnd").GetComponent<PlayerShooting> ().enabled = true;

		}
	void FixedUpdate()
		{
			if (cnt2 == 0 && myPlayerGO!=null) {
				username.text=user;
				PhotonNetwork.player.name=user;
				cnt2++;
			}
			if (cnt > 5 && myPlayerGO!=null) {

				score.text=scoreVal.ToString();
				health.text=myPlayerGO.GetComponent<PlayerHealth> ().currentHealth.ToString();
				Vector3 targetCamPos = myPlayerGO.transform.position + offSet;
				//Quaternion rotationCamPos = Quaternion.Euler (30, -304, 0);
				// Smoothly interpolate between the camera's current position and it's target position.
				Maincamera.transform.position = Vector3.Lerp (Maincamera.transform.position, targetCamPos, smoothing * Time.deltaTime);
				//Maincamera.transform.rotation = Quaternion.Lerp (Maincamera.transform.rotation, rotationCamPos, smoothing * Time.deltaTime);
			}
			cnt++;
		}
}
}
