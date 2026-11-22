using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;
    Blink material;
    SpriteRenderer sprite;
    public Image healthImg;

    public GameObject GameOverImg;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthImg.fillAmount = health / 100;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            AudioManager.instance.PlayAudio(AudioManager.instance.hitPlayer);
            StartCoroutine(Inmunity());
            if (health <= 0)
            {
                Time.timeScale = 0;
                GameOverImg.SetActive(true);
            }
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }

}
