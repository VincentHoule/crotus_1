using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// Lettre qui permet de commencer le jeu
public class Lettre : MonoBehaviour
{
    [SerializeField]
    Transform joueur;

    [SerializeField]
    Transform debutMap;

    [SerializeField]
    private Transition transition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Feu"))
        {
            StartCoroutine(DebutJeu());

        }
    }

    private IEnumerator DebutJeu()
    {
        float tempsTransition = 3.0f;

        StartCoroutine(transition.FonduAuNoir(tempsTransition));
        yield return new WaitForSeconds(tempsTransition);

        joueur.position = debutMap.position;
        StartCoroutine(transition.FonduAuClair(tempsTransition));
    }



}
