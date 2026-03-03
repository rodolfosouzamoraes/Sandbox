using UnityEngine;

public class ZonaDaMorte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // Reiniciar a cena atual
            GerenciadorDeCena.Instance.ReiniciarCenaAtual();
        }
    }
}
