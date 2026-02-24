using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform alvo;
    public float suavidade = 5f;

    // Limites da câmera
    public float limiteMinX;
    public float limiteMaxX;
    public float limiteMinY;
    public float limiteMaxY;

    // Referência ao BoxCollider2D do mapa para calcular os limites
    public BoxCollider2D limiteMapa;

    void Start()
    {
        Bounds limites = limiteMapa.bounds;

        // Calcula os limites considerando o tamanho da câmera
        float camAltura = Camera.main.orthographicSize;
        float camLargura = camAltura * Camera.main.aspect;

        // Ajusta os limites para que a câmera não ultrapasse as bordas do mapa
        limiteMinX = limites.min.x + camLargura;
        limiteMaxX = limites.max.x - camLargura;
        limiteMinY = limites.min.y + camAltura;
        limiteMaxY = limites.max.y - camAltura;
    }

    void LateUpdate()
    {
        Vector3 posicaoDesejada = new Vector3(
            alvo.position.x,
            alvo.position.y,
            transform.position.z
        );

        // Suavização
        Vector3 posicaoSuavizada = Vector3.Lerp(
            transform.position,
            posicaoDesejada,
            suavidade * Time.deltaTime
        );

        // Aplicando limites
        float posicaoX = Mathf.Clamp(posicaoSuavizada.x, limiteMinX, limiteMaxX);
        float posicaoY = Mathf.Clamp(posicaoSuavizada.y, limiteMinY, limiteMaxY);

        transform.position = new Vector3(posicaoX, posicaoY, transform.position.z);
    }
}




