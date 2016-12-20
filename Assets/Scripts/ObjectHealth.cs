using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjectHealth : MonoBehaviour
{

    public float max_health = 100f;
    public float cur_health = 0f;
    public GameObject healthbar;
    public string scene;

    // Use this for initialization
    void Start()
    {
        cur_health = max_health;
        InvokeRepeating("lowerHealthPerSecond", 2.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Tutorial:     SWORD DAMAGES OBJECT
        //Instead of putting: If Health = 0 in Update, Make a Check function that "Checks" Whenever follower
        //is touching sword and if health = 0, wait a second then: Destroy(gameObject, 1);
        //Destroy(gameObject, 10);
        if (cur_health <= 0 && scene == "FighterCompletionScreen")
        {
            victory(scene);
            Destroy(gameObject);
        }
        else if (cur_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void lowerHealthPerSecond()
    {
        cur_health -= 10;
        float calc_health = cur_health / max_health; //Decreased size of heal bar. Ex: 70 / 100 = .7f
        setHealthbar(calc_health);
    }

    //Lower Health
    void decreaseHealth(float amount)
    {
        cur_health -= amount;
        float calc_health = cur_health / max_health; //Decreased size of heal bar. Ex: 70 / 100 = .7f
        setHealthbar(calc_health);
        //GameObject.Find("OVRPlayerController").GetComponent<PlayerHealth>().player_health -= 10f; //GLobal Variable
    }

    public void setHealthbar(float myHealth)
    {
        //myHealth must be a value 0-1 (B/c Scale of object is between 0 and 1)
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }

    void victory(string _scene)
    {
    print("Victory!!!");
    SceneManager.LoadScene(_scene);
    }  
}