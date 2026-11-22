using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int shurikenToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Shuriken.instance.SubItem(shurikenToGive);
            AudioManager.instance.PlayAudio(AudioManager.instance.shuriken);
            Destroy(gameObject);
        }
    }
}
