using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Slider vidaSlider;
    public Text vidaTexto;
    public Text misionTexto;
    public Health jugadorHealth;

    void Start()
    {
        vidaSlider.maxValue = jugadorHealth.vidaMaxima;
        vidaSlider.value = jugadorHealth.vidaMaxima;
        vidaTexto.text = "Vida: " + jugadorHealth.vidaMaxima;
        misionTexto.text = "MISIÓN: ¡Escapa de la invasión alienígena!";
    }

    void Update()
    {
        vidaSlider.value = jugadorHealth.VidaActual();
        vidaTexto.text = "Vida: " + jugadorHealth.VidaActual();
    }
}
