using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour // Classe Bullet: Representa um proj�til que causa dano a inimigos.

{
    [SerializeField] private Rigidbody2D rb;    // Componente Rigidbody2D usado para movimentar o proj�til.

    [SerializeField] private float bulletSpeed = 5f;    // Velocidade do proj�til.

    [SerializeField] private int bulletDamage = 1;    // Dano causado pelo proj�til ao colidir com um inimigo.

    private Transform target;    // Refer�ncia ao alvo que o proj�til deve seguir.

    public void SetTarget(Transform _target)    // M�todo para definir o alvo do proj�til.

    {
        target = _target;// Define o alvo do proj�til.
    }
    private void FixedUpdate()    // M�todo chamado a cada quadro de f�sica.

    {
        if (!target) return;        // Se n�o houver um alvo, sai do m�todo.

        Vector2 direction = (target.position - transform.position).normalized;        // Calcula a dire��o do proj�til em dire��o ao alvo e normaliza a dire��o.

        rb.velocity = direction * bulletSpeed;        // Define a velocidade do Rigidbody2D para mover o proj�til em dire��o ao alvo.

    }
    private void OnCollisionEnter2D(Collision2D other)     // M�todo chamado quando o proj�til colide com outro objeto.

    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);         // Aplica dano ao componente de sa�de do objeto colidido.

        Destroy(gameObject);        // Destr�i o objeto do proj�til ap�s a colis�o.

    }
}
