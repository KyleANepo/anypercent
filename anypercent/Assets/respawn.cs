using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    public void Respawn()
    {
        GameManager.Instance.ResetAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
