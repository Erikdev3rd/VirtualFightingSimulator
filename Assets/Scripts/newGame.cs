using UnityEngine;
using System.Collections;

public class newGame : MonoBehaviour {

    public bool startNewHordeGame;
    public bool startNewFighterGame;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
