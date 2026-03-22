using TMPro;
using UnityEngine;

public class Projeteis : MonoBehaviour
{
    public TextMeshProUGUI txtProjeteis;

    public void AtualizarProjeteis(int quantidade)
    {
        txtProjeteis.text = quantidade.ToString();
    }
}
