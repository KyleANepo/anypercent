using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalbosstransition : MonoBehaviour
{
    public void NextLevel()
    {
        GameManager.Instance.UIOff();
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
