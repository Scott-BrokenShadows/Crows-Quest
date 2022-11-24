using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    

    public GameObject visualCue;
    public bool playerInRange;
    public bool hasSpoke;
    float noticeMin = -0.005f;
    float noticeMax = 0.005f;
    float noticeVal = 0f;
    float noticeMe = 0.0001f;
    // Set Bounce Boundaries

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !hasSpoke)
        {
            visualCue.SetActive(true);
        }
        else
        {
            visualCue.SetActive(false);
        }
        // Bounce UI Icon
        noticeVal += noticeMe;
        if (noticeVal >= noticeMax) noticeMe = -noticeMe; 
        if (noticeVal <= noticeMin) noticeMe = -noticeMe;
        visualCue.transform.position += new Vector3 (0, noticeVal, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    
}
