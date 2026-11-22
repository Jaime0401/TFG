using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject Walls;

    public static BossUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bossPanel.SetActive(false);
        Walls.SetActive(false);
    }

    public void BossActivator()
    {
        bossPanel.SetActive(true);
        Walls.SetActive(true);
    }
    public void BossDeactivator()
    {
        bossPanel.SetActive(false);
        Walls.SetActive(false);
    }
}
