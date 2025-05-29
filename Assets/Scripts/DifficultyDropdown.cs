using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyDropdown : MonoBehaviour
{

    public TMP_Dropdown meuDropdown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Debug.Log("Valor inicial: " + meuDropdown.options[meuDropdown.value].text);
        
        // Detectar mudanças
        meuDropdown.onValueChanged.AddListener(OnDropdownMudou);
    }

    void OnDropdownMudou(int indiceSelecionado)
    {
        string textoSelecionado = meuDropdown.options[indiceSelecionado].text;
        GameController.intance.UpdateDifficulty(textoSelecionado);
    }
}
