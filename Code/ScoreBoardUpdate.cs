using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

struct User{
	public string name;
	public int score;
};

public class ScoreBoardUpdate : MonoBehaviour {

	User[] users = new User[8];
	void Start()
	{

	}
	
	public Text score1,player1,score2,player2,score3,player3,score4,player4;
	void Update () {
	
		for (int j=0; j<8; j++) {
			users[j].name = "";
			users[j].score = 0;
		}
		int i = 0;
		foreach (PhotonPlayer player in PhotonNetwork.playerList)
		{
			users[i].name=player.name;
			users[i].score=player.GetScore();
			//Debug.Log (users[i].score);
			i++;
		}
		/*Debug.Log (player1.text);
		Debug.Log (score1.text);
		if (player1.text != "Player1" && score1.text!="Score1") {
			users [4].score = Convert.ToInt16(score1.text);
			users [4].name = player1.text;
		}
		Debug.Log (player2.text);
		Debug.Log (score2.text);
		if (player2.text != "Player2" && score2.text!="Score2") {
			users [5].name = player2.text;
			users [5].score = Convert.ToInt16(score2.text);
		}
		Debug.Log (player3.text);
		Debug.Log (score3.text);
		if (player3.text != "Player3" && score3.text!="Score3") {
			users [6].name = player3.text;
			users [6].score = Convert.ToInt16(score3.text);
		}
		Debug.Log (player4.text);
		Debug.Log (score4.text);
		if (player4.text != "Player4" && score4.text!="Score4") {
			users [7].name = player4.text;
			users [7].score = Convert.ToInt16(score4.text);
		}
*/
		Array.Sort(users, delegate(User user1, User user2) {
			return user1.score.CompareTo(user2.score); 
		});

		Array.Reverse (users);


		player1.text = users [0].name;
		player2.text = users [1].name;
		player3.text = users [2].name;
		player4.text = users [3].name;

		score1.text = Convert.ToString (users [0].score);
		score2.text = Convert.ToString (users [1].score);
		score3.text = Convert.ToString (users [2].score);
		score4.text = Convert.ToString (users [3].score);




	/*	player1.text = users [0].name;
		score1.text = Convert.ToString (users [0].score);




		if (player1.text != users [1].name) {

			score2.text = Convert.ToString (users [1].score);
			player2.text = users [1].name;
		}

		if (users [2].name != player1.text && users [3].name != player2.text) {
			score3.text = Convert.ToString (users [2].score);
			player3.text = users [2].name;
		}

		if (users [3].name != player1.text && users [3].name != player2.text && users [3].name != player3.text) {
			score4.text = Convert.ToString (users [3].score);
			player4.text = users [3].name;
		}
*/

	}
}
