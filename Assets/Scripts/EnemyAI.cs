// EnemyAI.cs
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    public float rangoDeteccion = 10f;
    public float rangoAtaque = 2f;
    public bool usarIntercepcion = false;
    public bool usarVisionPerseguir = false;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 1.5f;
    private float proximoDisparo;
    
    private enum Estado { Patrullando, Persiguiendo, Atacando }
    private Estado estadoActual = Estado.Patrullando;
    private Vector3 puntoPatrulla;
    private Interceptar interceptar;
    private VisionPerseguir visionPerseguir;
    
    void Start()
    {
        AsignarPuntoPatrulla();
        interceptar = GetComponent<Interceptar>();
        visionPerseguir = GetComponent<VisionPerseguir>();
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, objetivo.position);

        switch (estadoActual)
        {
            case Estado.Patrullando:
                Patrullar();
                if (distancia < rangoDeteccion)
                {
                    estadoActual = Estado.Persiguiendo;
                }
                break;

            case Estado.Persiguiendo:
                if (usarIntercepcion && interceptar != null)
                {
                    interceptar.RealizarIntercepcion();
                }
                else if (usarVisionPerseguir && visionPerseguir != null)
                {
                    visionPerseguir.Perseguir();
                }
                else
                {
                    Perseguir();
                }

                if (distancia < rangoDeteccion)
                {
                    estadoActual = Estado.Atacando;
                }
                else if (distancia > rangoDeteccion)
                {
                    estadoActual = Estado.Patrullando;
                }
                break;

            case Estado.Atacando:
                Atacar();
                if (distancia > rangoAtaque)
                {
                    estadoActual = Estado.Persiguiendo;
                }
                break;
        }
    }

    void Patrullar()
    {
        if (Vector3.Distance(transform.position, puntoPatrulla) < 1f)
        {
            AsignarPuntoPatrulla();
        }
        transform.position = Vector3.MoveTowards(transform.position, puntoPatrulla, velocidad * Time.deltaTime);
    }

    void Perseguir()
    {
        transform.LookAt(objetivo);
        transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
    }

    void Atacar()
    {
        transform.LookAt(objetivo);
        if (Time.time >= proximoDisparo)
        {
            Disparar();
            proximoDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }

    void AsignarPuntoPatrulla()
    {
        puntoPatrulla = new Vector3(Random.Range(-10, 10) + transform.position.x, transform.position.y, Random.Range(-10, 10) + transform.position.z);
    }
}
