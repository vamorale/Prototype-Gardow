using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProyectileBehaviour : MonoBehaviour
{
    public float Speed = 2;
    public bool Thrown;
    public Vector3 LaunchOffset;
    private GameObject player;
    float timeLeft = 3f;
    private void Start()
    {
        if (Thrown)
        {
            var direction = -transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
        }
        transform.Translate(LaunchOffset);
    }

    private void Update()
    {
        timeLeft-=Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft=3f;
            Teleport();
        }
    }
    private void Teleport()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().SumarFruta();
        //Debug.Log("Hola"+timeLeft.ToString());
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Destroy(gameObject);
        }
    }
}
