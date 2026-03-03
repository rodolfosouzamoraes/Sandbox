using UnityEngine;

public class ItemFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GerenciadorDeCena.Instance.CarregarProximaCena();
        }
    }
}
