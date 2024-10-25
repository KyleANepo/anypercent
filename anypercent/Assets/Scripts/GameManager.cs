using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public bool End;
    public bool Paused;

    [SerializeField] Image healthbar;
    public float health;

    /*
    public float gameTime;
    [SerializeField] public GameObject ui;
    [SerializeField] public List<bool> minigames = new List<bool>(); // keeps track of which minigames were completed
    [SerializeField] public Image timer;
    */

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !End)
        {
            if (Paused)
            {
                Time.timeScale = 1;
                Paused = false;
            } else
            {
                Time.timeScale = 0;
                Paused = true;
            }
        }
    }

    private void FixedUpdate()
    {
        healthbar.fillAmount = health / 5f;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    [SerializeField] private GameObject opening;
    [SerializeField] private GameObject ending;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject dead;

    public void ResetAll()
    {
        opening.SetActive(false);
        ending.SetActive(false);
        text.SetActive(false);
        dead.SetActive(false);

        opening.SetActive(true);
        text.SetActive(true);
    }

    public void OnDeath()
    {
        dead.SetActive(true);
    }

    public void OnEnd()
    {
        ending.SetActive(true);
    }

    /*
    // Only return the index of games not completed yet
    private int GetRandomGame()
    {
        int index = Random.Range(0, minigames.Count);
        while (minigames[index])
            index = Random.Range(0, minigames.Count);
        minigames[index] = true;
        return index;
    }
    */
}
