using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;
    public GameObject ballPrefab;
    public GameObject[] powerUpPrefabs;

    // Intervallo di spawn dei power-up in secondi
    public float powerUpSpawnInterval = 10f;

    // Dimensioni del campo di gioco per spawn dei power-up
    public float fieldWidth = 8f;
    public float fieldHeight = 4f;

    // Margine dal bordo del campo per evitare spawn fuori limite
    public float margin = 1f;

    // Timer interno per controllare lo spawn dei power-up
    private float powerUpTimer = 0f;

    private void Awake()
    {
        // Inizializza il singleton
        instance = this;
    }

    private void Start()
    {
        SpawnBall();
    }

    private void Update()
    {
        // Se il gioco è finito, non spawnare nulla
        if (GameManager.instance.isGameOver)
            return;

        // Aggiorna il timer dei power-up
        powerUpTimer += Time.deltaTime;

        // Se è passato l'intervallo, spawn un nuovo power-up
        if (powerUpTimer >= powerUpSpawnInterval)
        {
            SpawnPowerUp();
            powerUpTimer = 0f; // reset timer
        }
    }

    // -------------------------
    // Metodo per spawnare una palla
    // -------------------------
    public void SpawnBall()
    {
        if (GameManager.instance.isGameOver)
            return;

        // Posizione casuale sull'asse Y tra -3 e 3
        Vector3 spawnPos = new Vector3(0, Random.Range(-3f, 3f), 0);

        // Istanzia la palla
        Instantiate(ballPrefab, spawnPos, Quaternion.identity);
    }

    // -------------------------
    // Metodo per spawnare un power-up
    // -------------------------
    private void SpawnPowerUp()
    {
        // Se non ci sono power-up assegnati, esci
        if (powerUpPrefabs.Length == 0)
            return;

        // Scegli casualmente quale power-up spawnare
        int index = Random.Range(0, powerUpPrefabs.Length);

        // Calcola posizione casuale all'interno del campo, rispettando i margini
        float x = Random.Range(-fieldWidth + margin, fieldWidth - margin);
        float y = Random.Range(-fieldHeight + margin, fieldHeight - margin);

        // Istanzia il power-up selezionato
        Instantiate(powerUpPrefabs[index], new Vector2(x, y), Quaternion.identity);
    }
}
