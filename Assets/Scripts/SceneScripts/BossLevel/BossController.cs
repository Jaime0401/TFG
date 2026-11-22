using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;

    public float timeToShoot, countdown;
    public float timeToTP, countdownToTP;

    public float BossHealth, currentHealth;
    public Image HealthImg;

    private void Start()
    {
        transform.position = transforms[3].position;
        countdown = timeToShoot;
        countdownToTP = timeToTP;
    }

    private void Update()
    {
        Countdowns();
        DamageBoss();
        BossScale();
    }

    public void Countdowns()
    {
        countdown -= Time.deltaTime;
        countdownToTP -= Time.deltaTime;
        if (countdown < 0f)
        {
            ShootToPlayer();
            countdown = timeToShoot;
        }

        if (countdownToTP <= 0)
        {
            countdownToTP = timeToTP;
            Teleport();
        }
    }
    public void ShootToPlayer()
    {
        GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
    }
    
    public void Teleport()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }

    public void DamageBoss()
    {
        currentHealth = GetComponent<Enemy>().healthPoints;
        HealthImg.fillAmount = currentHealth / BossHealth;
    }

    private void OnDestroy()
    {
        BossUI.instance.BossDeactivator();
        AudioManager.instance.StopAudio(AudioManager.instance.bossMusic);
        AudioManager.instance.PlayAudio(AudioManager.instance.BGMusic);
    }

    public void BossScale()
    {
        if(transform.position.x > PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
