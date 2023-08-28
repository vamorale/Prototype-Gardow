using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Score;
    private int scoreId;
    public Text ScoreFruit;
    public GameObject c1;
    public GameObject c2;
    void Update()
    {
        scoreId = Score.GetComponent<PlayerMove>().recuentofinal;
        ScoreFruit.text = scoreId.ToString();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //SceneManager.LoadScene("GameOver");
            Time.timeScale = 0;
            c1.SetActive(false);
            c2.SetActive(true);
            
        }

    }

}
