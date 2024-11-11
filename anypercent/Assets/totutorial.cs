using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class totutorial : MonoBehaviour
{
    [SerializeField] private AudioClip AudioClip;

    public void PlaySound()
    {
        SFXManager.Instance.PlaySoundFXClip(AudioClip, transform, 1f);
    }

    public void FadeOut()
    {
        GameManager.Instance.OnEnd();
    }

    public void NextLevel()
    {
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
