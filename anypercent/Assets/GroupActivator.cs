using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupActivator : MonoBehaviour
{
    [SerializeField] GameObject group;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (group && collision.GetComponent<Collider2D>().GetComponent<Hunter>())
        {
            Debug.Log("Group active!");
            group.SetActive(true);
        }
    }
}
