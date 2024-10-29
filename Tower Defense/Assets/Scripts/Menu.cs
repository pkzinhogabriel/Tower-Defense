using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour // Classe Menu responsável por gerenciar a interface do menu do jogo

{
    [SerializeField] TextMeshProUGUI currencyUI;     // Referência ao componente TextMeshProUGUI que exibe a moeda na UI

    private void OnGUI()     // Método chamado para desenhar a interface gráfica

    {
        currencyUI.text = LevelManager.instance.currency.ToString(); // Atualiza o texto da UI com o valor atual da moeda do LevelManager

    }
    public void SetSelected() // um método criado 
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
