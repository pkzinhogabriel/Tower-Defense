using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour // Classe LevelManager: Gerencia informa��es relacionadas ao n�vel, como pontos de in�cio e caminho dos inimigos.

{
    public static LevelManager instance;     // Inst�ncia singleton da classe LevelManager.

    public Transform startPoint;    // Ponto de in�cio para onde os inimigos devem ser gerados.

    public Transform[] path;    // Array de pontos que definem o caminho que os inimigos devem seguir.

    public int currency; // vari�vel das Moedas 

    private void Awake()    // M�todo chamado quando o objeto � inicializado.

    {
        instance = this; // Inicializa a inst�ncia singleton.
    }
    private void Start()
    {
        currency = 100; // inicia com 100 moedas
    }
    public void IncreaseCurrency(int amount) // Metodo que aumenta as Moedinhas
    {
        currency += amount;
    }
    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Pobre voc� �");
            return false;        
        }
    }
}
