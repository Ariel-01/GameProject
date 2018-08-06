using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrMovementUnitBasic : MonoBehaviour {

    const int MOVE_DIST = 12; //the distance the unit can move per unit time
    const float DELAY = 0.5f;

    private float speed = 0.2f;
    private enum UnitState { MOVING = 0, ATTACKING = 1 };
    private enum UnitOwner { PLAYER = 0, ENEMY = 1};
    private float range = 3.0f;

    private float timer = DELAY;
    private UnitState unitState;
    private UnitOwner unitOwner;
    private bool canAttack = true;

    public GameObject bullet;
    
    // Use this for initialization
	void Start () {
        //for a sample these will do
        unitState = UnitState.MOVING;
        unitOwner = UnitOwner.PLAYER;
    }

    //Move the unit
    IEnumerator MoveUnit(int dir)
    {
        Vector2 incrementVector;
        float fraction = 0.0f;
        if (dir == -1)
        {
            incrementVector = new Vector2( -MOVE_DIST,0);
        }
        else if (dir == 1)
        {
            incrementVector = new Vector2(MOVE_DIST,0);
        }
        else { throw new System.ArgumentException("ERROR #1: Invalid dir argument passed in system."); }

        Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPos = startPos + incrementVector;
        do
        {
            fraction += Time.deltaTime * speed;
            transform.position = Vector2.Lerp(startPos, targetPos, fraction);

            yield return null;
        }
        while (fraction < 1);

        yield return new WaitForSeconds(0.25f);
    }

    void attack()
    {
        Vector2 newPos = transform.position;
        newPos.x += 1;
        Instantiate(bullet, newPos
            , transform.rotation);
    }

    // Update is called once per frame
    void Update() {
        RaycastHit2D raycast =  Physics2D.Raycast(transform.position,Vector3.right,range);
        if (raycast.collider != null)
        {
            unitState = UnitState.ATTACKING;
        }
        else { unitState = UnitState.MOVING; }

        // Something will be added later to calculate state
        switch (unitState)
        {
            case UnitState.MOVING:
                if (unitOwner == UnitOwner.PLAYER) StartCoroutine(MoveUnit(1)); 
                else StartCoroutine(MoveUnit(-1));
                break;
            case UnitState.ATTACKING:
                StopAllCoroutines();
                if (canAttack) { 
                    attack();
                    canAttack = false;
                }

                if (!canAttack)
                {
                    timer -= Time.deltaTime;
                    if (timer < 0)
                    {
                        canAttack = true;
                        timer = DELAY;
                    }
                }
                break;
        }
	}
}
