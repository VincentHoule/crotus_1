using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joueur : MonoBehaviour
{
    [SerializeField]
    private Transform endroitMort;

    [SerializeField]
    private Transition transition;

    public void JoueurPerdu()
    {
        StartCoroutine(JoueurTeleportation());
    }

    private IEnumerator JoueurTeleportation()
    {
        float tempsTransition = 3.0f;

        StartCoroutine(transition.FonduAuNoir(tempsTransition));
        yield return new WaitForSeconds(tempsTransition);
        transform.position = endroitMort.position;
        StartCoroutine(transition.FonduAuClair(tempsTransition));
    }

    
}
