using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject Boss;

    private void Start()
    {
        Boss.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivator();
            AudioManager.instance.StopAudio(AudioManager.instance.BGMusic);
            AudioManager.instance.PlayAudio(AudioManager.instance.bossMusic);
            StartCoroutine(WaitForBoss());
        }
    }

    IEnumerator WaitForBoss()
    {
        var currentSpeed = PlayerController.instance.speed;
        PlayerController.instance.speed = 0;
        Boss.SetActive(true);
        yield return new WaitForSeconds(1f);
        PlayerController.instance.speed = currentSpeed;
        Destroy(gameObject);
    }
}
