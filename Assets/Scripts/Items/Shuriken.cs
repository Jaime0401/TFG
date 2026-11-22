using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shuriken : MonoBehaviour
{
    public Text shurikenText;
    public int shurikenAmount;

    public static Shuriken instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        shurikenText.text = "X " + shurikenAmount.ToString();
    }

    public void SubItem(int subItemAmount)
    {
        shurikenAmount += subItemAmount;
        shurikenText.text = "X " + shurikenAmount.ToString();
    }
}
