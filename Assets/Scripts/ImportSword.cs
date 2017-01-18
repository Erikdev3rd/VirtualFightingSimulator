using UnityEngine;
using System.Collections;

public class ImportSword : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	} //Load Sword!

    void spawnSword(int _x, int _z, int _sword)
    {
            GameObject Clone = Instantiate(Resources.Load("Prefabs/Edged_Sword") as GameObject;
            Clone.name = "Sword";
    }
}
