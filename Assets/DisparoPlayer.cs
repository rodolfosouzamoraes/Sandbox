using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    public GameObject prefabProjetil;
    public Transform pontoDeDisparo;
    public float intervaloDisparo = 0.5f;
    private float tempoProximoDisparo = 0;
    
    public AudioClip somDisparo;
    private AudioManager audioMng;

    public int maximoProjetil = 20;
    private int projetilAtual;
    private Projeteis projeteisUI;
    private void Start()
    {
        audioMng = FindAnyObjectByType<AudioManager>();
        projeteisUI = FindAnyObjectByType<Projeteis>();
        projetilAtual = maximoProjetil; // Inicializa a quantidade de projéteis disponíveis
        projeteisUI.AtualizarProjeteis(projetilAtual); // Atualiza a UI de projéteis
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && projetilAtual > 0)
        {
            if (Time.time >= tempoProximoDisparo) { // Verifica se o tempo para o próximo disparo já passou
                Atirar();
                tempoProximoDisparo = Time.time + intervaloDisparo; // Define o tempo para o próximo disparo
            }
        }
    }

    private void Atirar()
    {
        GameObject novoProjetil = Instantiate(prefabProjetil, pontoDeDisparo.position, Quaternion.identity);

        float direcao = transform.localScale.x > 0 ? 1 : -1; // Determina a direção com base na escala do jogador

        novoProjetil.GetComponent<Projetil>().ConfigurarDirecao(direcao);

        // Toca o som de disparo
        audioMng.TocarEfeito(somDisparo);

        projetilAtual--; // Diminui a quantidade de projéteis disponíveis
        projeteisUI.AtualizarProjeteis(projetilAtual);
    }
}
