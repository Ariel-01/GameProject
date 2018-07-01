using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPointerFunctionality : MonoBehaviour
{

 

    // Use this for initialization
    void Start()
    {
 
    }

    //MOVEMENT
    IEnumerator MovePlayer(int dir, char axis)
    {
        moveState = PlayerMoveState.MOVING;
        Vector2 incrementVector = new Vector2(0, 0);
        float fraction = 0;
        //Changes sprite direction and assigns direction vector
        if (dir > 0 && axis == 'x')
        {
            incrementVector = new Vector2(MOVE_DIST, 0);
        }
        else if (dir < 0 && axis == 'x')
        {
            incrementVector = new Vector2(-MOVE_DIST, 0);
        }
        else if (dir > 0 && axis == 'y')
        {
            incrementVector = new Vector2(0, MOVE_DIST);
        }
        else if (dir < 0 && axis == 'y')
        {
            incrementVector = new Vector2(0, -MOVE_DIST);
        }

        //POS INIT
        Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPos = startPos + incrementVector;

        do
        {
            fraction += Time.deltaTime * MOVE_SPEED;
            transform.position = Vector2.Lerp(startPos, targetPos, fraction);
            yield return null;
        }
        while (fraction < 1 && moveState == PlayerMoveState.MOVING);

        moveState = PlayerMoveState.IDLE;
        yield return new WaitForSeconds(0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        //checking for input
        Vector2 moveInput = Vector2.zero;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        switch (moveState)
        {
            case PlayerMoveState.IDLE:
                if (moveInput.x == 1 || moveInput.x == -1)
                {
                    bool allowMove = currentFloor.canMove("x", (int)moveInput.x, playerSize);
                    if (allowMove)
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 90f) * -1 * moveInput.x;

                        StartCoroutine(MovePlayer((int)moveInput.x, 'x'));
                    }
                }
                else if (moveInput.y == 1 || moveInput.y == -1)
                {

                    bool allowMove = currentFloor.canMove("y", (int)moveInput.y, playerSize);
                    if (allowMove)
                    {
                        if (moveInput.y == 1) transform.eulerAngles = new Vector3(0f, 0f, 0f);
                        if (moveInput.y == -1) transform.eulerAngles = new Vector3(0f, 0f, 180f);
                        StartCoroutine(MovePlayer((int)moveInput.y, 'y'));
                    }
                }
                break;
        }
    }


}
