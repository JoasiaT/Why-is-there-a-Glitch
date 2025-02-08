using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isIteratioTextVisible = false;
    public UIManager manager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                // if ((collider is not BoxCollider) || (collider is BoxCollider && collider.gameObjet.tag == ""))
                if (collider is not BoxCollider)
                {
                    if (collider.gameObject.tag == "Object")  // "Object" zamieniæ na wartoœæ tagu przypisan¹ do konkretnego obiektu
                                                              // dziêki temu bêdzie mo¿na ustaliæ dla konkretnych obiektów wyswietlane teskty
                    {
                        if (!isIteratioTextVisible)
                        {
                            // wyœwietl na UI teskst:
                            manager.SetIteractionText("Napi³eœ siê!");
                            isIteratioTextVisible = true;
                        } 
                        else
                        {
                            manager.SetIteractionText(""); // wyczyœæ tekst
                            isIteratioTextVisible = false;
                        }
                    }
                   // Debug.Log(collider);
                }
            }
        }

    }
}
