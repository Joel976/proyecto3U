using UnityEngine;
using UnityEngine.SceneManagement;
public class EscapeZone : MonoBehaviour
{
    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            Debug.Log("¡Has escapado con éxito!");
            SceneManager.LoadScene("Ganar");
        }
    }
}
