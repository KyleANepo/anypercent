using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour, IMinigame
{
    [SerializeField] private GameObject moon;

    public List<Transform> grid;
    private int curPosition;

    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            curPosition -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            curPosition += 1;
        }

    }

    public void StartGame()
    {
        curPosition = 4;
        moon.transform.position = grid[curPosition].position;
    }

    public void Win()
    {

    }

    public void Lose()
    { 

    }
}