using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MixedSolid : NegativeNPC
{
  
    private PlayerInventory inventory;
    public int correctBlue;
    public int correctWhite;
    public int correctRed;
    public int correctGreen;
    public int Blue;
    public int White;
    public int Red;
    public int Green;
    public GameObject Can;
    public Sprite filledSprite;

    void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        dialogueAvatar.sprite = avatar;
        Can.GetComponent<SpecialFlower>().enabled = false;  
    }

    void Update()
    {
        if (!isDone)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                if (!dialoguePanel.activeInHierarchy)
                {
                    dialogueName.text = charName;
                    dialogueAvatar.sprite = avatar;
                    dialoguePanel.SetActive(true);
                    inventory.WaterCan = 1;
                    inventory.mixedSolid = this;
                    StartCoroutine(Typing(dialogue[0]));

                }
                else if (dialogueText.text == dialogue[0])
                {
                    RemoveText();
                    Can.SetActive(false);
                    
                }

            }


        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                if (isFull())
                {
                    if (check())
                    {
                        if (!dialoguePanel.activeInHierarchy)
                        {
                            dialogueName.text = charName;
                            dialogueAvatar.sprite = avatar;
                            dialoguePanel.SetActive(true);
                            inventory.WaterCan = 1;
                            inventory.mixedSolid = this;
                            StartCoroutine(Typing(dialogue[2]));

                        }
                        else if (dialogueText.text == dialogue[2])
                        {
                            RemoveText();
                            Can.SetActive(true);
                            Can.GetComponent<SpriteRenderer>().sprite = filledSprite;
                            Can.GetComponent<SpecialFlower>().enabled = true;

                            clearSolid();
                        }

                    }
                    else
                    {
                        if (!dialoguePanel.activeInHierarchy)
                        {
                            dialogueName.text = charName;
                            dialogueAvatar.sprite = avatar;
                            dialoguePanel.SetActive(true);
                            inventory.WaterCan = 1;
                            inventory.mixedSolid = this;
                            StartCoroutine(Typing(dialogue[1]));

                        }
                        else if (dialogueText.text == dialogue[1])
                        {
                            RemoveText();
                            clearSolid();
                        }
                    }
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
    private bool check()
    {
        return (Red == correctRed && Blue == correctBlue && White == correctWhite && Green == correctGreen);
    }
    public bool isFull()
    {
        return Red + Blue + White + Green == 10;
    }    
    private void clearSolid()
    {
        Red = 0; Blue = 0; White = 0;  Green = 0;
    }
}
