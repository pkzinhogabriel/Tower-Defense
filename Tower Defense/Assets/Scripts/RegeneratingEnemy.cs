using System.Collections;
using UnityEngine;

public class RegeneratingEnemy : Health // Classe RegeneratingEnemy: Representa um inimigo que regenera sa�de ao longo do tempo, herdando de Health.

{
    [SerializeField] private float regenerationRate = 1f;   // Taxa de regenera��o de sa�de por segundo.
    [SerializeField] private float maxHitPoints = 5f;   // M�ximo de pontos de vida que o inimigo pode ter.

    private void Start()     // M�todo chamado no in�cio do jogo. Inicializa os pontos de vida e inicia o processo de regenera��o.

    {
        hitPoints = maxHitPoints;   // Define os pontos de vida iniciais como o m�ximo.
        StartCoroutine(RegenerateHealth());  // Inicia a corrotina para regenerar sa�de.
    }

    private IEnumerator RegenerateHealth()     // Corrotina que lida com a regenera��o da sa�de do inimigo.

    {
        while (!isDestroyed)         // Enquanto o inimigo n�o estiver destru�do, continua a regenerar sa�de.

        {
            if (hitPoints < maxHitPoints)             // Se os pontos de vida estiverem abaixo do m�ximo, aumenta os pontos de vida.

            {
                hitPoints += regenerationRate * Time.deltaTime;  // Regenera sa�de com base na taxa e no tempo.
                hitPoints = Mathf.Min(hitPoints, maxHitPoints);   // Garante que os pontos de vida n�o ultrapassem o m�ximo.
            }
            yield return null;  // Espera o pr�ximo quadro antes de continuar.
        }
    }

    public override void TakeDamage(float dmg)  // M�todo chamado quando o inimigo recebe dano.
    {
        base.TakeDamage(dmg);  // Chama o m�todo TakeDamage da classe base.
    }
}
