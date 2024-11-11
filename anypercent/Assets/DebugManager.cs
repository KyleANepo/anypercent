using System.Collections;
using System.Collections.Generic;
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

        switch (index)
        {
            case 0: // break barrier

                break;
            case 1: // increase speed
                speed = 8f;
                break;

        }
    }
}
