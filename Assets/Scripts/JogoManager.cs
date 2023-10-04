using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogoManager : MonoBehaviour
{
    public static JogoManager main;

    [SerializeField]
    private GameObject telaDeCarregamento;
    private void Awake()
    {
        main = this;
    }
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        StartCoroutine(Inicializar());
    }
    
    public IEnumerator Inicializar()
    {
        telaDeCarregamento.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync((int)CenaIndice.Cenario, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int)CenaIndice.MenuPrincipal, LoadSceneMode.Additive);
        telaDeCarregamento.SetActive(false);
    }

    public void ComecarJogo()
    {
        StartCoroutine(ComecarjogoCoroutine());
    }

    public IEnumerator ComecarjogoCoroutine()
    {
        telaDeCarregamento.SetActive(true);
        SceneManager.UnloadSceneAsync((int)CenaIndice.MenuPrincipal, UnloadSceneOptions.None);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync((int)CenaIndice.Filosofos, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int)CenaIndice.Camera, LoadSceneMode.Additive);
        telaDeCarregamento.SetActive(false);
    }
}
