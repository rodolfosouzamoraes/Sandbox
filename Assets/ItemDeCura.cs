using UnityEngine;

public class ItemDeCura : MonoBehaviour
{
    private VidaJogador vidaJogador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaJogador = FindFirstObjectByType<VidaJogador>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            vidaJogador.RegenerarVida();
            Destroy(gameObject);
        }
    }
}


