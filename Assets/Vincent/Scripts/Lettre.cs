using UnityEngine;

public class Lettre : MonoBehaviour
{
    [SerializeField]
    Transform joueur;

    [SerializeField]
    Transform debutMap;
    void Start()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Feu"))
        {
            joueur.position = debutMap.position;

        }
    }

}
