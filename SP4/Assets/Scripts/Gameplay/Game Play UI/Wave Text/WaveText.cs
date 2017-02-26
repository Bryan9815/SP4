using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveText : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<Text> ().text = "Wave : " + WaveManager.GetWaveNumber();
	}

}
