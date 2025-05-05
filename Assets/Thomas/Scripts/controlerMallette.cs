using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class controlerMallette : MonoBehaviour
{
    /// <summary>
    /// Est appeller dans la mallette detecte une gem
    /// </summary>
    public UnityEvent OnGemDetecte;

    /// <summary>
    /// le texte qui affiche les points
    /// </summary>
    private TextMeshPro etiquetteArgent;

    /// <summary>
    /// variable interne gardant la valeur de l'argent en mémoire
    /// </summary>
    public int argent = 0;

    /// <summary>
    /// variable interne du controlrGemme de la derniere gemme mis dans la mallette
    /// </summary>
    private controlerGemme gemme;

    public void Start()
    {
        etiquetteArgent = GetComponentInChildren<TextMeshPro>();
    }
    public void OnTriggerEnter(Collider autreObjet)
    {
        if (autreObjet.gameObject.CompareTag("Gem"))
        {
            gemme = autreObjet.GetComponent<controlerGemme>();
            argent += gemme.valeur;
            etiquetteArgent.SetText($"{argent}");
            Destroy(autreObjet.gameObject);
        }
        if (autreObjet.gameObject.CompareTag("basDeMap"))
        {
            gameObject.transform.position = new Vector3(-3.667798f, 0.3123897f, -0.366f);
        }

    }
}
