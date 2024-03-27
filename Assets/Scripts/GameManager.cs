using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI textCoin;

    public TextMeshProUGUI textRequired;

    public TextMeshProUGUI textCurrentSpeed;

    public int coin = 0;

    public Car carMain;

    public int updateSpeedCost = 10;

    private bool isGameFinished;

    private void Awake()
    {
        Instance = this;

        isGameFinished = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (isGameFinished)
        {
            ResetGame();
            return;
        }

        SetText();
    }

    private void SetText()
    {
        textCoin.SetText("Coin : {0}", coin);

        textRequired.SetText("Speed update : {0}", updateSpeedCost);

        textCurrentSpeed.SetText("Current Speed : {0}", carMain.speed);
    }

    public void SpeedUpdate()
    {
        if (coin >= updateSpeedCost)
        {
            carMain.speed += 1f;

            coin -= updateSpeedCost;

            if (carMain.speed == 10)
                isGameFinished = true;
        }
    }
}