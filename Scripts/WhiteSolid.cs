using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSolid : NegativeNPC
{

    PlayerInventory inventory;


    // Update is called once per frame
    void Update()
    {

        if (inventory.WaterCan == 2) return;
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && inventory.mixedSolid != null)
        {
            if (!inventory.mixedSolid.isFull())
            {
                if (!dialoguePanel.activeInHierarchy)
                {
                    dialogueName.text = charName;
                    dialogueAvatar.sprite = avatar;
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing(dialogue[0]));
                    inventory.mixedSolid.White++;

                }
                else if (dialogueText.text == dialogue[0])
                {
                    RemoveText();
                }
            }
            else
            {
                    string text = "Your water pitcher is full. It contains " + inventory.mixedSolid.Blue + " blue solid," + inventory.mixedSolid.White + " white solid," + inventory.mixedSolid.Red + " red solid," + inventory.mixedSolid.Green + " green solid.";
                if (!dialoguePanel.activeInHierarchy)
                {
                    dialogueName.text = charName;
                    dialogueAvatar.sprite = avatar;
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing(text));

                }
                else if (dialogueText.text == text)
                {
                    RemoveText();
                }
                else if (dialogueText.text == dialogue[0])
                {
                    RemoveText();
                }
            }

        }


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = true;
            inventory = other.gameObject.GetComponent<PlayerInventory>();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
            inventory = null;
        }
    }
    IEnumerator Typing(string thisDialogue)
    {
        foreach (char letter in thisDialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
}

