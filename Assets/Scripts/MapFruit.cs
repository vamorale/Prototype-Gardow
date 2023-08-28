using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFruit : MonoBehaviour
{
    public GameObject jugador;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugador.GetComponent<PlayerMove>().SumarFruta();
            Destroy(gameObject);
        }
    }
}
