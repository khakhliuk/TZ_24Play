using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.1f;

    private void Start()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        SmoothFollow();   
    }

    public void SmoothFollow()
    {
        Vector3 targetPos = target.position + offset;
        //Vector3 smoothFollow = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        //smoothFollow.x = transform.position.x;
        transform.position = targetPos;
    }
    
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}
