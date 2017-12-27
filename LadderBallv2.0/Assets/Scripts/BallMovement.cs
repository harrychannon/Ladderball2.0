using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private Vector3 InitialTouchPos;
    private Vector3 LastTouchPos;
    private Vector3 BallMovementVector;

    private bool IsGameOver;

    public GameObject RightWall;
    public GameObject LeftWall;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        DetectPlayerTouch();
    }

    void DetectPlayerTouch()
    {
        if (Input.touchCount == 1)
        {
            Touch GettingPlayerTouch = Input.GetTouch(0);

            if (GettingPlayerTouch.phase == TouchPhase.Began)
            {
                InitialTouchPos = GettingPlayerTouch.position;
                LastTouchPos = GettingPlayerTouch.position;
            }

            else if (GettingPlayerTouch.phase == TouchPhase.Moved)
            {
                LastTouchPos = GettingPlayerTouch.position;
            }

            else if (GettingPlayerTouch.phase == TouchPhase.Ended)
            {
                LastTouchPos = GettingPlayerTouch.position;

                BallMovementVector.x = Mathf.Abs(InitialTouchPos.x - LastTouchPos.x);
                BallMovementVector.y = Mathf.Abs(InitialTouchPos.y - LastTouchPos.y);

                GetComponent<Rigidbody>().AddForce(BallMovementVector.x, BallMovementVector.y, 0.0f);

                RightWall.transform.localScale = RightWall.transform.localScale + new Vector3(0.0f, 1.0f, 0.0f);
                LeftWall.transform.localScale = LeftWall.transform.localScale + new Vector3(0.0f, 1.0f, 0.0f);
            }
        }
    }

    void OnCollisionEnter(Collision CollidedObject)
    {
        if (CollidedObject.gameObject.tag == "Ladder")
        {
            IsGameOver = true;
            Destroy(gameObject);
        }
    }
}
