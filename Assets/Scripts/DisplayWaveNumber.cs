using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayWaveNumber : MonoBehaviour {

    Text waveNum;

	// Updates Wave Number Text
	public void Refresh ( string _file) {
        waveNum = GetComponent<Text>();
        waveNum.text = "Wave #: " + SaveLoad.Load(_file);
    }
}
