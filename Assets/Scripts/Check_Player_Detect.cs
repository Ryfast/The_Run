using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Player_Detect : MonoBehaviour
{
    public float maxDistance;

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

            if (hit.transform.tag == "Joueur")
            {
                print(hit.transform.name + " en vue !");
                transform.parent.GetComponent<Killer_Deplacement>().playeurInView = true;
                transform.parent.GetComponent<Killer_Deplacement>().ennemyAnimator.SetBool("PlayerSpoted", true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        RaycastHit hit;

        Vector3 vision = new Vector3(killerCollider.bounds.extents.x, killerCollider.bounds.extents.y, killerCollider.bounds.extents.z * 10);

        if (Physics.BoxCast(transform.position, vision, transform.right, out hit, killerCollider.transform.rotation, maxDistance, mask))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.right * maxDistance);
            Gizmos.DrawWireCube(transform.position + transform.right * maxDistance, vision);

        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, transform.right * maxDistance);
            Gizmos.DrawWireCube(transform.position + transform.right * maxDistance, vision);
        }
    }

}
