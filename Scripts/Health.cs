using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool _isPlayer;
    [SerializeField] int _health = 50;
    [SerializeField] int _score = 62;

    [Header("Effects")]
    [SerializeField] ParticleSystem _hitEffect;
    private CameraShake _cameraShake;
    private bool _applyCameraShake;

    [Header("Score")]
    private ScoreKeeper _scoreKeeper;

    [Header("Scene Management")]
    private LevelManager _levelManager;


    void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _levelManager = FindObjectOfType<LevelManager>();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            PlayDamageSound();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    public int GetHealth()
    {
        return _health;
    }
    void TakeDamage(int damage)
    {
        _health -= damage;   
        if (_health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (!_isPlayer)
        {
            ScoreKeeper.GetInstance().ModifyScore(_score);
        }
        else
        {
            _levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
    void PlayHitEffect()
    {
        if (_hitEffect != null)
        {
            ParticleSystem instance = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if (_cameraShake != null && _applyCameraShake)
        {
            _cameraShake.Play();
        }
        else { return; }
    }
    void PlayDamageSound()
    {
        AudioPlayer.GetInstance().PlayDamageClip();
    }
}
