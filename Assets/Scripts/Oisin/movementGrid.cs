using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementGrid : MonoBehaviour
{
    private bool isMoving = false;
    private float speed = 0.2f;
    private Vector3 origPos, targetPos;
    private bool uCol;
    private bool dCol;
    private bool lCol;
    private bool rCol;


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 1))
        {
            uCol = true;
        }

        else
        {
            uCol = false;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1))
        {
            dCol = true;
        }

        else
        {
            dCol = false;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 1))
        {
            lCol = true;
        }

        else
        {
            lCol = false;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 1))
        {
            rCol = true;
        }

        else
        {
            rCol = false;
        }


        if (Input.GetKey(KeyCode.UpArrow) && !isMoving && !uCol)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (Input.GetKey(KeyCode.DownArrow) && !isMoving && !dCol)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving && !lCol)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isMoving && !rCol)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float moveTime = 0f;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (moveTime < speed)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (moveTime / speed));
            moveTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
}