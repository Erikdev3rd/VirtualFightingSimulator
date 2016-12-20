using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float max_health = 100f;
    public float player_health = 0f;
    public GameObject healthbar;
    public string gameMode;
    private float calc_health;

    // Use this for initialization
    void Start () {
        player_health = max_health;
    }
	
	// Update is called once per frame
	void Update () {
    }

    //Lower Health
    public void decreaseHealth(float amount)
    {
        player_health -= amount;
        calc_health = player_health / max_health; //Decreased size of heal bar. Ex: 70 / 100 = .7f
        setHealthbar(calc_health);
        if(player_health <= 0)
        {
            gameOver(gameMode);
        }
        //Destroy(gameObject, 3);
    }

    void gameOver(string _gameMode)
    {
        print("Game Over!!!");
        SceneManager.LoadScene(_gameMode);
    }

    public void setHealthbar(float myHealth)
    {
        //myHealth must be a value 0-1 (B/c Scale of object is between 0 and 1)
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }
}
