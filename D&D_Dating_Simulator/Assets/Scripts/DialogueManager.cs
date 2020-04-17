using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI response1Text;
    public TextMeshProUGUI response2Text;
    public TextMeshProUGUI response3Text;

    public GameObject responseBox;

    public GameObject loveMeter;

    public Animator dialogueBox;

    private float continuePlayerMovement;
    private float continueCameraMovemet;

    private Dialogue dialogue;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        continueCameraMovemet = FindObjectOfType<MouseLook>().mouseSensitivity;
        continuePlayerMovement = FindObjectOfType<PlayerMovement>().speed;

        sentences = new Queue<string>();

        responseBox.SetActive(false);

        loveMeter.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<PlayerMovement>().speed = 0;
        FindObjectOfType<MouseLook>().mouseSensitivity = 0;

        dialogueBox.SetBool("isOpen", true);

        loveMeter.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        response1Text.text = dialogue.answers[0];
        response2Text.text = dialogue.answers[1];
        response3Text.text = dialogue.answers[2];

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 2)
        {
            DisplayResponse();
            //EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void DisplayResponse()
    {
        responseBox.SetActive(true);
    }

    public void ChoiceOption1()
    {
        //string response = "fasfasdf";

        TypeSentence(dialogue.answers[1]);
        //TypeSentence(response);
    }

    public void ChoiceOption2()
    {

    }

    public void ChoiceOption3()
    {

    }

    void EndDialogue()
    {
        dialogueBox.SetBool("isOpen", false);

        loveMeter.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FindObjectOfType<PlayerMovement>().speed = continuePlayerMovement;
        FindObjectOfType<MouseLook>().mouseSensitivity = continueCameraMovemet;
    }
}
