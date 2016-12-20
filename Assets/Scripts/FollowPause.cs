using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class FollowPause : MonoBehaviour {

    public int speed;// = UnityEngine.Random.Range(3, 10);
    public int startTime;// = UnityEngine.Random.Range(1, 8);
    public int endTime;// = UnityEngine.Random.Range(9, 15);
    public GameObject player;
    public float timeLeft;// = 5.0f;
    //System.Random random = new System.Random();
    System.Random rdn;

    // Use this for initialization
    void Start()
    {
        rdn = new System.Random();
        /*speed = rdn.Next(3, 10);
        startTime = rdn.Next(1, 8);
        endTime = rdn.Next(9, 12);*/
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("OVRPlayerController");
        timeLeft -= Time.deltaTime;
        //Debug.Log(Mathf.Round(timeLeft));
        if (timeLeft <= startTime)
        {
            Vector3 localPosition = player.transform.position - transform.position;
            localPosition = localPosition.normalized; // The normalized direction in LOCAL space
            transform.Translate(localPosition.x * Time.deltaTime * speed/5, localPosition.y * Time.deltaTime * speed/5, localPosition.z * Time.deltaTime * speed/5);
        }
        else if (timeLeft <= endTime && timeLeft > startTime)
        {

        }
        if(timeLeft <= 1)
        {
            timeLeft = rdn.Next(0, 10);
        }
    }
}