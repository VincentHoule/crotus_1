using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gère lancement de la nouvelle partie
/// </summary>
public class Echappe : MonoBehaviour
{
    // Gestionnaire de transition
    [SerializeField]
    private Transition transition;

    /// <summary>
    /// Détertion du relancement de jeu
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Joueur"))
        {
            StartCoroutine(RecommencerJeu());
        }
    }

    /// <summary>
    /// Relance le jeu avec fondu
    /// </summary>
    /// <returns></returns>
    private IEnumerator RecommencerJeu()
    {
        float tempsTransition = 3.0f;

        StartCoroutine(transition.FonduAuNoir(tempsTransition));
        yield return new WaitForSeconds(tempsTransition + 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
