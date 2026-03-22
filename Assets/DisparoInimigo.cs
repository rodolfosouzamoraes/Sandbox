using UnityEngine;

public class DisparoInimigo : MonoBehaviour
{
    public GameObject prefabProjetil;
    public Transform pontoDeDisparo;
    public float intervaloDisparo = 0.5f;
    private float tempoProximoDisparo = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= tempoProximoDisparo)
        {
            Atirar();
            tempoProximoDisparo = Time.time + intervaloDisparo;
        }
    }

    private void Atirar()
    {
        GameObject novoProjetil = Instantiate(prefabProjetil, 
            pontoDeDisparo.position, 
            Quaternion.identity
        );

        float direcao = transform.localScale.x > 0 ? 1 : -1;
        novoProjetil.GetComponent<Projetil>().ConfigurarDirecao(direcao);
    }
}
