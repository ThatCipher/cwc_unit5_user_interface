using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("General")] 
    [SerializeField] private int score;
    [SerializeField] private int lifes  = 0;
    public bool isGameOver { get; private set; } = true;

    [Header("Spawn")]
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1f;

    [Header("References")] 
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject infoUI;
    
    private void Start()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = $"Score : {score}";
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.gameObject.SetActive(true);
    }

    public void UpdateLifes(int lifesAdd)
    {
        lifes += lifesAdd;
        if(lifes <= 0)
            GameOver();
        lifeText.text = $"Lifes : {lifes}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleUI.SetActive(false);
        infoUI.SetActive(true);
        isGameOver = false;
        UpdateLifes(3);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
}
