using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public int Difficulty = 1; // 1 EASY - 2 MEDIUM - 3 HARD
    public float GravityScale = 0.2f; // Padrão é 1. Menores valores = queda mais lenta

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI DifficultyText;

    public GameObject InitPainel;
    public GameObject MenuPainel;
    public GameObject WinPainel;
    public GameObject GameOverPainel;
    public GameObject Garbage;

    public static GameController intance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intance = this;
    }

    public void StartGame()
    {
        TotalScore = 0;
        UpdateScoreText();

        GameOverPainel.SetActive(false);
        WinPainel.SetActive(false);
        MenuPainel.SetActive(false);
        InitPainel.SetActive(false);

        Garbage.SetActive(true);

        TrashSpawner.intance.initSpawner();
    }

    public void RestartGame()
    {
        TotalScore = 0;
        UpdateScoreText();

        GameOverPainel.SetActive(false);
        WinPainel.SetActive(false);
        MenuPainel.SetActive(false);
        Garbage.SetActive(false);
        
        InitPainel.SetActive(true);
    }

    public void ResumeGame()
    {
        Garbage.SetActive(true);
        TrashSpawner.intance.initSpawner();
    }

    public void PauseGame()
    {
        Garbage.SetActive(false);
        TrashSpawner.intance.stopSpawner();
    }

    public void UpdateScoreText()
    {
        ScoreText.text = "Score: " + TotalScore.ToString();
    }

    public void UpdateDifficulty(string textoSelecionado)
    {
        Debug.Log("Selecionado: " + textoSelecionado);
        if (textoSelecionado == "MEDIUM")
        {
            Difficulty = 2;
            GravityScale = 0.4f;
        }
        else if (textoSelecionado == "HARD")
        {
            Difficulty = 3;
            GravityScale = 0.7f;
        }
        else
        {
            Difficulty = 1;
            GravityScale = 0.2f;
        }

        DifficultyText.text = "Difficulty: " + textoSelecionado;
    }
}
