using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialFlower : NegativeNPC
{
    // Start is called before the first frame update
    PlayerInventory inventory; 


    // Update is called once per frame
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
                    StartCoroutine(Typing());
                }
                else if (dialogueText.text == dialogue[index])
                {
                    NextLine();
                    inventory.Flower = 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
            {
                RemoveText();
            }
        } else
        {
           this.gameObject.SetActive(false);
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
}
