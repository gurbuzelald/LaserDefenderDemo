using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [Header("General")]
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _projectileBulletSpeed = 10f;
    [SerializeField] float _projectileLifeTime = 5f;
    [SerializeField] float _baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool _useAI;
    [SerializeField] float _firingRateVariance = 0f;
    [SerializeField] float _minFiringRate = 0.1f;

    [Header("Firing")]
    private Coroutine _firingCoroutine;


    [HideInInspector] public bool isFiring;
    void Start()
    {
        if (_useAI)
        {
            isFiring = true;
        }
    }


    void Update()    
    {
        Fire();
    }
    

    void Fire()
    {
        if (isFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(_projectilePrefab, 
                                              transform.position,   
                                              Quaternion.identity);

            Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.velocity = transform.up*_projectileBulletSpeed;
            }

            Destroy(instance, _projectileLifeTime);

            float timeToNextProjectile = Random.Range(_baseFiringRate - _firingRateVariance, _baseFiringRate + _firingRateVariance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, _minFiringRate, float.MaxValue);

            PlayShootingSound();
            //_audioPlayer.GetInstance().PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);

        }
    }
    void PlayShootingSound()
    {
        AudioPlayer.GetInstance().PlayShootingClip();
    }
}
