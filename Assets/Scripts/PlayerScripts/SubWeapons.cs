using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{
    public int shurikenCost;
    public GameObject shurikenT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    {
        if(Input.GetButtonDown("Fire2") && shurikenCost <= Shuriken.instance.shurikenAmount)
        {
            Shuriken.instance.SubItem(-shurikenCost);
            AudioManager.instance.PlayAudio(AudioManager.instance.shot);
            GameObject subItem = Instantiate(shurikenT, transform.position, Quaternion.identity);

            if(transform.localScale.x < 0)
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f, 0f), ForceMode2D.Force);
            }
            else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 0f), ForceMode2D.Force);
            }
            Destroy(subItem, 1f);
        }
    }
}
