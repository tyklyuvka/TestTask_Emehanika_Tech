using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _jumpPower;
    [SerializeField]
    private GameObject _gameMenu;
    private Rigidbody _rigidbody;
    private bool _isJumping = false;
    private Vector2 _touchStartPos;
    private Vector2 _touchEndPos;
    
     private float _step= 0.1f;

    private float _swipeDistanceThreshold = 70f;
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (Input.touchCount > 0 && _gameMenu.activeSelf) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                _touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) {
                _touchEndPos = touch.position;
                Vector2 swipeDirection = _touchEndPos - _touchStartPos;
                if (!_isJumping)  {
                    if (swipeDirection.y > _swipeDistanceThreshold) {
                        Jump();
                    }
                    if (swipeDirection.x > _swipeDistanceThreshold) {
                        MoveRight();
                    }
                    if (swipeDirection.x < -_swipeDistanceThreshold){
                        MoveLeft();
                    }
                }
            }
        }
    }

    private void Jump(){
        _rigidbody.AddForce(_jumpPower * Vector3.up, ForceMode.Impulse);
        _isJumping = true;
    }

    private void MoveRight(){
        if (transform.position.x!=_step) {
            Vector3 newPosition = new Vector3(_step, 0, 0);  
            transform.position += newPosition;
        }
    }

    private void MoveLeft() {
        if (transform.position.x!=(-_step)) {
                Vector3 newPosition = new Vector3(-_step, 0, 0);  
                transform.position += newPosition;
            }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) {
            _isJumping = false;
        }
    }

}
