using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    public float velocidad = 15f;
    public float tiempoDeVida = 3f;
    public int daño = 2; 

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
        if (otro.CompareTag("Alien"))
        {
            otro.GetComponent<Health>().TomarDaño(daño);
            Debug.Log("¡Impacto al enemigo!");
            Destroy(gameObject);
        }
    }
}
