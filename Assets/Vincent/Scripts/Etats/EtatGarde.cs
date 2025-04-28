using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// État neutre ou le squelette suit son chemin
/// </summary>
public class EtatGarde : EtatChevalier
{

    public void OnCommencer(Chevalier chevalier)
    {
        chevalier.ConeDetection.enabled = true;
        chevalier.Agent.enabled = true;
        chevalier.Destination = null;
    }

    public EtatChevalier OnExecuter(Chevalier chevalier)
    {
        Vector3 position = chevalier.Rb.position;


        if (chevalier.Destination == null)
        {
            chevalier.DeplacerVers();
        }

        else if (Vector3.Distance((Vector3)chevalier.Destination, position) < 1.2f)
        {
            chevalier.DeplacerVers();
        }
        return this;

    }

    public void OnSortie(Chevalier chevalier)
    {
        // rien
    }
}
