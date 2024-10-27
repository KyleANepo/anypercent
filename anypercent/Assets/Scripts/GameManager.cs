using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This should only be created in the intro class!
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    public bool End;
    public bool Paused;

    [SerializeField] Image healthbar;
    public float health;
    [SerializeField] TextMeshProUGUI numWrenches;
    public int wrenches;

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
                paused.SetActive(false);
                Paused = false;
            } else
            {
                SFXManager.Instance.PlaySoundFXClip(pausedEffect, transform, 1f);
                Time.timeScale = 0;
                paused.SetActive(true);
                Paused = true;
            }
        }
    }

    private void FixedUpdate()
    {
        healthbar.fillAmount = health / 5f;
        numWrenches.text = "" + wrenches;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject opening;
    [SerializeField] private GameObject ending;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject dead;
    [SerializeField] private GameObject paused;
    [SerializeField] private AudioClip pausedEffect;

    public void ResetAll()
    {
        opening.SetActive(false);
        ending.SetActive(false);
        text.SetActive(false);
        dead.SetActive(false);
        paused.SetActive(false);

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

    public void UIOn()
    {
        ui.SetActive(true);
        ResetAll();
    }

    public void UIOff()
    {
        ui.SetActive(false);
    }
}
