using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadSprint = 8f;
    public float sensibilidad = 2f;
    public Camera camara;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 10f;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        Movimiento();
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Movimiento()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        
        Vector3 movimiento = transform.right * movX + transform.forward * movZ;
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadSprint : velocidad;
        
        rb.linearVelocity = new Vector3(movimiento.x * velocidadActual, rb.linearVelocity.y, movimiento.z * velocidadActual);
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rbBala = bala.GetComponent<Rigidbody>();
        rbBala.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
    }
}
