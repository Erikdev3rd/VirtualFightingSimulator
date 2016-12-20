using UnityEngine;
using System.Collections;

public class BillboardScript : MonoBehaviour {

    Camera my_camera;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        my_camera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.back,
            my_camera.transform.rotation * Vector3.down);
	}
}
