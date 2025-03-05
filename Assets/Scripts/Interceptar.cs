// Interceptar.cs
using UnityEngine;

public class Interceptar : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    private Vector3 velObjetivo, objPosAnterior;

    void Start()
    {
        objPosAnterior = objetivo.position;
    }

    public void RealizarIntercepcion()
    {
        velObjetivo = (objetivo.position - objPosAnterior) / Time.deltaTime;
        objPosAnterior = objetivo.position;
        Vector3 posPrediccion = objetivo.position + velObjetivo * 2f;
        transform.LookAt(posPrediccion);
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}