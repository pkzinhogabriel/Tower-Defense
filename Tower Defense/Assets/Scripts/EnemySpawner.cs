using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemySpawner : MonoBehaviour // Classe EnemySpawner: Respons�vel por gerar inimigos em ondas no jogo.

{
    [SerializeField] private GameObject[] enemyPrefabs;    // Prefabs dos inimigos que podem ser gerados.

    [SerializeField] private int baseEnemies = 8;    // N�mero base de inimigos por onda.

    [SerializeField] private float enemiesPerSecond = 0.5f;    // N�mero de inimigos gerados por segundo.

    [SerializeField] private float timeBetweenWaves = 5f;    // Tempo entre ondas de inimigos.

    [SerializeField] private float difficultyScalingFactor = 0.75f;    // Fator de escalonamento de dificuldade por onda.

    [SerializeField] private float enemiesPerSecondCap = 15f;    // Limite m�ximo de inimigos gerados por segundo.


    public static UnityEvent onEnemyDestroy = new UnityEvent();    // Evento que � acionado quando um inimigo � destru�do.

    // Vari�veis internas para gerenciar o estado do spawner.

    private int currentWave = 1;// Onda atual.
    private float timeSinceLastSpawn; // Tempo desde o �ltimo inimigo gerado.
    private int enemiesAlive; // N�mero de Inimigos vivos
    private int enemiesLeftToSpawn; // N�mero de inimigos restantes a serem gerados.
    private float eps; // Inimigos por segundo (enemies per second).
    private bool isSpawning = false; // Indica se os inimigos est�o sendo gerados.
    private void Awake()     // M�todo chamado quando o objeto � inicializado.

    {
        onEnemyDestroy.AddListener(EnemyDestroyed); // Adiciona o listener para o evento de destrui��o de inimigos.
    }
    private void Start()     // M�todo chamado no in�cio do jogo.

    {
        StartCoroutine(StartWave()); // Inicia a primeira onda de inimigos.
    }
    private void Update()     // M�todo chamado a cada quadro.

    {
        if (!isSpawning) return;         // Se n�o estiver gerando inimigos, sai do m�todo.

        timeSinceLastSpawn += Time.deltaTime;        // Atualiza o tempo desde o �ltimo inimigo gerado.

        if (timeSinceLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0)        // Verifica se � hora de gerar um novo inimigo.

        {
            SpawnEnemy(); // Gera um inimigo.
            enemiesLeftToSpawn--; // Decrementa o n�mero de inimigos restantes a serem gerados.
            enemiesAlive++; // Incrementa o n�mero de inimigos vivos.
            timeSinceLastSpawn = 0f; // Reseta o temporizador.
        }
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)         // Verifica se todos os inimigos foram destru�dos.

        {
            EndWave(); // Termina a onda atual.
        }
    }
    private void EnemyDestroyed()     // M�todo chamado quando um inimigo � destru�do.

    {
        enemiesAlive--; // Decrementa o n�mero de inimigos vivos.
    }
    private IEnumerator StartWave()     //   inicia uma nova onda de inimigos.

    {
        yield return new WaitForSeconds(timeBetweenWaves);// Espera pelo tempo entre ondas.
        isSpawning = true; // Marca que os inimigos est�o sendo gerados.
        enemiesLeftToSpawn = EnemiesPerWave(); // Calcula quantos inimigos ser�o gerados nesta onda.
        eps = EnemiesPerSecond(); // Calcula a taxa de gera��o de inimigos por segundo.
    }
    private void EndWave()     // M�todo para terminar a onda atual e iniciar uma nova.

    {
        isSpawning = false; // Para a gera��o de inimigos.
        timeSinceLastSpawn = 0f; // Reseta o temporizador de gera��o.
        currentWave++; // Avan�a para a pr�xima onda.
        StartCoroutine(StartWave()); // Inicia a pr�xima onda.
    }
    private void SpawnEnemy()     // M�todo para gerar um inimigo.

    {
        int index = Random.Range(0, enemyPrefabs.Length); // Seleciona um prefab aleat�rio de inimigo.
        GameObject prefabToSpawn = enemyPrefabs[index]; // Obt�m o prefab escolhido.
        Instantiate(prefabToSpawn, LevelManager.instance.startPoint.position, Quaternion.identity); // Instancia o inimigo na posi��o inicial.
    }
    private int EnemiesPerWave()     // M�todo para calcular o n�mero de inimigos por onda.

    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor)); // Aplica a escala de dificuldade.
    }
    private float EnemiesPerSecond()     // M�todo para calcular a taxa de inimigos gerados por segundo.

    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0f,enemiesPerSecondCap); // Aplica limite m�ximo.
    }


}
