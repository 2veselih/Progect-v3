using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public GameObject SettingsV;
	public void tart(){
		Application.LoadLevel (1);
	}

	public void Settings(){
		SettingsV.SetActive(!SettingsV.activeSelf);
	}

	public void Authors(){
		Application.LoadLevel (2);
	}

	public void Quit(){
		Application.Quit ();
		
	}
	public void SetMusic(float Value){
		Global.MusicVol = Value;
	}
}
