using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField] GameObject spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spawner)
        {
            Debug.Log("Spawner active!");
            spawner.SetActive(true);
            Destroy(gameObject);
        }
    }
}
