using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLadder : MonoBehaviour {

    public bool IsMovingLeft = true;
    public bool IsMovingRight = false;

    void Update()
    {
        if (IsMovingLeft == true)
        {
            MoveLeft();
        }

        if (IsMovingRight == true)
        {
            MoveRight();
        }
    }


    private void OnCollisionEnter(Collision Barrier)
    {
        if (IsMovingLeft == true)
        {
            IsMovingLeft = false;
            IsMovingRight = true;
        }
        else if (IsMovingRight == true)
        {
            IsMovingRight = false;
            IsMovingLeft = true;
        }
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector3.back * Time.deltaTime);
    }
}
