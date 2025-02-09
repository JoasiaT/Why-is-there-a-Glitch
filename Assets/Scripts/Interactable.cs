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
                    if (collider.gameObject.tag == "VendingMachine")  // "Object" zamieniæ na wartoœæ tagu przypisan¹ do konkretnego obiektu
                                                                      // dziêki temu bêdzie mo¿na ustaliæ dla konkretnych obiektów wyswietlane teskty
                    {
                        if (!isIteratioTextVisible)
                        {
                            manager.SetIteractionText("Napi³eœ siê!");
                            isIteratioTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "TrashCan") // tu tag obiektu, dla ktorego wysw. bedze tekst
                    {
                        if (!isIteratioTextVisible)
                        {
                            manager.SetIteractionText("Znalaz³eœ znajdŸkê");
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
