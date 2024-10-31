using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SFXManager.Instance.PlayMusic(1);
        GameManager.Instance.SetText("Hector Mansion");
    }
}
