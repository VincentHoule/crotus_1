using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// Lettre qui permet de commencer le jeu
public class Lettre : MonoBehaviour
{
    // Position du joueur
    [SerializeField]
    Transform joueur;

    // Endroit à envoyer le joueur pour commencer le jeu
    [SerializeField]
    Transform debutMap;

    // Gestionnaire de transition
    [SerializeField]
    private Transition transition;

    /// <summary>
    /// Détection de la lettre dans le feu
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Feu"))
        {
            StartCoroutine(DebutJeu());

        }
    }

    /// <summary>
    /// Débute le jeu avec transition
    /// </summary>
    /// <returns></returns>
    private IEnumerator DebutJeu()
    {
        float tempsTransition = 3.0f;

        StartCoroutine(transition.FonduAuNoir(tempsTransition));
        yield return new WaitForSeconds(tempsTransition + 1f);

        joueur.position = debutMap.position;
        StartCoroutine(transition.FonduAuClair(tempsTransition));
    }



}
