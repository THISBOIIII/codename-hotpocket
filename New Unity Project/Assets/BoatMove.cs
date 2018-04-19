using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour {

    public float boatSpeed = 0.01f;
    public bool isMoving;
    public Vector2 startPoint;
    public Vector2 stopPoint;
    public bool moveRight = true;
	// Use this for initialization
	void Awake () {
        Debug.Log(transform);
        startPoint = new Vector2(transform.position.x, transform.position.y);
	}

    void Move()
    {
        if (transform.position.x > stopPoint.x)
            moveRight = false;
        else if (transform.position.x < startPoint.x)
            moveRight = true;


        if (moveRight)
        {
            transform.Translate(Vector2.right * boatSpeed);
        }
        else
        {
            transform.Translate(Vector2.left * boatSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }
}
