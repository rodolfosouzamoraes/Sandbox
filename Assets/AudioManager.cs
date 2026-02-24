using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Variável para armazenar o AudioSource dos efeitos sonoros
    public AudioSource audioEfeitos;

    // Método para tocar um efeito sonoro específico
    public void TocarEfeito(AudioClip clip)
    {
        audioEfeitos.PlayOneShot(clip);
    }
}
