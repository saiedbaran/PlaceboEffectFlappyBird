using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;
    
    private Rigidbody2D _rb;
    void Start()
    {
       _rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, _rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.GameOver();
    }
}
