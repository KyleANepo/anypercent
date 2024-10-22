using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

// Don't use, unity sucks!
public class Minigame
{
    public string Name;
    public bool Played;
}

// This should only be created in the intro class!
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public int gameCount;
    public float gameTime;
    [SerializeField] public GameObject ui;
    [SerializeField] public List<bool> minigames = new List<bool>(); // keeps track of which minigames were completed
    [SerializeField] public Image timer;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        
    }

    private void StartGame()
    {
        gameCount = 0;
        gameTime = 10f;
        int index = GetRandomGame();
        SceneManager.LoadScene(index + 3);
    }



    // Only return the index of games not completed yet
    private int GetRandomGame()
    {
        int index = Random.Range(0, minigames.Count);
        while (minigames[index])
            index = Random.Range(0, minigames.Count);
        minigames[index] = true;
        return index;
    }
}
