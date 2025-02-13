using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    private float maxVisibleTime = 2f;
    private float timeSinceInfoVisible = 0f;
    private bool isIterationTextVisible = false;
    public UIManager manager;
    public MouseLook mouseLook;
    public PlayerMovment playerMovment;
    public AudioManager audioMananger;

    private void Awake()
    {
        audioMananger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        timeSinceInfoVisible += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 10f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                //if ((collider is not BoxCollider) || (collider is BoxCollider && collider.gameObject.tag == ""))
                if (collider is not BoxCollider)
                {
                    if (collider.gameObject.tag == "VendingMachine")  // "Object" zamieni� na warto�� tagu przypisan� do konkretnego obiektu
                                                                      // dzi�ki temu b�dzie mo�na ustali� dla konkretnych obiekt�w wyswietlane teskty
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Napi�e� si�!");
                            isIterationTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "TrashCan") // tu tag obiektu, dla ktorego wysw. bedze tekst
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "LoungeChair2")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "CoffeTable")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "Plant2")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "BookOpen")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Przeczyts�e� ksi��k�");
                            isIterationTextVisible = true;
                        }
                    }
                    if (collider.gameObject.tag == "WaterDispenser")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Wypi�e� wod�");
                            isIterationTextVisible = true;

                        }
                    }
                    if (collider.gameObject.tag == "microwave")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Odgrza�e� pizze");
                            isIterationTextVisible = true;

                        }
                    }
                    if (collider.gameObject.tag == "CoffeeMachine")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Wypi�e� kaw�");
                            isIterationTextVisible = true;

                        }
                    }
                    if (collider.gameObject.tag == "BomBox")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("W��czy�e� radio");
                            isIterationTextVisible = true;
                            //DODA� KOD NA ODTWARZANIE MUZYKI W RADIU

                        }
                    }

                    //if (collider.gameObject.tag == "Radio")
                    //{
                    //    audioMananger.PlayOneShoot(audioMananger.radioMusic);
                    //}



                    //Debug.Log(collider);
                    //Debug.Log(collider.gameObject.tag);
                }

            }
        }
        if (timeSinceInfoVisible >= maxVisibleTime)
        {
            if (isIterationTextVisible)
            {
                manager.SetIteractionText("");
                isIterationTextVisible = false;
            }
            timeSinceInfoVisible = 0f;
        }   

        if (Input.GetKeyDown(KeyCode.M))
        {
            float interactRange = 10f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                if (collider.gameObject.tag == "BoomBox")
                {
                    if (audioMananger.boomBox != null)
                    {
                        audioMananger.PlayMusic();
                    }
                    Debug.Log("Gra muzyka!");
                }
                // kolejne obiekty tu!
            }
        }
    }

    public void OnCollisionEnter(Collision collision) //Tym trzeba si� zaj��, tylko jak? Najpro�ciej jak to mo�liwe!
    {
        //if (collision.gameObject.tag == "Obsticle")
        //{
        Debug.Log(collision.gameObject.tag);
        //}
    }
}