using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// Gère les transition
/// </summary>
public class Transition : MonoBehaviour
{
    // Image pour la transition
    [SerializeField]
    private Image image;


    /// <summary>
    /// Fonction qui fait un fondu au noir pour le joueur
    /// </summary>
    /// <param name="tempsTransition">Duration de la transition</param>
    /// <returns></returns>
    public IEnumerator FonduAuNoir(float tempsTransition)
    {
        float tempsEcouler = 0f;
        Color couleurTemp = Color.black;
        while(tempsEcouler < tempsTransition)
        {
            tempsEcouler += Time.deltaTime;
            float valeurCouleur = tempsEcouler / tempsTransition;
            couleurTemp.a = valeurCouleur;
            image.color = couleurTemp;

            yield return null;
        }
 
    }
    /// <summary>
    /// Fonction qui fait un fondu au clair pour le joueur
    /// </summary>
    /// <param name="tempsTransition">Duration de la transition</param>
    /// <returns></returns>
    public IEnumerator FonduAuClair(float tempsTransition)
    {
        float tempsEcouler = 0f;
        Color couleurTemp = Color.black;
        while (tempsEcouler < tempsTransition)
        {
            tempsEcouler += Time.deltaTime;
            float valeurCouleur = (tempsTransition - tempsEcouler) / tempsTransition;
            couleurTemp.a = valeurCouleur;
            image.color = couleurTemp;

            yield return null;
        }

    }
}
