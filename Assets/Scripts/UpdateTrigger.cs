using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpdateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] platPrefabs;
    [SerializeField] private GameObject cubeHolder;
    private float planeStep = 60f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Vector3 newPos = cubeHolder.transform.position;
            newPos.z += planeStep;
            newPos.x = 0;
            Instantiate(platPrefabs[Random.Range(0, 3)], newPos, new Quaternion());
        }
        Destroy(other.gameObject);
    }

}
