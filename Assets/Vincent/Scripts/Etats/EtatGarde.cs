using UnityEngine;
using UnityEngine.AI;

public class EtatGarde : EtatChevalier
{

    public void OnCommencer(Chevalier chevalier)
    {
        chevalier.Destination = null;
        chevalier.GetComponent<NavMeshAgent>().enabled = true;
    }

    public EtatChevalier OnExecuter(Chevalier chevalier)
    {
        Vector3 position = chevalier.GetComponent<Rigidbody>().position;


        if (chevalier.Destination == null)
        {
            chevalier.DeplacerVers();
        }

        else if (Vector3.Distance((Vector3)chevalier.Destination, position) < 1)
        {
            Debug.Log("lo");
            chevalier.DeplacerVers();
        }
        return this;

    }

    public void OnSortie(Chevalier chevalier)
        {
            // rien
        }
    }
