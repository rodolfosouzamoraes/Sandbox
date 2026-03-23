using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaAtual;
    private BarraDeVida barraDeVida; // Referência ao script da UI

    private void Start()
    {
        vidaAtual = vidaMaxima; // Inicializa a vida atual com a vida máxima
        barraDeVida = FindAnyObjectByType<BarraDeVida>(); // Encontra o script da UI na cena
        barraDeVida.AtualizarBarra(vidaAtual, vidaMaxima); // Atualiza a barra de vida na UI
    }
    public void ReceberDano(float dano)
    {
        vidaAtual -= dano;
        if (vidaAtual <= 0){
            vidaAtual = 0;
            Debug.Log("Jogador morreu!");
        }
        barraDeVida.AtualizarBarra(vidaAtual, vidaMaxima);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReceberDano(10);
        }
    }
}


