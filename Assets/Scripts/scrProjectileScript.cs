using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrProjectileScript : MonoBehaviour {

    const float SPEED = 1.0F;
    const float MOVE_DIST = 24;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Despacito");
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

    IEnumerator moveBullet()
    {
        float fraction = 0.0f;
        Vector2 incrementVector = new Vector2(MOVE_DIST, 0);
        Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPos = startPos + incrementVector;
        do
        {
            fraction += Time.deltaTime * SPEED;
            transform.position = Vector2.Lerp(startPos, targetPos, fraction);

            yield return null;
        }
        while (fraction < 1);
        yield return new WaitForSeconds(0.25f);
    }

    // Update is called once per frame
    void Update () {
        StartCoroutine(moveBullet());
	}
}
