using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("General")] 
    [SerializeField] private int score;
    [SerializeField] private bool isGameOver = false;

    [Header("Spawn")]
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1f;

    [Header("References")] 
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
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
}
