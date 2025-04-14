using UnityEngine;

public class ControlerEtagere : MonoBehaviour
{

    /// <summary>
    /// Référence a l'Animator
    /// </summary>
    private Animator controleurAnimation;

    private bool deplacer = false;

    private void Start()
    {
        controleurAnimation = GetComponent<Animator>();
    }

    public void OnTriggerExit(Collider autreObjet)
    {
        if (autreObjet.gameObject.CompareTag("Livre"))
        {
            if (!deplacer) {
                deplacer = true;
                controleurAnimation.SetTrigger("livreEnleve");
            }
        }
    }
}
