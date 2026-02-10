using UnityEngine;

public class MovimentoJogador2D : MonoBehaviour
{
    // ===== MOVIMENTO =====
    public float velocidade = 5f;
    private float direcao;

    // ===== PULO =====
    public float forcaPulo = 10f;
    private bool estaNoChao;

    // ===== DASH =====
    public float forcaDash = 12f;
    private bool podeDarDash = true;

    // ===== RAYCAST DO CHÃO =====
    public Transform pontoDoChao;
    public float distanciaDoChao = 0.2f;
    public LayerMask camadaDoChao;

    // ===== COMPONENTES =====
    private Rigidbody2D corpo;

    void Start()
    {
        // Pega o Rigidbody2D do jogador
        corpo = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lê a direção horizontal (A/D ou setas)
        direcao = Input.GetAxisRaw("Horizontal");

        // Verifica se está no chão usando Raycast
        VerificarChao();

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            corpo.linearVelocity = new Vector2(corpo.linearVelocity.x, forcaPulo);
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && podeDarDash)
        {
            corpo.linearVelocity = new Vector2(direcao * forcaDash, corpo.linearVelocity.y);
            podeDarDash = false;
        }
    }

    void FixedUpdate()
    {
        // Movimento horizontal
        corpo.linearVelocity = new Vector2(direcao * velocidade, corpo.linearVelocity.y);
    }

    void VerificarChao()
    {
        // Lança um raio para baixo a partir do ponto do chão
        RaycastHit2D hit = Physics2D.Raycast(
            pontoDoChao.position,     // Ponto de origem
            Vector2.down,             // Direção (para baixo)
            distanciaDoChao,          // Distância do raio
            camadaDoChao              // Camada considerada como chão
        );

        // Se o raio encostou em algo da camada do chão
        if (hit.collider != null)
        {
            estaNoChao = true;
            podeDarDash = true; // Libera o dash ao tocar o chão
        }
        else
        {
            estaNoChao = false;
        }
    }

    void OnDrawGizmos()
    {
        // Desenha o Raycast no editor (ajuda a visualizar)
        if (pontoDoChao != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                pontoDoChao.position,
                pontoDoChao.position + Vector3.down * distanciaDoChao
            );
        }
    }
}
