using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBox : MonoBehaviour
{
    public string fruit;
    //public string platform;
    public GameObject p;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(fruit))
        {
            p.GetComponent<PlatformMove>().ChangeBool(true);
            gameObject.SetActive(false);
        }
    }
}
