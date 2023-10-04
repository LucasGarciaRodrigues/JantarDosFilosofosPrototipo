using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeIn : MonoBehaviour
{
    private CanvasGroup canvasGroup;
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
        float t = 0f;
        canvasGroup.alpha = 0f;
        while (t < tempo)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1f, t);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
        enabled = false;
    }
}
