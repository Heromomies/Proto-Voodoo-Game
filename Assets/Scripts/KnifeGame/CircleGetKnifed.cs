using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGetKnifed : MonoBehaviour
{
    public int level;
    private float _randomNumber;
    void Update()
    {
        Debug.Log(level);
        switch (level)
        {
            case 1: _randomNumber = 0.2f;
                break;
            case 2: _randomNumber = 0.4f;
                break;
            case 3: _randomNumber = 0.6f;
                break;
            case 4: _randomNumber = -0.8f;
                break;
            case 5: _randomNumber = 1;
                break;
            case 6: _randomNumber = 1.2f;
                break;
            case 7: _randomNumber = -1.4f;
                break;
            case 8: _randomNumber = 1.6f;
                break;
            case 9: _randomNumber = 1.8f;
                break;
            case 10: _randomNumber = -2f;
                break;
        }
        transform.Rotate( new Vector3(0, 0, _randomNumber));
    }
}
