using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float _shakeDuration = 1f;
    [SerializeField] float _shakeMagnitude = 0.5f;

    private Vector3 _initialPosition;
    void Start()
    {
        _initialPosition = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {

        float elapsedTime = 0f;
        while (elapsedTime < _shakeDuration)
        {
            transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(_shakeDuration);
        }
        transform.position = _initialPosition;
    }

}
