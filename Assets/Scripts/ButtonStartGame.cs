using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStartGame : MonoBehaviour
{
    public Button meuBotao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuBotao.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        GameController.intance.StartGame();
    }
}
