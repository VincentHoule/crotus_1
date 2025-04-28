using UnityEngine;

/// <summary>
/// Interface d'un �tat pour le squelette
/// </summary>
public interface EtatChevalier
{
    /// <summary>
    /// S�quence � faire au d�but de l'�tat
    /// </summary>
    /// <param name="chevalier">Le script squelette</param>
    public void OnCommencer(Chevalier chevalier);

    /// <summary>
    /// S�quence � faire pendant l'�tat
    /// </summary>
    /// <param name="chevalier">Le script squelette</param>
    /// <returns>L'�tat suivant</returns>
    public EtatChevalier OnExecuter(Chevalier chevalier);

    /// <summary>
    /// S�quence � faire apr�s l'�tat
    /// </summary>
    /// <param name="chevalier">Le script du squelette</param>
    public void OnSortie(Chevalier chevalier);
}