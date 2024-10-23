using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask playerLayer;

    private float endingTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsExit() && !GameManager.Instance.End)
        {
            GameManager.Instance.End = true;
            GameManager.Instance.OnEnd();
        }

        if (GameManager.Instance.End)
        {
            endingTimer -= Time.deltaTime;
        }

        if (endingTimer < 0)
        {
            NextLevel();
        }
    }

    bool IsExit()
    {
        return Physics2D.OverlapCircle(playerCheck.position, 1f, playerLayer);
    }

    public void NextLevel()
    {
        GameManager.Instance.End = false;
        GameManager.Instance.ResetAll();
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
