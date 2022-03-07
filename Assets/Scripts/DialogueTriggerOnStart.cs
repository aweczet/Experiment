using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOnStart : MonoBehaviour
{
    public DialogueTrigger trigger;
    private void Start()
    {
        trigger.TriggerDialogue();
    }
}
