using UnityEngine;

public class DanoConstante : MonoBehaviour
{
    public float valorDano;
    private bool estaTomandoDano;
    private VidaJogador vidaJogador;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaJogador = FindFirstObjectByType<VidaJogador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estaTomandoDano) { 
            vidaJogador.ReceberDano(valorDano * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaTomandoDano = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaTomandoDano = false;
        }
    }
}
