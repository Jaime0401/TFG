using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public Image expImage;
    public float currentExp;
    public float expTNL;
    public int currentLvl;
    public Text lvlText;

    public static PlayerExp instance;

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
        currentLvl = 1;
        lvlText.text = currentLvl.ToString();
        expImage.fillAmount = currentExp / expTNL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void expModifier(float exp)
    {
        currentExp += exp;
        expImage.fillAmount = currentExp / expTNL;

        if (currentExp >= expTNL)
        {
            expTNL = expTNL * 2;
            currentExp = 0;
            PlayerController.instance.damage += 1;
            currentLvl++;
            lvlText.text = currentLvl.ToString();
        }
    }
}
