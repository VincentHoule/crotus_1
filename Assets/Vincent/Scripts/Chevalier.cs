using System;
using System.Collections;
using ConeCastDemo;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;


/// <summary>
/// G�re les gardes squelettes
/// </summary>
public class Chevalier : MonoBehaviour
{

    // Tableau des emplacements pour tracer le chemins de garde du squelette
    [SerializeField]
    private Transform[] chemins;

    // Temps que le squelette est �tourdi
    [SerializeField]
    private float tempsEtourdi;

    // Acc�sseur de la destination du squelette
    public Vector3? Destination { get; set; }

    // Acc�sseur de l'indcateur de l'�tat du squelette
    public bool? Etourdi { get; set; }

    // Acc�sseur du NavMeshAgent du squelette
    public NavMeshAgent Agent { get; set; }

    // Acc�sseur de l'Animator du squelette
    public Animator Animator { get; set; }

    // Acc�sseur du Rigidbody du squelette
    public Rigidbody Rb { get; private set; }

    // Acc�sseur du ConeCastModifier du squelette
    public ConeCastModifier ConeDetection { get;  set; }

    // NavMeshAgent du squelette
    private NavMeshAgent agent;

    // Animator du squelette
    private Animator animator;

    // Zone de d�tection du squelette
    private ConeCastModifier coneDetection;

    // Rigibody du squelette
    private Rigidbody rb;
    
    // �tat du squelette
    private EtatChevalier etat;

    // �tat pr�c�dant du squelette
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
    /// D�tecte si la collision est caus� par un objet lanc�e
    /// </summary>
    /// <param name="other">Objet entr� en collision</param>
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
    /// Active l'�tat �tourdi du squelette
    /// </summary>
    public void EtreEtourdi()
    {
        Etourdi = true;
        StartCoroutine(TempsEtourdi());
    }

    /// <summary>
    /// Temps d'innactivit� du squelette
    /// </summary>
    /// <returns></returns>
    private IEnumerator TempsEtourdi()
    {
        yield return new WaitForSeconds(tempsEtourdi);
        Etourdi = false;
    }

    void Update()
    {
        // Machine � �tat
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
