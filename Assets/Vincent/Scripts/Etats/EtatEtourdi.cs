using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// État lorsque le squelette est touché par un objet lancer par le joueur
/// </summary>
public class EtatEtourdi : EtatChevalier
{
    public void OnCommencer(Chevalier chevalier)
    {
        chevalier.ConeDetection.enabled = false;
        chevalier.Destination = null;
        chevalier.Agent.enabled = false;
        chevalier.Animator.SetTrigger("Etourdi");
        chevalier.EtreEtourdi();

    }

    public EtatChevalier OnExecuter(Chevalier chevalier)
    {
        if((bool)chevalier.Etourdi)
        {

            return this;
        }
        else
        {
            chevalier.Animator.SetTrigger("Reveille");
            return new EtatGarde();

        }
    }

    public void OnSortie(Chevalier chevalier)
    {
        // rien
    }

}
