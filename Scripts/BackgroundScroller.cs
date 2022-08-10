using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 _moveSpeed;
    private Vector2 _offset;
    private Material _material;
    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offset = _moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += _offset;
    }
}
