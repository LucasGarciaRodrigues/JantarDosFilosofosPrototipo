using UnityEngine;

public class EnterParaComecar : MonoBehaviour
{
    void Update()
    {
        if (ControleManager.main.GetEnterDown())
        {
            JogoManager.main.ComecarJogo();
        }
    }
}
