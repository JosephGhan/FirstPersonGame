using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Light newLight;
    public GameObject rockPrefab;

    int runes = 4;
    int runesPlaced = 0;
    bool isOn = false;
    bool[] isActivated = new bool[] {false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        newLight.enabled = isOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            ActionE();
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

        IsOver();
    }

    void IsOver()
    {

    }

    void ActionE()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            SphereCollider sp = hit.collider as SphereCollider;
            if (sp != null)
            {
                Destroy(sp.gameObject);
                runes++;
            }
            BoxCollider bc = hit.collider as BoxCollider;
            if (bc != null && runes > 0)
            {
                //print(bc.name);
                switch (bc.name)
                {
                    case "shrine1":
                        if (!isActivated[0])
                        {
                            runes--;
                            Instantiate(rockPrefab, bc.transform.position + new Vector3(.05f, 1.7f, -0.1f), Quaternion.identity);
                            runesPlaced++;
                            isActivated[0] = true;
                        }
                        break;
                    case "shrine2":
                        if (!isActivated[1])
                        {
                            runes--;
                            Instantiate(rockPrefab, bc.transform.position + new Vector3(0.1f, 1.7f, 0f), Quaternion.identity);
                            runesPlaced++;
                            isActivated[1] = true;
                        }
                        break;
                    case "shrine3":
                        if (!isActivated[2])
                        {
                            runes--;
                            Instantiate(rockPrefab, bc.transform.position + new Vector3(-0.1f, 1.7f, 0.1f), Quaternion.identity);
                            runesPlaced++;
                            isActivated[2] = true;
                        }
                        break;
                    case "shrine4":
                        if (!isActivated[3])
                        {
                            runes--;
                            Instantiate(rockPrefab, bc.transform.position + new Vector3(.1f, 1.7f, .1f), Quaternion.identity);
                            runesPlaced++;
                            isActivated[3] = true;
                        }
                        break;
                    default:
                        break;

                }

            }
        }
    }
}
