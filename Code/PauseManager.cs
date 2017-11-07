using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

	public GameObject Scoreborad;
	public GameObject HUDmenu;
	public GameObject MainMenu;
	public GameObject Panel;

	int cnt=0;
	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(cnt==0)
			{
				MainMenu.SetActive(!MainMenu.GetActive());
				Panel.SetActive(!Panel.GetActive());
				HUDmenu.SetActive(!HUDmenu.GetActive());
				Scoreborad.SetActive(!Scoreborad.GetActive());
				cnt=1;
			}
			else
			{
				Scoreborad.SetActive(!Scoreborad.GetActive());
				Panel.SetActive(!Panel.GetActive());
				MainMenu.SetActive(!MainMenu.GetActive());
				HUDmenu.SetActive(!HUDmenu.GetActive());
				cnt=0;
			}
		}
	}

	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void Quit()
	{
#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
#else 
		Application.Quit();
#endif
	}
}
