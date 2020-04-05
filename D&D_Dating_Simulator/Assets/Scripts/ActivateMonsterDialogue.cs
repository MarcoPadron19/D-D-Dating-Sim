using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMonsterDialogue : MonoBehaviour
{
    public GameObject popUpBox;
    public float minDist = 1f;
    public Transform target; // The location of the player

    // Update is called once per frame
    void Update()
    {
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDist)
        {
            popUpBox.SetActive(true);
     
            if (Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            }
        }
        else
        {
            popUpBox.SetActive(false);
        }
    }
}
