using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    AudioClip music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SFXManager.Instance.PlayMusic(0);
        GameManager.Instance.SetText("Riverbend City");
    }
}
