using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretFire : Turret // Classe TurretFire: Representa uma torre que causa dano por queimadura a inimigos.

{
    [SerializeField] private float burnDuration = 3f;       // Dura��o da queimadura em segundos.

    [SerializeField] private float burnDamagePerSecond = 1f;     // Dano causado por segundo pela queimadura.

    public override void Atacar()     // M�todo chamado para atacar o alvo.

    {
        if (target != null)         // Verifica se h� um alvo definido.

        {

            Health enemyHealth = target.GetComponent<Health>();             // Obt�m o componente de sa�de do inimigo.


            if (enemyHealth != null)             // Se o inimigo tiver um componente de sa�de, inicia a aplica��o de dano por queimadura.

            {

                StartCoroutine(ApplyBurnDamage(enemyHealth));
            }
        }
    }
    private IEnumerator ApplyBurnDamage(Health enemyHealth)     // Corrotina que aplica dano por queimadura ao inimigo ao longo do tempo.

    {
        float elapsedTime = 0f; // Tempo decorrido.

        while (elapsedTime < burnDuration) // Enquanto o tempo decorrido for menor que a dura��o da queimadura.
        {
            enemyHealth.TakeDamage(burnDamagePerSecond * Time.deltaTime);    // Aplica dano ao inimigo baseado no dano por segundo.
            elapsedTime += Time.deltaTime; // Atualiza o tempo decorrido.
            yield return null;   // Espera o pr�ximo quadro antes de continuar.
        }
    }

    
    protected override void Shoot()     // M�todo protegido para atirar um proj�til.

    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);         // Instancia o objeto da bala na posi��o do ponto de disparo.

        // Obt�m o script da bala e define o alvo.

        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);

        Atacar();          // Chama o m�todo de ataque para aplicar queimadura.

    }
}

