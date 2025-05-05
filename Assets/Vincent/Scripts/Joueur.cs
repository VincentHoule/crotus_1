using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gère la mort du joueur
/// </summary>
public class Joueur : MonoBehaviour
{
    // Endroit à envoyer le joueur
    [SerializeField]
    private Transform endroitMort;

    // Gestionnaire de transition
    [SerializeField]
    private Transition transition;

    /// <summary>
    /// Évènnement qui déclanche la coroutine
    /// </summary>
    public void JoueurPerdu()
    {
        StartCoroutine(JoueurTeleportation());
    }

    /// <summary>
    /// Téléporte le joueur avec le fondu
    /// </summary>
    /// <returns></returns>
    private IEnumerator JoueurTeleportation()
    {
        float tempsTransition = 3.0f;

        StartCoroutine(transition.FonduAuNoir(tempsTransition));
        yield return new WaitForSeconds(tempsTransition + 1f);
        transform.position = endroitMort.position;
        StartCoroutine(transition.FonduAuClair(tempsTransition));
    }

    
}
