using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float maxVisibleTime = 2f;
    private float timeSinceInfoVisible = 0f;
    private bool isIteratioTextVisible = false;
    public UIManager manager;
    

    private void Update()
    {
        timeSinceInfoVisible += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 10f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                // if ((collider is not BoxCollider) || (collider is BoxCollider && collider.gameObject.tag == ""))
                if (collider is not BoxCollider)
                {
                    if (collider.gameObject.tag == "VendingMachine")  // "Object" zamieni� na warto�� tagu przypisan� do konkretnego obiektu
                                                                      // dzi�ki temu b�dzie mo�na ustali� dla konkretnych obiekt�w wyswietlane teskty
                    {
                        if (!isIteratioTextVisible)
                        {
                            manager.SetIteractionText("Napi�e� si�!");
                            isIteratioTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "TrashCan") // tu tag obiektu, dla ktorego wysw. bedze tekst
                    {
                        if (!isIteratioTextVisible)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIteratioTextVisible = true;
                        }
                    }
                    //Debug.Log(collider);
                    //Debug.Log(collider.gameObject.tag);
                }
            }
        }

        if (timeSinceInfoVisible >= maxVisibleTime)
        {
            if (isIteratioTextVisible)
            {
                manager.SetIteractionText("");
                isIteratioTextVisible = false;
            }
            timeSinceInfoVisible = 0f;
        }
    }
}
