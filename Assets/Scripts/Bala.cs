using UnityEngine;

public class Bala : MonoBehaviour
{
    int daño = 1;
    public float velocidad = 1f;
    public float tiempoDeVida = 3f;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            otro.GetComponent<Health>().TomarDaño(daño);	
            Debug.Log("¡El jugador ha sido impactado!");
            Destroy(gameObject);
        }
    }
}
