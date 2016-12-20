using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class FollowStrafe : MonoBehaviour
{

    public int speed;
    public int startTime;
    public int endTime;
    public GameObject player;
    public float timeLeft = 5.0f;
    System.Random rdn;

    // Use this for initialization
    void Start()
    {
        rdn = new System.Random();

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
            transform.Translate(localPosition.x * Time.deltaTime * speed / 5, localPosition.y * Time.deltaTime * speed / 5, localPosition.z * Time.deltaTime * speed / 5);
        }
        else if (timeLeft <= endTime && timeLeft > startTime)
        {
            Vector3 localPosition = player.transform.position - transform.position * -15;
            localPosition = localPosition.normalized; // The normalized direction in LOCAL space
            transform.Translate(localPosition.x * Time.deltaTime * speed / 5, localPosition.y * Time.deltaTime * speed / 5, localPosition.z * Time.deltaTime * speed / 5);
        }
        if (timeLeft <= 1)
        {
            timeLeft = rdn.Next(0, 10);
        }
    }
}
