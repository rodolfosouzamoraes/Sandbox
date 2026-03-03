using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCena : MonoBehaviour
{
    // Singleton para garantir que haja apenas um GerenciadorDeCena em toda a aplicação
    public static GerenciadorDeCena Instance;
    private void Awake()
    {
        // Verificar se já existe uma instância do GerenciadorDeCena
        if (Instance == null)
        {
            // Se não existir, referenciar a instância atual
            Instance = this;
            // Impedir que o GerenciadorDeCena seja destruído ao carregar uma nova cena
            DontDestroyOnLoad(gameObject);
            return;
        }
        // Se já existir uma instância, destruir o novo script para garantir que haja apenas um
        Destroy(this);
    }
    public void CarregarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void ReiniciarCenaAtual()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CarregarProximaCena()
    {
        // Contar o número total de cenas no build settings
        var totalCenas = SceneManager.sceneCountInBuildSettings;

        // Verificar se a próxima cena existe, caso contrário, voltar para o menu principal
        if (SceneManager.GetActiveScene().buildIndex + 1 >= totalCenas)
        {
            SceneManager.LoadScene("MenuPrincipal");
            return;
        }

        // Carregar a próxima cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

