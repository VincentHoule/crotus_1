using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Chevalier : MonoBehaviour
{
    public Vector3? Destination { get; set; }
    public bool? Etourdi { get; private set; }

    [SerializeField]
    private Transform[] chemins;

    [SerializeField]
    private float tempsEtourdi;

    private NavMeshAgent agent;

    private int numChemin = 0;

    private EtatChevalier etat;

    private EtatChevalier etatPrecedant;

    private Rigidbody rb;

    private BoxCollider detection;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Destination = null;
        etat = new EtatGarde();

    }



    public void DeplacerVers()
    {
        Destination = chemins[numChemin].transform.position;
        agent.destination = (Vector3)Destination;
        numChemin++;
        if (numChemin == chemins.Length)
            numChemin = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lancable"))
        {
            etat = new EtatEtourdi();
        }
    }

    public void EtreEtourdi()
    {
        Etourdi = true;
        StartCoroutine(TempsEtourdi());
    }

    private IEnumerator TempsEtourdi()
    {
        yield return new WaitForSeconds(tempsEtourdi);
        Etourdi = false;
    }

    void Update()
    {
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
