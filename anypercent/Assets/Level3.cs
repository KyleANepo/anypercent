using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SFXManager.Instance.PlayMusic(2);
        GameManager.Instance.SetText("Mask Labs");
    }
}
