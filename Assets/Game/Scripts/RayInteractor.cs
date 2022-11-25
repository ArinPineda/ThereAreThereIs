using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteractor : MonoBehaviour
{

    public GameObject lasthit;
    public Vector3 collision = Vector3.zero;
    public LayerMask layer;
    

   
    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position,this.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 4, layer))
        {
            lasthit = hit.transform.gameObject;
            collision = hit.point;
            Debug.DrawRay(this.transform.position, transform.TransformDirection (Vector3.forward) * hit.distance, Color.red );
            if (hit.transform.gameObject.GetComponent<Collider>().tag.Equals(UIManager.instance.aimQuest) && UIManager.instance.isCourutineActive)
            {

                StartCoroutine(UIManager.instance.waitLerp(hit.transform.gameObject));
                
            }

        }
    }

   


}
