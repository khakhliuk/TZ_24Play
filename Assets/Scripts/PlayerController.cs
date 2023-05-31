using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForse;
    [SerializeField] private GameObject cubeHolder;
    [SerializeField] private GameObject warp;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject holdText;
    [SerializeField] private Animator animator;
    public static PlayerController Instance;
    private Vector3 position;
    private Transform playerTransform;
    public bool shouldMove;
    private bool firstTouch = true;
    
    void Start()
    {
        Instance = this;
        playerTransform = GetComponent<Transform>();
        AddBox();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WallCube"))
        {
            GameManager.Instance.StopGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            playerTransform.Translate(Vector3.forward * (speed * Time.deltaTime));
            cubeHolder.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (firstTouch)
            {
                shouldMove = true;
                holdText.SetActive(false);
                warp.SetActive(true);
                firstTouch = false;
            }
            
            if (touch.phase == TouchPhase.Moved && shouldMove)
            {
                float nextMove = playerTransform.position.x + touch.deltaPosition.x * 0.003f;
                if (Math.Abs(nextMove) <= 2)
                {
                    position = playerTransform.position;
                    playerTransform.position = new Vector3(nextMove, position.y, position.z);;
                    cubeHolder.transform.position = new Vector3(nextMove, cubeHolder.transform.position.y, cubeHolder.transform.position.z);
                }
            }
        }
                
    }

    public void AddBox()
    {
        playerTransform.Translate(0f, jumpForse, 0f);
        Instantiate(cubePrefab, playerTransform.position, new Quaternion(), cubeHolder.transform);
        animator.SetTrigger("Jump");
    }
    
    public void DeleteBox()
    {
        Destroy(cubeHolder.transform.GetChild(0).gameObject);
    }
}
