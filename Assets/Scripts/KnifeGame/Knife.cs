using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed;
    public bool isMoving = true;
    
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * speed));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isMoving = false;
        gameObject.transform.parent = other.transform;
        GetComponent<SpriteRenderer>().sortingOrder = -1;
        if (other.GetComponent<Knife>())
        {
            Death.Instance.Dead();
        }
    }
}
