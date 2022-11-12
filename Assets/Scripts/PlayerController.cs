using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D theRB;

    public float moveSpeed;

    public float inputX;
    public float inputY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        theRB.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
        inputY = context.ReadValue<Vector2>().y;
    }
}
