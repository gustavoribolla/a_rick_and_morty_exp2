using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI tempoTexto;
    public TextMeshProUGUI tempoFinalTexto;
    public bool contando = true;

    private float tempoAtual = 0f;

    void Update()
    {
        if (contando)
        {
            tempoAtual += Time.deltaTime;
            AtualizarTexto();
        }
    }

    void AtualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tempoAtual / 60f);
        int segundos = Mathf.FloorToInt(tempoAtual % 60f);
        tempoTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void PararContagem()
    {
        contando = false;
        if (tempoFinalTexto != null)
        {
            int minutos = Mathf.FloorToInt(tempoAtual / 60f);
            int segundos = Mathf.FloorToInt(tempoAtual % 60f);
            tempoFinalTexto.text = $"Tempo Final: {minutos:00}:{segundos:00}";
        }
    }

    public float GetTempo()
    {
        return tempoAtual;
    }
}
