using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> groups;
    [SerializeField] private float min;
    [SerializeField] private float max;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        if (timer <= 0f)
        {
            Debug.Log("Group spawned!");
            timer = GetRandTime();
            SpawnGroup();
        }
    }

    private void SpawnGroup()
    {
        Instantiate(GetRandGroup(), transform.position, transform.rotation);
    }

    public GameObject GetRandGroup()
    {
        return groups[Random.Range(0, groups.Count)];
    }

    public float GetRandTime()
    {
        return Random.Range(min, max);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().GetComponent<Hunter>())
        {
            Debug.Log("Spawner destroyed!");
            Destroy(gameObject);
        }
    }
}
