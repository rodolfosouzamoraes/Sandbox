using UnityEngine;

public class Moeda : MonoBehaviour
{
    public int valor = 1; // Valor da moeda
    public AudioClip somDeColeta; // Som a ser tocado quando a moeda for coletada

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
                // Toca o som de coleta
                FindFirstObjectByType<AudioManager>().TocarEfeito(somDeColeta);
                pontuacao.AdicionarPontos(valor);
            }

            // Remove a moeda da cena
            Destroy(gameObject);
        }
    }
}
