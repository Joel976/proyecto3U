using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void TomarDaño(int daño)
    {
        vidaActual -= daño;
        Debug.Log(gameObject.name + " recibió daño: " + daño + " | Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Perder");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int VidaActual()
    {
        return vidaActual;
    }

}
