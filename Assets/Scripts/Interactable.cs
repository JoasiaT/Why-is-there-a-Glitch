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
                    if (collider.gameObject.tag == "Object")  // "Object" zamieni� na warto�� tagu przypisan� do konkretnego obiektu
                                                              // dzi�ki temu b�dzie mo�na ustali� dla konkretnych obiekt�w wyswietlane teskty
                    {
                        if (!isIteratioTextVisible)
                        {
                            // wy�wietl na UI teskst:
                            manager.SetIteractionText("Napi�e� si�!");
                            isIteratioTextVisible = true;
                        } 
                        else
                        {
                            manager.SetIteractionText(""); // wyczy�� tekst
                            isIteratioTextVisible = false;
                        }
                    }
                   // Debug.Log(collider);
                }
            }
        }

    }
}
