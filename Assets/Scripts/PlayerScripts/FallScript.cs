using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    public GameObject GameOverImg;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().health = 0;
            Time.timeScale = 0;
            GameOverImg.SetActive(true);
        }
    }
}
