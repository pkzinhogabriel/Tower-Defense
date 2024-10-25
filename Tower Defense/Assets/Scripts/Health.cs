using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour // Classe Health: Gerencia os pontos de vida e a destrui��o de um objeto.

{
    [SerializeField] protected float hitPoints = 2;    // Pontos de vida iniciais do objeto. 

    protected bool isDestroyed = false;    // Indica se o objeto j� foi destru�do.

    public virtual void TakeDamage(float dmg)    // M�todo virtual para aplicar dano ao objeto.

    {
        hitPoints -= dmg;// Subtrai o dano dos pontos de vida.
        if (hitPoints <= 0 && !isDestroyed)        // Verifica se os pontos de vida chegaram a zero ou menos e se o objeto n�o foi destru�do.

        {
            EnemySpawner.onEnemyDestroy.Invoke();// Notifica o spawner que um inimigo foi destru�do.
            isDestroyed = true;// Marca o objeto como destru�do.
            Destroy(gameObject);// Destr�i o objeto do jogo.
        }
    }
}
