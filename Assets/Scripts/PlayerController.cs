using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private const float g = 9.8f;
    private Vector3 _moveVector;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fall;
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;
 
    private void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space ) && _characterController.isGrounded)
        {
            _fall = -_jumpForce;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
    }
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * _speed * Time.fixedDeltaTime);
       
       
        _fall += g * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fall * Time.fixedDeltaTime); 
        
        if (_characterController.isGrounded)
            _fall = 0;
    }
}
 