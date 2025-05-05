using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// G�re la mort du joueur
/// </summary>
public class Joueur : MonoBehaviour
{
    // Endroit � envoyer le joueur
    [SerializeField]
    private Transform endroitMort;

    // Gestionnaire de transition
    [SerializeField]
    private Transition transition;

    /// <summary>
    /// �v�nnement qui d�clanche la coroutine
    /// </summary>
    public void JoueurPerdu()
    {
        StartCoroutine(JoueurTeleportation());
    }

    /// <summary>
    /// T�l�porte le joueur avec le fondu
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
