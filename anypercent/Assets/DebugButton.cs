using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    [SerializeField] int id;
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.color = Color.black;
    }

    private void FixedUpdate() // i know this is bad practice ok????
    {
        if (DebugManager.Instance.developerNotesFound[id] == true)
            textMeshPro.color = Color.white;
    }

    public void ChangePage()
    {
        if (DebugManager.Instance.developerNotesFound.Count > id && DebugManager.Instance.developerNotesFound[id] == true)
            DebugManager.Instance.ChangePage(id);
    }
}
