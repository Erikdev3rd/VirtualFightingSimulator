using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

    public GameObject plane;
    public int width = 20;
    public int height = 20;
    public string gameMode;
    public string filePath = @"\FWNumber.txt";
    public string newGameFile;
    public Transform spawnLocation; //Remove this if it doesn't work
    public static int waveNumber;
    newGame newGameScript;
    DisplayWaveNumber displayScript;

    private GameObject[,] grid = new GameObject[20, 20];

    void Start()
    {
        displayScript = GameObject.Find("WaveNumber").GetComponent<DisplayWaveNumber>();
        newGameScript = GameObject.Find(newGameFile).GetComponent<newGame>();

        if (newGameScript.startNewHordeGame == false)
        {
            Debug.Log("CONTINUE CALLED");
            Debug.Log(newGameScript.startNewHordeGame);
            waveNumber = SaveLoad.Load(filePath);
        }
        else
        {
            Debug.Log("NEW GAME CALLED");
            Debug.Log(newGameScript.startNewHordeGame);
            waveNumber = 1;
            SaveLoad.SaveData(1, filePath);
        }
        displayScript.Refresh(filePath);
    }

    void Update()
    {
        if(gameMode == "FollowerXXX") {
            //Called Once if no followers exist
            if (GameObject.Find("FollowerMob") == null)
            {
                Debug.Log(waveNumber);
                SaveLoad.SaveData(waveNumber, filePath);
                Main();
                waveNumber = waveNumber + 1;
                displayScript.Refresh(filePath);
                reAwake();
            }
        }
        else if (gameMode == "Turn this Line <--Bk into else")
        {
            //Called Once if no fighters exist
            if (GameObject.Find("FighterMob") == null)
            {
                displayScript.Refresh(filePath);
                SaveLoad.SaveData(waveNumber, filePath);
                spawnFighter(2 * Random.Range(2 / 2, 18 / 2), 2 * Random.Range(2 / 2, 18 / 2), 1);
                waveNumber = waveNumber + 1;
                reAwake();
            }
        }
    }

    void spawnFighter(int _x, int _z, int _fScript)
    {
        do
        {
            //Keep Trying to Spawn Fighter Until...
            GameObject Clone = Instantiate(Resources.Load("Prefabs/Fighter", typeof(GameObject)), grid[_x, _z].transform.position, Quaternion.identity) as GameObject;
            Clone.name = "FighterMob";
            Clone.AddComponent<Follow>();
            Clone.GetComponent<Follow>().speed = 1;
            //Stop Spawning When:
        } while (grid[_x, _z].activeSelf != false && GameObject.Find("FighterMob") == null);
    }

    void Main()
    {
        float n = 1f + (waveNumber - 1f) * 1.2f;

        //Spawn n number of enemies based on current wave
        for (int i = 0; i < n; i++)
        {
            spawnSomething(2 * Random.Range(2 / 2, 18 / 2), 2 * Random.Range(2 / 2, 18 / 2), Random.Range(3, 10), Random.Range(1, 8), Random.Range(9, 15), Random.Range(0, 10), Random.Range(1, 3));
        }
    }

    void Awake()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GameObject gridPlane = (GameObject)Instantiate(plane);
                gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + x,
                    gridPlane.transform.position.y, gridPlane.transform.position.z + z);
                grid[x, z] = gridPlane;
            }
        }
    }

    void reAwake()
    {
        for (var i = 0; i < grid.Length; i++)
        {
            for (var n = 0; n < 20; n++)
            {
                //Destroy(grid[i, n]);
                grid[i, n].SetActive(true);
            }
        }
    }

    void spawnSomething(int _x, int _z, int _speed, int _startTime, int _endTime, int _movement, int _mScript)
    {
        if (grid[_x, _z].activeSelf == true)
        {
            GameObject Clone = Instantiate(Resources.Load("Prefabs/Follower", typeof(GameObject)), grid[_x, _z].transform.position, Quaternion.identity) as GameObject;
            Clone.name = "FollowerMob";
            if(_mScript == 1)
            {
                Clone.AddComponent<Follow>();
                Clone.GetComponent<Follow>().speed = _speed/4;
            }
            else if(_mScript == 2)
            {
                Clone.AddComponent<FollowStrafe>();
                Clone.GetComponent<FollowStrafe>().speed = _speed;
                Clone.GetComponent<FollowStrafe>().startTime = _startTime;
                Clone.GetComponent<FollowStrafe>().endTime = _endTime;
                Clone.GetComponent<FollowStrafe>().timeLeft = _movement;
            }
            else
            {
                Clone.AddComponent<FollowPause>();
                Clone.GetComponent<FollowPause>().speed = _speed;
                Clone.GetComponent<FollowPause>().startTime = _startTime;
                Clone.GetComponent<FollowPause>().endTime = _endTime;
                Clone.GetComponent<FollowPause>().timeLeft = _movement;
            }
        }
    }

    /*public IEnumerator DoTheDance()
    {
        //Putting something [Right] Here is called before waiting seconds
        while (true)
        {
            Awake();
            yield return null; //wait for a frame
            yield return new WaitForSeconds(2f);
        }
    }*/
}
