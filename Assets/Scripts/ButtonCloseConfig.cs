using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCloseConfig : MonoBehaviour
{
    public Button meuBotao;
    public GameObject MenuPainel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuBotao.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {        
        MenuPainel.SetActive(false);
        GameController.intance.ResumeGame();
    }
}
