using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimController : MonoBehaviour
{
    public float MoveX;
    public float MoveY;
    public bool isMoving;

    [SerializeField] List<Sprite> flyingIdleSprites;

    [SerializeField] List<Sprite> flyingDownSprites;
    [SerializeField] List<Sprite> flyingUpSprites;
    [SerializeField] List<Sprite> flyingRightSprites;
    [SerializeField] List<Sprite> flyingLeftSprites;

    // States
    SpriteAnimator flyingIdleAnim;
    SpriteAnimator flyingDownAnim;
    SpriteAnimator flyingUpAnim;
    SpriteAnimator flyingRightAnim;
    SpriteAnimator flyingLeftAnim;

    // Current State
    SpriteAnimator currentAnim;

    // Checking Previous Move
    bool wasPreviouslyMoving;

    // Refrences
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        flyingIdleAnim = new SpriteAnimator(flyingIdleSprites, spriteRenderer);
        flyingDownAnim = new SpriteAnimator(flyingDownSprites, spriteRenderer);
        flyingUpAnim = new SpriteAnimator(flyingUpSprites, spriteRenderer);
        flyingRightAnim = new SpriteAnimator(flyingRightSprites, spriteRenderer);
        flyingLeftAnim = new SpriteAnimator(flyingLeftSprites, spriteRenderer);

        currentAnim = flyingIdleAnim;
    }

    private void Update()
    {
        var prevAnim = currentAnim;

        if (MoveX == 1)
        { currentAnim = flyingRightAnim; }
        else if (MoveX == -1)
        { currentAnim = flyingLeftAnim; }
        else if (MoveY == 1)
        { currentAnim = flyingUpAnim; }
        else if (MoveY == -1)
        { currentAnim = flyingDownAnim; }

        if (currentAnim != prevAnim || isMoving != wasPreviouslyMoving)
        { currentAnim.Start(); }

        if (isMoving)
        { currentAnim.HandleUpdate(); }
        else
        { spriteRenderer.sprite = currentAnim.Frames[0]; }

        wasPreviouslyMoving = isMoving;
    }
}
