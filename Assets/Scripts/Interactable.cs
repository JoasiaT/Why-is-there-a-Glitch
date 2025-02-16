using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float maxVisibleTime = 3f;
    private float timeSinceInfoVisible = 0f;
    private bool isIterationTextVisible = false;
    public UIManager manager;
    public MouseLook mouseLook;
    public PlayerMovment playerMovment;
    public AudioManager audioMananger;
    private bool TrashCanFound = false;
    private bool Plant2Found = false;
    private bool LoungeChair2Found = false;
    private bool CoffeTableFound = false;
    private bool playerTextVisible = false;
    private float maxDialogTextVisible = 6f;
    private float timeSinceDialogVisible = 0f;

    private void Awake()
    {
        audioMananger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        timeSinceInfoVisible += Time.deltaTime;
        timeSinceDialogVisible += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 5f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                if (collider is not BoxCollider)
                {
                    if (collider.gameObject.tag == "VendingMachine")  // "Object" zamieni� na warto�� tagu przypisan� do konkretnego obiektu
                                                                      // dzi�ki temu b�dzie mo�na ustali� dla konkretnych obiekt�w wyswietlane teskty
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("Napi�e� si�!");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f; // doda� dla wszystkich znajdowanych obiekt�w to zerowanie!
                        }
                    }
                    if (collider.gameObject.tag == "TrashCan") // tu tag obiektu, dla ktorego wysw. bedze tekst
                    {
                        if (!isIterationTextVisible && !TrashCanFound)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            TrashCanFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "LoungeChair2")
                    {
                        if (!isIterationTextVisible && !LoungeChair2Found)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            LoungeChair2Found = true;
                        }
                    }
                    if (collider.gameObject.tag == "CoffeTable")
                    {
                        if (!isIterationTextVisible && !CoffeTableFound)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            CoffeTableFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Plant2")
                    {
                        if (!isIterationTextVisible && !Plant2Found)
                        {
                            manager.SetIteractionText("Znalaz�e� znajd�k�");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            Plant2Found = true;
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
                    if (collider.gameObject.tag == "BoomBox")
                    {
                        if (!isIterationTextVisible)
                        {
                            manager.SetIteractionText("W��czy�e� radio");
                            isIterationTextVisible = true;
                            if (audioMananger.boomBox != null)
                            {
                                audioMananger.PlayMusic();
                            }
                        }
                    }
                    if (collider.gameObject.tag == "Plant2")
                    {
                        if (!playerTextVisible)
                        {
                            manager.SetDialogueText("Moje super sekretne przemy�lenia....");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                        }
                    }
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
        if (timeSinceDialogVisible >= maxDialogTextVisible)
        {
            if (playerTextVisible)
            {
                manager.SetDialogueText("");
                playerTextVisible = false;
            }
            timeSinceDialogVisible = 0f;
        }
    }

}