using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool start;
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject panel3;
    [SerializeField] AudioClip boom;
    [SerializeField] AudioClip title;

    private float timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // SFXManager.Instance.PlaySoundFXClip(title, transform, 1f);
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void StartGame()
    {
        Debug.Log("HELLO?");
        if (!start)
        {
            start = true;
            SFXManager.Instance.PlaySoundFXClip(boom, transform, 1f);
            panel2.SetActive(true);
            panel3.SetActive(true);
        }
    }
}
