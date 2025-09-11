using UnityEngine;

public enum PowerUpType { SlowTime, DoubleBall }

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se l'oggetto che collide non è una palla, non fare nulla
        if (!other.CompareTag("Ball"))
            return;

        // Controlla il tipo di power-up
        if (powerUpType == PowerUpType.SlowTime)
        {
            // Rallenta il tempo usando il GameManager (scala 0.5, durata 5 secondi reali)
            GameManager.instance.SlowTime(0.5f, 5f);
        }
        else if (powerUpType == PowerUpType.DoubleBall)
        {
            // Ottieni lo script della palla che ha colpito il power-up
            BallScript ballScript = other.GetComponent<BallScript>();
            if (ballScript != null)
                // Genera un clone della palla
                ballScript.SpawnCloneBall();
        }

        // Distruggi il power-up dopo l'attivazione
        Destroy(gameObject);
    }
}
