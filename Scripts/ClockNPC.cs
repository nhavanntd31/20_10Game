using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClockNPC : NegativeNPC
{
    // Start is called before the first frame update
    public Clock _clock;
    public Image clockWindows;
    void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        dialogueAvatar.sprite = avatar;
        _clock = GetComponent<Clock>();
        clockWindows = _clock.clock;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (clockWindows.gameObject.activeInHierarchy)
            {
                if (_clock.checkCorrectHour())
                {
                    _clock.isCorrect = true;
                    clockWindows.gameObject.SetActive(false);
                } 
            } 
            if (!dialoguePanel.activeInHierarchy && _clock.isCorrect)
            {
                dialogueName.text = charName;
                dialogueAvatar.sprite = avatar;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialoguePanel.activeInHierarchy && dialogueText.text == dialogue[0])
            {
                RemoveText();
            }
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
 