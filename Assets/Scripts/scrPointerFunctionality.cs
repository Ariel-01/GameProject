using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPointerFunctionality : MonoBehaviour
{
    private enum PointerState { IDLE = 0, MOVING = 1, ACTION = 2 };
    private PointerState pointerState;
    const int MOVE_DIST = 1;
    const float POINTER_SPEED = 3.0f;
    const float DELAY = 3.0f;

    public float CAP_TOP;
    public float CAP_BOT;
    public GameObject testUnit; 

    private bool canCreate = true;
    private float timer;
    private bool canMoveUp = true;
    private bool canMoveDown = true;

    // Use this for initialization
    void Start()
    {
        pointerState = PointerState.IDLE;
        timer = DELAY;
    }

    //MOVEMENT
    IEnumerator MovePlayer(int dir)
    {
        pointerState = PointerState.MOVING;
        Vector2 incrementVector = new Vector2(0, 0);
        float fraction = 0;

        if (dir > 0)
        {
            incrementVector = new Vector2(0, MOVE_DIST);
        }
        
        if (dir < 0)
        {
            incrementVector = new Vector2(0, -MOVE_DIST);
        }

        //POS INIT
        Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPos = startPos + incrementVector;

        do
        {
            fraction += Time.deltaTime * POINTER_SPEED;
            transform.position = Vector2.Lerp(startPos, targetPos, fraction);
            yield return null;
        }
        while (fraction < 1 && pointerState == PointerState.MOVING);

        pointerState = PointerState.IDLE;
        yield return new WaitForSeconds(0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        //checking the pointer is below pos or above pos
        Vector3 checkPos = transform.position;

        if (checkPos.y >= CAP_TOP)
        {
            checkPos.y = CAP_TOP;
            transform.position = checkPos;
            canMoveUp = false;
        }
        else if (checkPos.y <= CAP_BOT)
        {
            checkPos.y = CAP_BOT;
            transform.position = checkPos;
            canMoveDown = false;
        }
        else {
            canMoveDown = true;
            canMoveUp = true;
        }

        //checking for input
        Vector2 moveInput = Vector2.zero;
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (!canCreate)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                canCreate = true;
                timer = DELAY;
            }
        }

        switch (pointerState)
        {
            case PointerState.IDLE:
                if (moveInput.y == 1 && canMoveUp)
                {
                    StartCoroutine(MovePlayer((int)moveInput.y));
                }

                if (moveInput.y == -1 && canMoveDown)
                {
                    StartCoroutine(MovePlayer((int)moveInput.y));
                }
                break;
        }

        //creating test units
        float checkSpace = Input.GetAxisRaw("Jump");

        if (checkSpace == 1)
        { 
            if(canCreate)
            {
                //create unit
                Vector3 newPosition = this.transform.position;
                Instantiate(testUnit, newPosition, transform.rotation);
                canCreate = false;
            }
        }
    }
}
