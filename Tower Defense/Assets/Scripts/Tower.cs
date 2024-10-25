
using System;
using UnityEngine;

[Serializable]
public class Tower  // Classe Tower: Representa uma torre que pode ser construída no jogo.

{
    public string name;     // Nome da torre.

    public GameObject prefab;    // Prefab da torre, usado para instanciar a torre no jogo.

    public Tower(string _name, int _cost, GameObject _prefab)    // Construtor da classe Tower, que inicializa os atributos da torre.

    {
        name = _name;// Inicializa o nome da torre.

        prefab = _prefab; // Inicializa o prefab da torre.

    }
}