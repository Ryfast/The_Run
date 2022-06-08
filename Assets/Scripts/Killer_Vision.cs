using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer_Vision : MonoBehaviour
{
    public float maxDistance = 7.5f;

    public LayerMask mask;

    public Collider killerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 vision = new Vector3(killerCollider.bounds.extents.x, killerCollider.bounds.extents.y, killerCollider.bounds.extents.z * 5);

        if (Physics.BoxCast(transform.position, vision, transform.right, out hit, killerCollider.transform.rotation, maxDistance, mask))
        {
            print(hit.transform.name + " a été touché");
        }
    }
    //void RaycastOne()
    //{
    //    RaycastHit hit;
    //    Ray rayon = new Ray(transform.position, transform.right);

    //    if (Physics.BoxCast(transform.position, killerCollider.bounds.extents, transform.right, out hit,killerCollider.transform.rotation, maxDistance, mask))
    //    {
    //        Debug.DrawRay(rayon.origin, transform.right * hit.distance, Color.green);
    //        print(hit.transform.name + " a été touché");

    //        if (hit.transform.name == "Joueur")
    //        {
    //            transform.parent.GetComponent<Killer_Deplacement>().playeurInView = true;
    //        }
    //    }
    //    else
    //    {
    //        Debug.DrawRay(rayon.origin, transform.right * maxDistance, Color.green);
    //    }
    //}

    private void OnDrawGizmos()
    {
        RaycastHit hit;

        Vector3 vision = new Vector3(killerCollider.bounds.extents.x, killerCollider.bounds.extents.y, killerCollider.bounds.extents.z * 10);

        if (Physics.BoxCast(transform.position, vision, transform.right, out hit, killerCollider.transform.rotation, maxDistance, mask))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.right * maxDistance);
            Gizmos.DrawWireCube(transform.position + transform.right * maxDistance, vision);

        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.right * maxDistance);
            Gizmos.DrawWireCube(transform.position + transform.right * maxDistance, vision);
        }
    }
}
