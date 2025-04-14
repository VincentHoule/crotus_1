using UnityEngine;
using UnityEngine.Events;

public class controlerMallette : MonoBehaviour
{
    /// <summary>
    /// Est appeller dans la mallette detecte une gem
    /// </summary>
    public UnityEvent OnGemDetecte;
    public void OnTriggerEnter(Collider autreObjet)
    {
        if (autreObjet.gameObject.CompareTag("Gem"))
        {
            OnGemDetecte?.Invoke();
            Destroy(gameObject);
        }

    }
}
