using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidadeBase = 2f;
    public float velocidadeMaxima = 6f;
    public float aumentoPorSegundo = 0.2f;
    public float height = 3f;

    private Vector3 startPosition;
    private bool subindo = true;

    private float velocidadeAtual;
    private Cronometro cronometro;

    void Start()
    {
        startPosition = transform.position;
        cronometro = FindObjectOfType<Cronometro>();
        velocidadeAtual = velocidadeBase;
    }

    void Update()
    {
        AtualizarVelocidade();

        float movimento = velocidadeAtual * Time.deltaTime;

        if (subindo)
        {
            transform.Translate(Vector2.up * movimento);
            if (transform.position.y >= startPosition.y + height)
                subindo = false;
        }
        else
        {
            transform.Translate(Vector2.down * movimento);
            if (transform.position.y <= startPosition.y - height)
                subindo = true;
        }
    }

    void AtualizarVelocidade()
    {
        if (cronometro != null)
        {
            float tempo = cronometro.GetTempo();
            velocidadeAtual = Mathf.Min(velocidadeBase + (tempo * aumentoPorSegundo), velocidadeMaxima);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("O inimigo matou o jogador!");

            UIManager ui = FindFirstObjectByType<UIManager>();
            if (ui != null)
            {
                ui.GameOver();
            }
        }
    }
}
