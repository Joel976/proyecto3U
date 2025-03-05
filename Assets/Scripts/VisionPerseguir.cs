// VisionPerseguir.cs
using UnityEngine;

public class VisionPerseguir : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;

    public void Perseguir()
    {
        transform.LookAt(objetivo);
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}