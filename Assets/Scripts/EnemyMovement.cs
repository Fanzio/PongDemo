using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 5f;
    private float yRange = 3.8f;

    private Transform ball;

    private void Update()
    {
        // Se non abbiamo ancora un riferimento alla palla
        if (ball == null)
        {
            // Cerca un GameObject con tag "Ball"
            GameObject b = GameObject.FindWithTag("Ball");
            if (b != null)
                ball = b.transform; // assegna il Transform della palla
            else
                return; // se non c'è la palla, esci dal metodo
        }

        // Ottieni la posizione corrente dell'avversario
        Vector3 pos = transform.position;

        // Muovi l'avversario verso l'alto o il basso in base alla posizione della palla
        if (ball.position.y > pos.y)
            pos.y += speed * Time.deltaTime; // sposta verso l'alto
        else if (ball.position.y < pos.y)
            pos.y -= speed * Time.deltaTime; // sposta verso il basso

        // Limita il movimento verticale all'interno del campo
        if (pos.y > yRange)
            pos.y = yRange;
        else if (pos.y < -yRange)
            pos.y = -yRange;

        // Applica la nuova posizione all'avversario
        transform.position = pos;
    }
}
