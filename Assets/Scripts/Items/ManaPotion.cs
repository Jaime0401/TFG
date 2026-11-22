using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public float manaToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().mana += manaToGive;
            AudioManager.instance.PlayAudio(AudioManager.instance.potion);
            Destroy(gameObject);
        }
    }
}
