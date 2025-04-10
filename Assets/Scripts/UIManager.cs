using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public Cronometro cronometro;
    public GameObject textoTempo;

    private bool fimDeJogo = false;

    void FixedUpdate()
    {
        if (!fimDeJogo && GameController.gameOver)
        {
            fimDeJogo = true;

            cronometro.PararContagem(); 
            endGamePanel.SetActive(true);
            textoTempo.SetActive(false);
        }
    }
}
