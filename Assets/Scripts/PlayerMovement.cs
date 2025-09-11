using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10f;
    private float yRange = 4f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Legge l'input verticale (freccia su/giù o W/S)
        float verticalInput = Input.GetAxis("Vertical");

        // Imposta la velocità verticale del Rigidbody
        rb.velocity = Vector2.up * verticalInput * speed;

        // Ottieni la posizione Y attuale
        float clampedY = transform.position.y;

        // Limita il movimento verticale tra -yRange e yRange
        if (clampedY > yRange)
            clampedY = yRange;
        else if (clampedY < -yRange)
            clampedY = -yRange;

        // Applica la posizione limitata al giocatore
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
