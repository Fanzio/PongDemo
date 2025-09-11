using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver { get; private set; } = false;

    public GameObject gameOverCanvas;
    private Coroutine slowCoroutine = null;

    private void Awake()
    {
        instance = this;
    }

    // Metodo chiamato quando il gioco termina
    public void GameOver()
    {
        isGameOver = true;

        // Blocca il gioco
        Time.timeScale = 0f;

        // Mostra il canvas Game Over se assegnato
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);
    }

    // Riavvia il gioco
    public void RestartGame()
    {
        // Riporta la velocità normale
        Time.timeScale = 1f;

        // Resetta i punteggi
        ScoreManager.instance.ResetScore();

        // Ricarica la scena attuale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Rallenta il tempo su una scala specifica per una durata reale
    public void SlowTime(float scale, float duration)
    {
        // Se c'è già un rallentamento in corso, fermalo
        if (slowCoroutine != null)
            StopCoroutine(slowCoroutine);

        // Avvia una nuova Coroutine per rallentare il tempo
        slowCoroutine = StartCoroutine(SlowTimeRoutine(scale, duration));
    }

    // Coroutine che gestisce il rallentamento del tempo
    private IEnumerator SlowTimeRoutine(float scale, float duration)
    {
        // Imposta la scala temporale
        Time.timeScale = scale;

        // Attende la durata in secondi reali (ignora Time.timeScale)
        yield return new WaitForSecondsRealtime(duration);

        // Se il gioco non è finito, ripristina la velocità normale
        if (!isGameOver)
            Time.timeScale = 1f;

        // Rimuove il riferimento alla Coroutine
        slowCoroutine = null;
    }
}
