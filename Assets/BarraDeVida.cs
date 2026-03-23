using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;

    public void AtualizarBarra(float vidaAtual, float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
        slider.value = vidaAtual;
    }
}



