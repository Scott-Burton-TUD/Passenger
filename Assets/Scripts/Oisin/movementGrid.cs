using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementGrid : MonoBehaviour
{
    private bool isMoving = false;
    private float speed = 0.2f;
    private Vector3 origPos, targetPos;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
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