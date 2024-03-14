using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NormalFlower : NegativeNPC
{


    void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        dialogueAvatar.sprite = avatar;

    }

}
