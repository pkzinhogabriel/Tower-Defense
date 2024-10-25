using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour // Classe BuildManager: Gerencia a sele��o e o acesso a torres para constru��o.
{
    public static BuildManager instance;  // Inst�ncia est�tica da classe BuildManager, usada para acessar globalmente.

    [SerializeField] private Tower[] towers; // Array de torres dispon�veis para constru��o.
    private int selectedTower; // �ndice da torre atualmente selecionada.
    private void Awake() // M�todo chamado quando o objeto � instanciado. Inicializa a inst�ncia est�tica.
    {
        instance = this; // Define a inst�ncia atual como a inst�ncia est�tica.
    }
    public Tower GetSelectedTower() // Retorna a torre atualmente selecionada.
    {
        return towers[selectedTower];  // Retorna a torre com base no �ndice selecionado.
    }
    public void SetSelectedTower(int _selectedTower) // Define a torre selecionada pelo �ndice fornecido.
    {
        selectedTower = _selectedTower;  // Atualiza o �ndice da torre selecionada.
    }
}
