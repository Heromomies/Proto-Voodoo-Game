using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class PlayerControllerProto1 : MonoBehaviour
{
    public SwipeDirection swipeDirection;
    // Update is called once per frame
    void Update()
    {
	    if (SwipeDirection.Down == swipeDirection)
	    {
		    transform.position -= new Vector3(0,1);
	    }
	    
    }
}
