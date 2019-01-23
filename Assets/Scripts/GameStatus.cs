using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f, 10.0f)][SerializeField] float timeScale = 1f;

    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake() {
        if(FindObjectsOfType<GameStatus>().Length > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update() {
        Time.timeScale = timeScale;
    }

    public void AddToScore() {
        currentScore = currentScore + pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ClearScore() {
        currentScore = 0;
    }
}
