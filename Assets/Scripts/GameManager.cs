using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cubeHolder;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject failText;
    public static GameManager Instance;
    
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (cubeHolder.transform.childCount <= 3)
        {
            StopGame();
        }
    }

    public void StopGame()
    {
        PlayerController.Instance.shouldMove = false;
        failText.SetActive(true);
        restartButton.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
}
