using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscena : MonoBehaviour
{
    public void Inicio()
    {
        Debug.Log("Volviendo al inicio...");
        SceneManager.LoadScene("Inicio");
    }

    public void Game()
    {
        Debug.Log("Cargando escena de Game...");
        SceneManager.LoadScene("Juego");
    }
}
