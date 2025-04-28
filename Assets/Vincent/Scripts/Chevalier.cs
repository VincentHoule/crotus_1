using System;
using System.Collections;
using ConeCastDemo;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;


/// <summary>
/// Gère les gardes squelettes
/// </summary>
public class Chevalier : MonoBehaviour
{

    // Tableau des emplacements pour tracer le chemins de garde du squelette
    [SerializeField]
    private Transform[] chemins;

    // Temps que le squelette est étourdi
    [SerializeField]
    private float tempsEtourdi;

    // Accèsseur de la destination du squelette
    public Vector3? Destination { get; set; }

    // Accèsseur de l'indcateur de l'état du squelette
    public bool? Etourdi { get; set; }

    // Accèsseur du NavMeshAgent du squelette
    public NavMeshAgent Agent { get; set; }

    // Accèsseur de l'Animator du squelette
    public Animator Animator { get; set; }

    // Accèsseur du Rigidbody du squelette
    public Rigidbody Rb { get; private set; }

    // Accèsseur du ConeCastModifier du squelette
    public ConeCastModifier ConeDetection { get;  set; }

    // NavMeshAgent du squelette
    private NavMeshAgent agent;

    // Animator du squelette
    private Animator animator;

    // Zone de détection du squelette
    private ConeCastModifier coneDetection;

    // Rigibody du squelette
    private Rigidbody rb;
    
    // État du squelette
    private EtatChevalier etat;

    // État précédant du squelette
    private EtatChevalier etatPrecedant;

    // Endroit dans le tableau de chemin
    private int numChemin = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Agent = agent;
        animator = GetComponent<Animator>();
        Animator = animator;
        rb = GetComponent<Rigidbody>();
        Rb = rb;
        coneDetection = GetComponentInChildren<ConeCastModifier>();
        ConeDetection = coneDetection;
        Destination = null;
        Etourdi = false;
        etat = new EtatGarde();
        

    }

    /// <summary>
    /// Dirige le squelette vers un nouvel emplacement
    /// </summary>
    public void DeplacerVers()
    {
        Destination = chemins[numChemin].transform.position;
        agent.destination = (Vector3)Destination;
        numChemin++;
        if (numChemin == chemins.Length)
            numChemin = 0;

    }

    /// <summary>
    /// Détecte si la collision est causé par un objet lancée
    /// </summary>
    /// <param name="other">Objet entré en collision</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lancable"))
        {
            GetComponent<PlayableDirector>().Play();
            etat = new EtatEtourdi();
            Destroy(other.gameObject);

        }
    }

    /// <summary>
    /// Active l'état étourdi du squelette
    /// </summary>
    public void EtreEtourdi()
    {
        Etourdi = true;
        StartCoroutine(TempsEtourdi());
    }

    /// <summary>
    /// Temps d'innactivité du squelette
    /// </summary>
    /// <returns></returns>
    private IEnumerator TempsEtourdi()
    {
        yield return new WaitForSeconds(tempsEtourdi);
        Etourdi = false;
    }

    void Update()
    {
        // Machine à état
        if (etat != etatPrecedant)
        {
            etat.OnCommencer(this);
        }
        etatPrecedant = etat;
        if (etat != null)
        {
            etat = etat.OnExecuter(this);

        }

        if (etatPrecedant != etat)
        {
            if (etatPrecedant != null)
                etat.OnSortie(this);
        }
    }
}
