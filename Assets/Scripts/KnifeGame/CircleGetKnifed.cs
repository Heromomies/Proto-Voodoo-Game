using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGetKnifed : MonoBehaviour
{
    
    void Update()
    {
        float randomNumber = Random.Range(0.1f, 1);
        transform.Rotate( new Vector3(0, 0, randomNumber));
    }
}
