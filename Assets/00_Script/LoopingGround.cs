using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 6f;
    
    private SpriteRenderer _spriteRenderer;
    private Vector2 _startSize;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSize = _spriteRenderer.size;
    }

    void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + speed * Time.deltaTime, _spriteRenderer.size.y);
        
        if(_spriteRenderer.size.x >= width)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
