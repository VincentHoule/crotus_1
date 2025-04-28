using UnityEngine;

/// <summary>
/// Interface d'un état pour le squelette
/// </summary>
public interface EtatChevalier
{
    /// <summary>
    /// Séquence à faire au début de l'état
    /// </summary>
    /// <param name="chevalier">Le script squelette</param>
    public void OnCommencer(Chevalier chevalier);

    /// <summary>
    /// Séquence à faire pendant l'état
    /// </summary>
    /// <param name="chevalier">Le script squelette</param>
    /// <returns>L'état suivant</returns>
    public EtatChevalier OnExecuter(Chevalier chevalier);

    /// <summary>
    /// Séquence à faire après l'état
    /// </summary>
    /// <param name="chevalier">Le script du squelette</param>
    public void OnSortie(Chevalier chevalier);
}