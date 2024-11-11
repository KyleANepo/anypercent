using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeMainMenu : MonoBehaviour
{
    private bool start;
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject panel3;
    [SerializeField] AudioClip boom;

    private float timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
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
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                // Debug.Log("No next found!");
            }
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
