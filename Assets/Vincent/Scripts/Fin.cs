using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    // Endroit de la zone de fin à téléporter le joueur
    [SerializeField]
    private Transform endroitFin;

    // Gestionnaire de transition
    [SerializeField]
    private Transition transition;

    // Joueur
    [SerializeField]
    private Transform joueur;

    // Fonction qui met à jour l'argent
    [SerializeField]
    private UnityEvent mettreArgent;


    private bool gagne;

    private void Start()
    {
        gagne = false;
    }
    /// <summary>
    /// Détecte lorsque le joueur s'échappe
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(!gagne)
        {
            gagne = true;
            StartCoroutine(TerminerJeu());
        }

    }

    /// <summary>
    /// Relance le jeu avec fondu
    /// </summary>
    /// <returns></returns>
    private IEnumerator TerminerJeu()
    {
        mettreArgent.Invoke();
        float tempsTransition = 3.0f;

        StartCoroutine(transition.FonduAuNoir(tempsTransition));
        yield return new WaitForSeconds(tempsTransition + 1f);
        joueur.position = endroitFin.position;

        StartCoroutine(transition.FonduAuClair(tempsTransition));
        yield return new WaitForSeconds(tempsTransition + 1f);

        StartCoroutine(transition.FonduAuNoir(tempsTransition));

        yield return new WaitForSeconds(tempsTransition + 3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
