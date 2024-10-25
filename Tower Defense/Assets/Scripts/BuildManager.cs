using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour // Classe BuildManager: Gerencia a seleção e o acesso a torres para construção.
{
    public static BuildManager instance;  // Instância estática da classe BuildManager, usada para acessar globalmente.

    [SerializeField] private Tower[] towers; // Array de torres disponíveis para construção.
    private int selectedTower; // Índice da torre atualmente selecionada.
    private void Awake() // Método chamado quando o objeto é instanciado. Inicializa a instância estática.
    {
        instance = this; // Define a instância atual como a instância estática.
    }
    public Tower GetSelectedTower() // Retorna a torre atualmente selecionada.
    {
        return towers[selectedTower];  // Retorna a torre com base no índice selecionado.
    }
    public void SetSelectedTower(int _selectedTower) // Define a torre selecionada pelo índice fornecido.
    {
        selectedTower = _selectedTower;  // Atualiza o índice da torre selecionada.
    }
}
