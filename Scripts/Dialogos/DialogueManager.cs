using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public PerkManager perkManager;
    public Dialogue dialogue;
    
    Queue<string> sentences;
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;
    
    string activeSentence;
    public float typingSpeed;

    public bool nearToNPC;
    public bool interactable;

    public GameObject perkMachine;
    public bool isPerkMachine;
    public bool buyPerkDialogue;
    public string perkToBuy;
    
    void Start()
    {
        nearToNPC = false;
        sentences = new Queue<string>();
        typingSpeed = 0.05f;

        perkManager.InitializePerksPrice();
    }

    private void StartDialogue()
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentencesList) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (sentences.Count <= 0) {
            displayText.text = activeSentence;
            dialoguePanel.SetActive(false);
            return;
        }

        activeSentence =  sentences.Dequeue();
        displayText.text = activeSentence;

        StartCoroutine(TypeSentence(activeSentence));
    }

    public void DisplayNewText(string newText)
    {
        activeSentence =  newText;
        displayText.text = activeSentence;

        StartCoroutine(TypeSentence(activeSentence));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            dialoguePanel.SetActive(true);
            StartDialogue();
        }

        if (isPerkMachine) {
            perkMachine = this.gameObject;
        }

        nearToNPC = true;
    }

    private void Update()
    {
        if (nearToNPC) {
            if (Input.GetKey(KeyCode.Return) && displayText.text == activeSentence) {
                DisplayNextSentence();
            }

            if (interactable) {
                if (buyPerkDialogue) {
                    if (Input.GetKeyDown(KeyCode.E)  && displayText.text == activeSentence) {
                        perkManager.BuyPlayerPerk(this.gameObject, perkToBuy);
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            nearToNPC = false;
            dialoguePanel.SetActive(false);
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
