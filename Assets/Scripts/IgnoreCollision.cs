using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour
{
    void Update()
    {
        checkRadius(transform.position + new Vector3(0, 0.6f, -1.6f), 2);
    }

    void checkRadius(Vector3 center, float radius)
    {
      Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Environment")
            {
                //hitColliders[i].gameObject.SetActive(false);
                Physics.IgnoreCollision(hitColliders[i].GetComponent<Collider>(), GetComponent<Collider>());
            }
            i++;
        }
    }
}
