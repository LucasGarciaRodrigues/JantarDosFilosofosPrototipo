using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeOut : MonoBehaviour
{
    private CanvasGroup canvasGroup = null;
    [SerializeField]
    private float tempo = 1f;
    [SerializeField]
    private float atraso = 0f;
    private float atrasoAtual = 0f;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
        
    void Start()
    {
        if(atraso == 0f) atrasoAtual += Time.deltaTime;
    }

    private void Update()
    {
        if (atrasoAtual > atraso)
        {
            StartCoroutine(Reproduzir());
        }
        atrasoAtual += Time.deltaTime;
    }

    public IEnumerator Reproduzir()
    {
        float t = 0;
        canvasGroup.alpha = 1f;
        while (t < tempo)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0f, t);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
        enabled = false;
    }
}
