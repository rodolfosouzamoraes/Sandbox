using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCena : MonoBehaviour
{
    // Método para carregar cena pelo nome
    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    // Método opcional para fechar o jogo
    public void SairDoJogo()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}





