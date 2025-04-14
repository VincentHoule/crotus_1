using UnityEngine;

public interface EtatChevalier
{
    public void OnCommencer(Chevalier chevalier);

    public EtatChevalier OnExecuter(Chevalier chevalier);

    public void OnSortie(Chevalier chevalier);
}