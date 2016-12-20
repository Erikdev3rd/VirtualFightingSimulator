using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public float damage = 20f;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.Find("OVRPlayerController").GetComponent<PlayerHealth>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "OVRPlayerController")
        {
            playerHealth.decreaseHealth(damage);
        }
    }
}
