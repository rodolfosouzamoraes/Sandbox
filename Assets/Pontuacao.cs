using TMPro;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public int pontos; // Total de pontos
    public TextMeshProUGUI textoPontos; // Texto da UI

    void Start()
    {
        AtualizarTexto(); // Atualiza a UI ao iniciar
    }

    public void AdicionarPontos(int valor)
    {
        pontos += valor; // Soma os pontos
        AtualizarTexto(); // Atualiza a UI
    }

    void AtualizarTexto()
    {
        textoPontos.text = "Moedas: " + pontos;
    }
}
