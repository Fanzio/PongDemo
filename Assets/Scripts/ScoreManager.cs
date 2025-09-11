using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text player1Text;
    public TMP_Text player2Text;

    private int player1Score = 0;
    private int player2Score = 0;
    private void Awake()
    {
        instance = this;

        UpdateUI();
    }

    // Aggiunge un punto al giocatore specificato
    public void AddScore(int player)
    {
        if (player == 1)
            player1Score++;
        else if (player == 2)
            player2Score++;

        UpdateUI();
    }

    // Aggiorna l'UI dei punteggi
    private void UpdateUI()
    {
        player1Text.text = player1Score.ToString();
        player2Text.text = player2Score.ToString();
    }

    // Resetta entrambi i punteggi a zero
    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateUI();
    }

    // Proprietà pubbliche per leggere i punteggi senza poterli modificare direttamente
    public int Player1Score { get { return player1Score; } }
    public int Player2Score { get { return player2Score; } }
}
