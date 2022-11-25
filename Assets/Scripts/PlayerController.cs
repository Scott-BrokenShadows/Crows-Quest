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
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        // Get Renderer for Sprite Flip
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
           return;
        }
       
        theRB.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
       


        // Flip Sprite with X Input
        if (inputX < 0)
        {
            sprite.flipX = true;
        }
        else if (inputX > 0)
        {
            sprite.flipX = false;
        }

        Flip();
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
        inputY = context.ReadValue<Vector2>().y;
    }

    void Flip()
    {
        if (transform.GetChild(2).childCount > 0)
        {
            if (sprite.flipX == true)
            {
                transform.GetChild(2).localScale =
                new Vector3(-Mathf.Abs(transform.GetChild(2).localScale.x), transform.GetChild(2).localScale.y, transform.GetChild(2).localScale.z);
            }
            else if (sprite.flipX == false)
            {
                transform.GetChild(2).localScale =
                new Vector3(Mathf.Abs(transform.GetChild(2).localScale.x), transform.GetChild(2).localScale.y, transform.GetChild(2).localScale.z);
            }
        }
        else
        {
            transform.GetChild(2).localScale =
            new Vector3(Mathf.Abs(transform.GetChild(2).localScale.x), transform.GetChild(2).localScale.y, transform.GetChild(2).localScale.z);
        }
    }
}
