using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public Cronometro cronometro;
    public GameObject textoTempo;
    public TextMeshProUGUI tempoFinalTexto;

    public AudioClip somVitoria;
    public AudioClip somDerrota;
    private AudioSource audioSource;

    private bool fimDeJogo = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!fimDeJogo && GameController.gameOver)
        {
            Vitoria();
        }
    }

    public void GameOver()
    {
        if (fimDeJogo) return;

        fimDeJogo = true;
        cronometro.PararContagem();
        textoTempo.SetActive(false);
        tempoFinalTexto.text = "GAME OVER";
        endGamePanel.SetActive(true);

        if (somDerrota != null)
            audioSource.PlayOneShot(somDerrota);
    }

    public void Vitoria()
    {
        if (fimDeJogo) return;

        fimDeJogo = true;
        cronometro.PararContagem();
        textoTempo.SetActive(false);

        float tempo = cronometro.GetTempo();
        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);

        tempoFinalTexto.text = $"Tempo: {minutos:00}:{segundos:00}";
        endGamePanel.SetActive(true);

        if (somVitoria != null)
            audioSource.PlayOneShot(somVitoria);
    }
}
