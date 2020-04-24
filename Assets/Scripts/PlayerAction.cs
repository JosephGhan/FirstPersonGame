using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Light newLight;

    bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        newLight.enabled = isOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                SphereCollider sp = hit.collider as SphereCollider;
                if (sp != null)
                {
                    Destroy(sp.gameObject);
                }
            }
        }

        if (Input.GetKeyDown("f"))
        {
            if (!isOn)
            {
                isOn = true;
                newLight.enabled = isOn;
            }
            else
            {
                isOn = false;
                newLight.enabled = isOn;
            }
        }
    }
}
