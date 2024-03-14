using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAvatarNPC : NegativeNPC
{
    // Start is called before the first frame update
    public Sprite[] avatar1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialogueName.text = charName;
                dialogueAvatar.sprite = avatar1[index];
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
                dialogueAvatar.sprite = avatar1[index];


            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }
}
