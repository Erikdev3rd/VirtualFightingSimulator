using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public int speed;
    public GameObject player;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("OVRPlayerController");
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed/5, localPosition.z * Time.deltaTime * speed/5);
    }
}
