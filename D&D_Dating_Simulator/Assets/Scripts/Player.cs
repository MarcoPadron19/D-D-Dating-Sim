using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxLoveMeter = 10;
    public int currentLove;
    public GameObject monster;


    public Material monsterMaterial;
    public Texture Meh;
    public Texture Happy;
    public Texture Neutral;
    public Texture Flattered;
    public Texture Angry;

    public LoveMeter loveMeter;

    void Start()
    {
        monsterMaterial.mainTexture = Neutral;
        currentLove = 0;
        loveMeter.setMaxLoveMeter(maxLoveMeter);
    }

    void Update()
    {
        if(currentLove <= 0)
        {
            currentLove = 0;
        }
        if(currentLove >= maxLoveMeter)
        {
            currentLove = maxLoveMeter;
        }
    }

    public void LoveMeterIncrease()
    {
        currentLove += 1;
        
        
        loveMeter.SetLoveMeter(currentLove);

        if (currentLove >= maxLoveMeter)
        {
            if(monster == GameObject.Find("Succubus"))
            {
                SceneManager.LoadScene("Succubus_Love_Interest");
            }

            if (monster == GameObject.Find("Beholder"))
            {
                SceneManager.LoadScene("Beholder_Love_Interest");
            }

            if (monster == GameObject.Find("Mindflayer"))
            {
                SceneManager.LoadScene("Mindflayer_Love_Interest");
            }
        }
        if (monster == GameObject.Find("Succubus"))
        {
            monsterMaterial.mainTexture = Happy;
        }
    }

    public void LoveMeterDecrease()
    {
        currentLove -= 1;
        if(monster == GameObject.Find("Succubus"))
        {
            monsterMaterial.mainTexture = Angry;
        }
        loveMeter.SetLoveMeter(currentLove);
    }

    public void LoveMeterNull()
    {
        currentLove += 0;

        loveMeter.SetLoveMeter(currentLove);
    }
}
