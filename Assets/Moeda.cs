using UnityEngine;

public class Moeda : MonoBehaviour
{
    public int valor = 1; // Valor da moeda

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Verifica se quem encostou foi o Player
        if (collider.CompareTag("Player"))
        {
            // Procura o script de pontuação na cena
            Pontuacao pontuacao = FindFirstObjectByType<Pontuacao>();

            // Se encontrou o script, soma os pontos
            if (pontuacao != null)
            {
                pontuacao.AdicionarPontos(valor);
            }

            // Remove a moeda da cena
            Destroy(gameObject);
        }
    }
}
