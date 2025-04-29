using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Transition : MonoBehaviour
{
    [SerializeField]
    private Image image;


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
