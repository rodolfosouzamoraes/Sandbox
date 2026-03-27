using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public TextMeshProUGUI txtVida;
    private float vidaAtual;

    public void AtualizarBarra(float vidaAtual, float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
        this.vidaAtual = vidaAtual;       
    }

    private void Update()
    {
        slider.value = Mathf.Lerp(slider.value, vidaAtual, Time.deltaTime*20);
        slider.value = slider.value < 0.01f ? 0 : slider.value; 
        slider.value = slider.value > slider.maxValue - 0.01f ? slider.maxValue : slider.value;
        AtualizarStatusBarra();
    }

    private void AtualizarStatusBarra()
    {
        if (slider.value > slider.maxValue * 0.5f)
        {
            fillImage.color = Color.green;
        }
        else if (slider.value > slider.maxValue * 0.25f)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
        }

        AtualizarTextoVida();
    }

    private void AtualizarTextoVida()
    {
        txtVida.text = $"{Mathf.CeilToInt(slider.value)}/{slider.maxValue}";
    }
}



