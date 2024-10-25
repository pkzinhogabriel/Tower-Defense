using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour // Classe EnemyMovement: Controla o movimento dos inimigos ao longo de um caminho definido.

{
    [SerializeField] private Rigidbody2D rb;    // Componente Rigidbody2D usado para movimentar o inimigo.

    [SerializeField] private float moveSpeed = 2f;    // Velocidade de movimento do inimigo.

    private Transform target;    // Refer�ncia ao pr�ximo ponto do caminho que o inimigo deve seguir.

    private int pathIndex = 0;    // �ndice do ponto atual no caminho.

    private float baseSpeed;    // Velocidade base do inimigo, usada para resetar a velocidade.

    // M�todo chamado no in�cio do jogo. Inicializa a velocidade e o alvo do inimigo.
    private void Start()
    {
        baseSpeed = moveSpeed; // Armazena a velocidade base.
        target = LevelManager.instance.path[pathIndex]; // Define o primeiro ponto do caminho como alvo.
    }

    // M�todo chamado a cada quadro para verificar a dist�ncia at� o pr�ximo ponto do caminho.
    private void Update()
    {
        if (Vector2.Distance(target.position,transform.position) <= 0.1f)         // Verifica se o inimigo chegou perto o suficiente do ponto alvo.

        {
            pathIndex++; // Avan�a para o pr�ximo ponto do caminho.

            if (pathIndex == LevelManager.instance.path.Length)            // Verifica se o inimigo atingiu o final do caminho.

            {
                EnemySpawner.onEnemyDestroy.Invoke(); // Notifica o spawner que o inimigo foi destru�do.
                Destroy(gameObject); // Destr�i o objeto do inimigo.
                return;
            }
            else
            {
                target = LevelManager.instance.path[pathIndex]; // Atualiza o alvo para o pr�ximo ponto do caminho.
            }
        }
    }
    private void FixedUpdate()     // M�todo chamado a cada quadro de f�sica para mover o inimigo.

    {
        Vector2 direction = (target.position -  transform.position).normalized;         // Calcula a dire��o do movimento em dire��o ao alvo e normaliza.


        rb.velocity = direction * moveSpeed;         // Define a velocidade do Rigidbody2D para mover o inimigo em dire��o ao alvo.

    }
    public void UpdateSpeed(float newSpeed)     // M�todo para atualizar a velocidade do inimigo, usado por torres ou outros efeitos.

    {
        moveSpeed = newSpeed; // Atualiza a velocidade de movimento.
    }
    public void ResetSpeed()     // M�todo para resetar a velocidade do inimigo � sua velocidade base.

    {
        moveSpeed = baseSpeed; // Restaura a velocidade original.
    }
}
