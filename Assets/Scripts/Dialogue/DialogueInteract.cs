using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : MonoBehaviour
{
    PlayerInputs inputs;
    public GameObject[] npc;
    public TextAsset[] inkJSON;

    private void Awake()
    {
        inputs = new PlayerInputs();

        inputs.Player.Interact.performed += ctx => Talk();
    }

    private void OnEnable()
    {
        inputs.Player.Enable();
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
    }

    public void Talk()
    {
        for(var i=0;i<npc.Length;i++) {
            if (npc[i].GetComponent<DialogueTrigger>().playerInRange == true && !npc[i].GetComponent<DialogueTrigger>().hasSpoke && !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[i]);
                npc[i].GetComponent<DialogueTrigger>().hasSpoke = true;
            }
        }
    }
}
