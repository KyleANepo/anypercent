using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.childCount == 0)
             Destroy(gameObject);
    }
}
