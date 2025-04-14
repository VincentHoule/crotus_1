using UnityEngine;
using UnityEngine.AI;

public class EtatEtourdi : EtatChevalier
{
    public void OnCommencer(Chevalier chevalier)
    {
        chevalier.GetComponent<NavMeshAgent>().enabled = false;
        chevalier.EtreEtourdi();
    }

    public EtatChevalier OnExecuter(Chevalier chevalier)
    {
        if((bool)chevalier.Etourdi)
        {
            return this;
        }

        return new EtatGarde();
    }

    public void OnSortie(Chevalier chevalier)
    {
        // rien
    }

}
