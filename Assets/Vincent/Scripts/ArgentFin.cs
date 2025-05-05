using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArgentFin : MonoBehaviour
{
    // Mallette
    [SerializeField]
    private controlerMallette controlerMallette;

    // Texte � afficher
    private string texte;

    // Affichage du texte
    private TextMeshPro textComponent;
    void Start()
    {
        texte = "Bravo ! Vous �tes encore en vie. Vous avez accumuler :";
        textComponent = GetComponent<TextMeshPro>();
    }

    /// <summary>
    /// Fontion qui met � jour l'argent finale.
    /// </summary>
    public void MettreArgent()
    {
        texte += controlerMallette.argent + "$";
        textComponent.text = texte;
    }
}
