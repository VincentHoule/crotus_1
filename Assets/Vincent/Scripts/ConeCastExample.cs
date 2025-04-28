using ConeCastCode;
using ConeCastScript.Demo;
using UnityEngine;
using UnityEngine.Events;

namespace ConeCastDemo
{
    /// <summary>
    /// Code emprunté
    /// Projète plusieurs raycast sous forme de cône
    /// 
    /// author : Agoston_R
    /// </summary>
    [ExecuteInEditMode]
    public class ConeCastModifier : MonoBehaviour
    {
        public bool blockingCast = true;
        public Color hitColor = Color.red;
        public Color defaultColor = Color.white;
        public float coneAngle = 15.0f;
        public int subdivision = 3;
        public float nearClipDistance = 1.0f;
        public float farClipDistance = 50.0f;
        public LayerMask layers;
        public bool useExtraSpheres = false;
        public float extraSphereRadius = 0.1f;
        public bool visualize = true;
        public Color drawColor = Color.yellow;

        [SerializeField]
        private UnityEvent toucherJoueur;

        public void Update()
        {
            if (blockingCast)
            {
                var isHit = ConePhysics.ConeCast(
                    hit: out var hit,
                    origin: transform.position,
                    direction: transform.forward,
                    coneAngle: coneAngle,
                    subdivision: subdivision,
                    nearClipDistance: nearClipDistance,
                    farClipDistance: farClipDistance,
                    layerMask: layers,
                    useExtraSpheres: useExtraSpheres,
                    extraSphereRadius: extraSphereRadius,
                    queryTriggerInteraction: QueryTriggerInteraction.Collide,
                    visualize: visualize,
                    drawColor: drawColor);

                if (isHit)
                {
                    // Partie modifier
                    if (hit.collider.gameObject.CompareTag("Joueur"))
                    {
                        toucherJoueur.Invoke();

                    }
                }
            }
           
        }

    }
}
