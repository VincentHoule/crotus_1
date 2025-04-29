using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Echappe : MonoBehaviour
{

    [SerializeField]
    private Transition transition;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Joueur"))
        {
            StartCoroutine(RecommencerJeu());
        }
    }

    private IEnumerator RecommencerJeu()
    {
        float tempsTransition = 3.0f;

        StartCoroutine(transition.FonduAuNoir(tempsTransition));
        yield return new WaitForSeconds(tempsTransition);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
