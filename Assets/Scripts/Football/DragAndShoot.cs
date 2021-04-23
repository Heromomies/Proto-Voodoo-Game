using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    public float forceMultiplier;
    
    private Vector3 _mousePressDownPos, _mouseReleasePos;
    private Rigidbody _rb;
    private bool _isShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _mouseReleasePos = Input.mousePosition;
        Shoot(_mouseReleasePos - _mousePressDownPos);
    }
    
    void Shoot(Vector3 force)
    {
        if (_isShoot)
            return;
        
        _rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        _isShoot = true;
    }
    
}
