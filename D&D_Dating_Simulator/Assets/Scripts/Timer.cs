using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 10f;

    public Text countDown;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDown.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(2);
        }
    }
}
