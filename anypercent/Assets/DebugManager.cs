using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public static DebugManager _instance;

    public static DebugManager Instance { get { return _instance; } }

    // Values that will be affected by codeblocks
    public float speed;
    public float jump;
    public float boneScale;

    public List<bool> developerNotesFound;
    public List<string> developerNotes;

    public TextMeshProUGUI dialogue;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ActivateDebug(int index)
    {
        if (index > developerNotes.Count) return;

        developerNotesFound[index] = true;
    }

    public void ChangePage(int index)
    {
        dialogue.text = developerNotes[index];
    }
}
