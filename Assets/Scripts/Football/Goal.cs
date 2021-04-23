using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    private float _score;

    public GameObject confettis;
    public float speed;
    public Transform minPos, maxPos;

    private bool _goRight, _goUp, _goLeft, _goDown;
    
    // Update is called once per frame
    void Update()
    {
        if (_score > 5 && _score <= 15)
        {
            Right();
        }

        if (_score > 15 && _score <= 30)
        {
            Down();
            speed = 8;
        }

        if (_score > 30 && _score <= 50)
        {
            Down();
            Right();
            speed = 10;
        }
        if(_score > 50)
        {
            Down();
            Right();
            speed = 15;
        }
    }

    void Right()
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
    void Left()
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
    void Up()
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
    void Down()
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DragAndShoot>() != null)
        {
            GameObject cf = Instantiate(confettis, other.transform.position, Quaternion.identity);
            Destroy(cf, 0.5f);
            _score++;
            scoreTxt.text = $"Score : {_score}";
            Destroy(other.gameObject);
            SpawnerBall.Instance.SpawnBall();
        }
    }
}
