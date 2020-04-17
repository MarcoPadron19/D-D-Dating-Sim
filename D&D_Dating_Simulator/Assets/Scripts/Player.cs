using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxLoveMeter = 10;
    public int currentLove;

    public LoveMeter loveMeter;

    void Start()
    {
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
    }

    public void LoveMeterDecrease()
    {
        currentLove -= 1;

        loveMeter.SetLoveMeter(currentLove);
    }

    public void LoveMeterNull()
    {
        currentLove += 0;

        loveMeter.SetLoveMeter(currentLove);
    }
}
