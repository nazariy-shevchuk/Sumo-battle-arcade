using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private Text waveText;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        player = GameObject.Find("Player");
        waveText = GameObject.Find("Wave Number").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaveText();
        GameOver();
    }

    private void UpdateWaveText()
    {
        waveText.text = "Enemy Wave: " + spawnManager.waveNumber;
    }

    private void GameOver()
    {
        if (player.transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
