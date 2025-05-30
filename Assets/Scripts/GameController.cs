using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public int TotalLife = 3;
    public int Difficulty = 1; // 1 EASY - 2 MEDIUM - 3 HARD
    public float GravityScale = 0.2f; // Padrão é 1. Menores valores = queda mais lenta

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI DifficultyText;

    public GameObject InitPainel;
    public GameObject MenuPainel;
    public GameObject WinPainel;
    public GameObject GameOverPainel;
    public GameObject Garbage;

    
    public GameObject Life01;
    public GameObject LifeEmpty01;
    
    public GameObject Life02;
    public GameObject LifeEmpty02;
    
    public GameObject Life03;
    public GameObject LifeEmpty03;

    public static GameController intance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intance = this;
    }

    public void StartGame()
    {
        TotalScore = 0;
        TotalLife = 3;
        UpdateScoreText();
        UpdateLifes();

        GameOverPainel.SetActive(false);
        WinPainel.SetActive(false);
        MenuPainel.SetActive(false);
        InitPainel.SetActive(false);

        Garbage.SetActive(true);

        TrashSpawner.intance.initSpawner();
        TrashSpawnerNonRecyclable.intance.initSpawner();
    }

    public void RestartGame()
    {
        TotalScore = 0;
        TotalLife = 3;
        UpdateScoreText();
        UpdateLifes();

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
        TrashSpawnerNonRecyclable.intance.stopSpawner();
    }

    public void UpdateLifes()
    {

        
        // Debug.Log("TotalLife: " + TotalLife);

        if (TotalLife == 0)
        {
            PauseGame();
            LifeEmpty01.SetActive(true);
            LifeEmpty02.SetActive(true);
            LifeEmpty03.SetActive(true);

            Life01.SetActive(false);
            Life02.SetActive(false);
            Life03.SetActive(false);

            WinPainel.SetActive(false);
            MenuPainel.SetActive(false);
            Garbage.SetActive(false);
            InitPainel.SetActive(false);

            GameOverPainel.SetActive(true);
        }
        else if (TotalLife == 1)
        {
            LifeEmpty01.SetActive(false);
            LifeEmpty02.SetActive(true);
            LifeEmpty03.SetActive(true);

            Life01.SetActive(true);
            Life02.SetActive(false);
            Life03.SetActive(false);
        }
        else if (TotalLife == 2)
        {
            LifeEmpty01.SetActive(false);
            LifeEmpty02.SetActive(false);
            LifeEmpty03.SetActive(true);

            Life01.SetActive(true);
            Life02.SetActive(true);
            Life03.SetActive(false);
        }
        else if (TotalLife == 3)
        {
            LifeEmpty01.SetActive(false);
            LifeEmpty02.SetActive(false);
            LifeEmpty03.SetActive(false);

            Life01.SetActive(true);
            Life02.SetActive(true);
            Life03.SetActive(true);
        }
    }

    public void UpdateScoreText()
    {
        ScoreText.text = "Score: " + TotalScore.ToString();

        // if (TotalScore < 0) {
        //     PauseGame();
        //     GameOverPainel.SetActive(true);            
        // }

        if (Difficulty == 1 && TotalScore == 1000) {
            PauseGame();
            WinPainel.SetActive(true);
        } else if (Difficulty == 2 && TotalScore == 1200) {
            PauseGame();
            WinPainel.SetActive(true);
        } else if (Difficulty == 3 && TotalScore >= 1400) {
            PauseGame();
            WinPainel.SetActive(true);
        }
    }

    public void UpdateDifficulty(string textoSelecionado)
    {
        // Debug.Log("Selecionado: " + textoSelecionado);
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
