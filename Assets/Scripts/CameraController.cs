using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;
    [SerializeField] 
    private float zoomMinimo = 2f;
    [SerializeField] 
    private float zoomMaximo = 10f;
    
    private Vector3 cliqueInicial;
    
    void Update()
    {
        SetPosicaoCamera();
        SetOrthograficSize();
    }

    private void SetPosicaoCamera()
    {
        if (ControleManager.main.getMouseBotaoEsquerdoDown())
        {
            cliqueInicial =  camera.ScreenToWorldPoint(ControleManager.main.getPosicaoDoMouse());
        }
        if (ControleManager.main.getMouseBotaoEsquerdo())
        {
            var distancia = cliqueInicial - camera.ScreenToWorldPoint
                (ControleManager.main.getPosicaoDoMouse());
            transform.position += distancia * 5f * Time.deltaTime;
        }
    }

    public void SetOrthograficSize()
    {
        float input = ControleManager.main.getMouseScroll();
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - input, zoomMinimo, zoomMaximo);
    }
}