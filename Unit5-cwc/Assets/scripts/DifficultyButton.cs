using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    private GameManager _gameManager;

    [SerializeField] private int difficulty;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        _gameManager.StartGame(difficulty);
    }
}
