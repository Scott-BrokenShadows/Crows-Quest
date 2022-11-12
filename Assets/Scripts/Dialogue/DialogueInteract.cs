using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : MonoBehaviour
{
    PlayerInputs inputs;
    public GameObject npc;
    public TextAsset inkJSON;

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
        if (npc.GetComponent<DialogueTrigger>().playerInRange == true && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
}
