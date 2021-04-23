using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public float score;

    public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }

    public float speed;
    public Transform minPos, maxPos;
    public Direction myDirection;
    
    private bool _goRight, _goUp, _goLeft, _goDown;

    private void Start()
    {
        if (myDirection == Direction.Right)
        {
            _goRight = true;
        }
        if (myDirection == Direction.Up)
        {
            _goUp = true;
        }
        if (myDirection == Direction.Left)
        {
            _goLeft = true;
        }
        if (myDirection == Direction.Down)
        {
            _goDown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 5)
        {
            Right();
        }
       
        Up();
        Left();
        Down();
    }

    void Right()
    {
        if (myDirection == Direction.Right)
        {
            if (_goRight)
            {
                transform.Translate(Vector2.right * (Time.deltaTime * speed));
            }
            if (transform.position.x >= maxPos.position.x)
            {
                _goRight = false;
            }
            if (!_goRight)
            {
                transform.Translate(Vector2.left * (Time.deltaTime * speed));
            }
            if (transform.position.x <= minPos.position.x)
            {
                _goRight = true;
            }
        }
    }
    void Left()
    {
        if (myDirection == Direction.Left)
        {
            if (_goLeft)
            {
                transform.Translate(Vector2.left * (Time.deltaTime * speed));
            }
            if (transform.position.x >= maxPos.position.x)
            {
                _goLeft = true;
            }
            if (!_goLeft)
            {
                transform.Translate(Vector2.right * (Time.deltaTime * speed));
            }
            if (transform.position.x <= minPos.position.x)
            {
                _goLeft = false;
            }
        }
    }
    void Up()
    {
        if (myDirection == Direction.Up)
        {
            if (_goUp)
            {
                transform.Translate(Vector2.up * (Time.deltaTime * speed));
            }
            if (transform.position.y >= maxPos.position.y)
            {
                _goUp = false;
            }
            if (!_goUp)
            {
                transform.Translate(Vector2.down * (Time.deltaTime * speed));
            }
            if (transform.position.y <= minPos.position.y)
            {
                _goUp = true;
            }
        }
    }
    void Down()
    {
        if (myDirection == Direction.Down)
        {
            if (_goDown)
            {
                transform.Translate(Vector2.down * (Time.deltaTime * speed));
            }
            if (transform.position.y <= maxPos.position.y)
            {
                _goDown = false;
            }
            if (!_goDown)
            {
                transform.Translate(Vector2.up * (Time.deltaTime * speed));
            }
            if (transform.position.y >= minPos.position.y)
            {
                _goDown = true;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DragAndShoot>() != null)
        {
            score++;
            scoreTxt.text = $"Score : {score}";
            SpawnerBall.Instance.SpawnBall();
        }
    }
}
