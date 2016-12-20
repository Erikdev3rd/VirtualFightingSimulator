using UnityEngine;
using System.Collections;

public class GridLocation : MonoBehaviour {

    public float gridDistance; //How far grid needs to be from Player to trigger Raycast
    public int thickness;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        /*RaycastHit hit; //Stores what is below Player
        float thickness = 5f; //<-- Desired thickness here.
        Vector3 origin = transform.position + new Vector3(0, 0.6f, -1.6f);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        if (Physics.SphereCast(origin, thickness, direction, out hit))
        {
            if (hit.collider.tag == "Environment") //If colliding with ANY object with "environment" tag
            {
                    //Destroy(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
            }
        }*/
        checkRadius(transform.position + new Vector3(0, 0.6f, -1.6f), thickness);
    }

    void checkRadius(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].tag == "Environment")
            {
                hitColliders[i].gameObject.SetActive(false);
                //Debug.Log(hitColliders[i].tag);
                Physics.IgnoreCollision(hitColliders[i].GetComponent<Collider>(), GetComponent<Collider>());
            }
            i++;
        }
    }
}