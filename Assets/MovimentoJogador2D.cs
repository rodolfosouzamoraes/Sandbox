using UnityEngine;

public class MovimentoJogador2D : MonoBehaviour
{
    // ===== MOVIMENTO =====
    public float velocidade = 5f;
    private float direcao;

    // ===== PULO =====
    public float forcaPulo = 10f;
    private bool estaNoChao;
    private bool puloDuplo; // Marca se o pulo duplo já foi usado
    private bool emSuperficieQueNaoPodePular; // Marca se está em superfície que não permite pular

    // ===== DASH =====
    public float forcaDash = 12f;
    private bool podeDarDash = true;
    private bool estaDandoDash;

    // ===== RAYCAST DO CHÃO =====
    public Transform pontoDoChao;
    public float distanciaDoChao = 0.2f;
    public LayerMask camadaDoChao;

    // ===== COMPONENTES =====
    private Rigidbody2D corpo;

    // ===== LIMITES DO MAPA =====
    public BoxCollider2D limiteMapa;

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
        // Ele não está no chão, mas ainda não usou o pulo duplo e a superfície permite pular
        else if (Input.GetKeyDown(KeyCode.Space) && estaNoChao == false && puloDuplo == false && emSuperficieQueNaoPodePular == false)
        {
            corpo.linearVelocity = new Vector2(corpo.linearVelocity.x, forcaPulo);
            puloDuplo = true; // Marca que o pulo duplo foi usado
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && podeDarDash)
        {
            corpo.linearVelocity = new Vector2(direcao * forcaDash, 0f);
            estaDandoDash = true;
            podeDarDash = false;

            Invoke("PararDash", 0.15f); // Tempo curto do dash
        }
    }

    void PararDash()
    {
        estaDandoDash = false;
    }

    void FixedUpdate()
    {
        // Se estiver dando dash, não aplica movimento normal
        if (estaDandoDash) return;

        // Movimento horizontal
        corpo.linearVelocity = new Vector2(direcao * velocidade, corpo.linearVelocity.y);

        // Bloqueio por limite
        corpo.linearVelocity = LimitarJogadorAoMapa(corpo.linearVelocity);
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
            // Só considera chão se a TAG for "Chão"
            if (hit.collider.CompareTag("Chao"))
            {
                estaNoChao = true;
                podeDarDash = true;
                puloDuplo = false;
                emSuperficieQueNaoPodePular = false;
            }
            else
            {
                // Encostou em algo que não é "Chão"
                estaNoChao = false;
                emSuperficieQueNaoPodePular = true;
            }
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

    // Limita o jogador dentro dos limites do mapa, considerando o tamanho do collider
    Vector2 LimitarJogadorAoMapa(Vector2 vel)
    {
        // Obtém os limites do mapa e do jogador
        Bounds boundsMapa = limiteMapa.bounds;
        // O bounds do jogador é baseado no collider, então pega o collider do jogador
        Bounds boundsPlayer = GetComponent<Collider2D>().bounds;
        // Posição atual do jogador
        Vector2 posicaoAtualPlayer = corpo.position;

        // Limites reais do player
        float minX = boundsMapa.min.x + boundsPlayer.extents.x;
        float maxX = boundsMapa.max.x - boundsPlayer.extents.x;
        float minY = boundsMapa.min.y + boundsPlayer.extents.y;
        float maxY = boundsMapa.max.y - boundsPlayer.extents.y;

        // Tentativa de sair no eixo X
        if ((posicaoAtualPlayer.x <= minX && vel.x < 0) || (posicaoAtualPlayer.x >= maxX && vel.x > 0))
            vel.x = 0;

        // Tentativa de sair no eixo Y
        if ((posicaoAtualPlayer.y <= minY && vel.y < 0) || (posicaoAtualPlayer.y >= maxY && vel.y > 0))
            vel.y = 0;

        return vel;
    }
}
