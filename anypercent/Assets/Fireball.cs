using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float max;
    private float min;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = transform.position;
        max = pos.y + max;
        min = pos.y;

        Debug.Log(max);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (pos.y >= max || pos.y < min)
            speed = -speed;

        pos.y += speed;
        transform.position = pos;
    }
}
