using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NegativeNPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueName;
    public Image dialogueAvatar;
    public string[] dialogue;
    public Sprite avatar;
    public string charName;
    protected int index = 0;
    protected bool isDone = false;
    public float wordSpeed;
    public bool playerIsClose;



    void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialogueName.text = charName;
                dialogueAvatar.sprite = avatar;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }
 
    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialogueName.text = "";
        dialogueAvatar.sprite = null;
        dialoguePanel.SetActive(false);
        isDone = true;

    }

    protected  IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            
            RemoveText();
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }

}

