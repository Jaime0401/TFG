using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCompleteScript : MonoBehaviour
{
    public GameObject LvlCompleteImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LvlCompleteImg.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
