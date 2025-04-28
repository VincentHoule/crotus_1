using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joueur : MonoBehaviour
{
    [SerializeField]
    private Transform endroitMort;

    private Transform position;
    private void Start()
    {
        position.GetComponent<Transform>();
    }

    public void JoueurPerdu()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
