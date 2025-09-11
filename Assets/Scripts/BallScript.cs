using UnityEngine;

public class BallScript : MonoBehaviour
{
    private float speed = 11f;
    private bool isClone = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LaunchBall();
    }

    // Imposta la velocità iniziale della palla con direzione casuale
    private void LaunchBall()
    {
        float xVelocity;

        // Determina casualmente se la palla va a destra o sinistra
        if (Random.value >= 0.5f)
            xVelocity = 1f;
        else
            xVelocity = -1f;

        // Velocità verticale casuale tra -1 e 1
        float yVelocity = Random.Range(-1f, 1f);

        // Applica la velocità al Rigidbody
        rb.velocity = new Vector2(xVelocity * speed, yVelocity * speed);
    }

    private void Update()
    {
        // Controlla se la palla ha superato i limiti del campo
        CheckBounds();
    }

    // Controlla se la palla è uscita dai bordi e aggiorna il punteggio
    private void CheckBounds()
    {
        float bound = 9.4f; // Limite del campo in X

        // Palla a sinistra → punto per il giocatore 2
        if (transform.position.x <= -bound)
        {
            ScoreManager.instance.AddScore(2);
            DestroyBall();
        }
        // Palla a destra → punto per il giocatore 1
        else if (transform.position.x >= bound)
        {
            ScoreManager.instance.AddScore(1);
            DestroyBall();
        }
    }

    // Distrugge la palla e gestisce eventuale spawn di nuova palla
    private void DestroyBall()
    {
        // Se non è un clone, spawn di una nuova palla
        if (!isClone)
            SpawnerManager.instance.SpawnBall();

        // Controllo Game Over: se qualcuno raggiunge 5 punti
        if (ScoreManager.instance.Player1Score >= 5 || ScoreManager.instance.Player2Score >= 5)
            GameManager.instance.GameOver();

        // Distruggi questo oggetto palla
        Destroy(gameObject);
    }

    // Crea una copia della palla (usata dal power-up DoubleBall)
    public void SpawnCloneBall()
    {
        // Istanzia una nuova palla alla stessa posizione
        GameObject clone = Instantiate(SpawnerManager.instance.ballPrefab, transform.position, Quaternion.identity);

        // Segna la nuova palla come clone
        BallScript cloneScript = clone.GetComponent<BallScript>();
        cloneScript.isClone = true;

        // Copia la velocità della palla originale con una variazione casuale in Y
        Rigidbody2D rbClone = clone.GetComponent<Rigidbody2D>();
        Vector2 newVel = rb.velocity;
        newVel.y += Random.Range(-1f, 1f);
        rbClone.velocity = newVel;
    }
}
