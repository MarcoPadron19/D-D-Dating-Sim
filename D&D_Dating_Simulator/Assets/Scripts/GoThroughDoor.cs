using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoThroughDoor : MonoBehaviour
{
    public GameObject popUpBox;
    public float minDist = 1f;
    public Transform target; // The location of the player
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDist)
        {
            popUpBox.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneName);
                //FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            }
        }
        else
        {
            popUpBox.SetActive(false);
        }
    }
}
