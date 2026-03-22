using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade = 10f; // Velocidade do projétil
    public float tempoDeVida = 3f; // Tempo de vida do projétil em segundos

    public Rigidbody2D rb;
    private float direcao;

    void Start()
    {
        // Destroi o projétil após o tempo de vida
        Destroy(gameObject, tempoDeVida); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroi o projétil ao colidir com qualquer objeto
        Destroy(gameObject); 
    }

    public void ConfigurarDirecao(float direcaoJogador)
    {
        direcao = direcaoJogador;
        // Move o projétil na direção do jogador
        rb.linearVelocity = new Vector2(direcao * velocidade, 0f); 
    }
}
