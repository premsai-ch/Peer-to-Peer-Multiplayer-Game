using UnityEngine;
using System.Collections;

public class NetworkMovement : Photon.MonoBehaviour {

	Vector3 realPosition=Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (photonView.isMine) {
			//Do nothing we don't need to change our positions 
			// they are updating in our scene
		}
		else {

			transform.position=Vector3.Lerp(transform.position,realPosition,0.2f);
			transform.rotation=Quaternion.Lerp (transform.rotation,realRotation,0.2f);
		}
	
	}
	void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
	{
		if (stream.isWriting) {

			// Sending our updates to all other users

			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
			stream.SendNext(anim.GetBool("IsWalking"));
		}
		else {
			// Recieving updates from other users to update their positions
			realPosition=(Vector3)stream.ReceiveNext();
			realRotation=(Quaternion)stream.ReceiveNext();
			anim.SetBool("IsWalking",(bool)stream.ReceiveNext());


		}

	}



}
