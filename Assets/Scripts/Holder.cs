using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    [SerializeField] private GameObject plusTextPrefab;
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                PlayerController.Instance.AddBox();
                Destroy(other.gameObject);
                Instantiate(plusTextPrefab, player.transform.position, new Quaternion());
            }
        }
}
