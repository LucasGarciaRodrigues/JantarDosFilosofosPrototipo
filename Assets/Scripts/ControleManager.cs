using UnityEngine;

public class ControleManager : MonoBehaviour
{
    public static ControleManager main;
    
    [SerializeField][Range(1f,10f)]
    private float sensibilidade = 5f;
    private void Awake()
    {
        main = this;
    }
    
    public bool GetEnterDown()
    {
        return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);
    }

    public Vector3 getPosicaoDoMouse()
    {
        return Input.mousePosition;
    }
    
    public bool getMouseBotaoEsquerdoDown()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    public bool getMouseBotaoEsquerdo()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }

    public float getMouseScroll()
    {
        return Input.GetAxis("Mouse ScrollWheel") * sensibilidade;
    }
}
