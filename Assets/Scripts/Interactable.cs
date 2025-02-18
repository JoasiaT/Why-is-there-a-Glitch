using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float maxVisibleTime = 3.5f;
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
    private bool VendingMachineFound = false;
    private bool BookOpenFound = false;
    private bool WaterDispenserFound = false;
    private bool microwaveFound = false;
    private bool CoffeeMachineFound = false;
    private bool BoomBoxFound = false;
    private float maxDialogTextVisible = 4f;
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
                    if (collider.gameObject.tag == "VendingMachine")  // "Object" zamieniæ na wartoœæ tagu przypisan¹ do konkretnego obiektu
                                                                      // dziêki temu bêdzie mo¿na ustaliæ dla konkretnych obiektów wyswietlane teskty
                    {
                        if (!isIterationTextVisible && !VendingMachineFound)
                        {
                            manager.SetDialogueText("Musi, tu byæ ktoœ, kto to wyjaœni.To bo nie mo¿e byæ prawdziwa gra.");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Napi³eœ siê!");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f; // dodaæ dla wszystkich znajdowanych obiektów to zerowanie!
                            VendingMachineFound = true; //nowa zmienna!


                                                                    //DO WBICIA DO G£OWY

                                             //DODAÆ DO INNYCH OBIEKTÓW TAK JAK TU. Czyli 1 - na górê i daæ Private Bool,
                                            //2 do tego fragmentu kodu 'if (!isIterationTextVisible' dodaæ -> && oraz now¹ nazwê <dopisaæ Found>
                                           //3 na samym dole daæ t¹ now¹ nazwê ze znakiem '=' i dopiskiem 'true'


                        }
                    }
                    if (collider.gameObject.tag == "TrashCan") // tu tag obiektu, dla ktorego wysw. bedze tekst
                    {
                        if (!isIterationTextVisible && !TrashCanFound)
                        {
                            manager.SetDialogueText("Serio? Kto to wymyœli³");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Znalaz³eœ znajdŸkê");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            TrashCanFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "LoungeChair2")
                    {
                        if (!isIterationTextVisible && !LoungeChair2Found)
                        {
                            manager.SetDialogueText("Jeszcze jedna. Chwila, jak to wygl¹da?");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Znalaz³eœ znajdŸkê");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            LoungeChair2Found = true;
                        }
                    }
                    if (collider.gameObject.tag == "CoffeTable")
                    {
                        if (!isIterationTextVisible && !CoffeTableFound)
                        {
                            manager.SetDialogueText("Wiem, gdzie jestem ...tylko nie panikuj, nie panikuj");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Znalaz³eœ znajdŸkê");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            CoffeTableFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Plant2")
                    {
                        if (!playerTextVisible && !Plant2Found)
                        {
                            manager.SetDialogueText("Co? ZnajdŸka? To ...to gra?");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Znalaz³eœ znajdŸkê");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            Plant2Found = true; 
                        }
                    }
                    if (collider.gameObject.tag == "BookOpen")
                    {
                        if (!playerTextVisible && !BookOpenFound)
                        {
                            manager.SetDialogueText("'Przeczyts³eœ ksi¹¿kê?' Jak?! Nie ruszy³am tego!");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Przeczyts³eœ ksi¹¿kê");
                            isIterationTextVisible = true;
                            BookOpenFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "WaterDispenser")
                    {
                        if (!isIterationTextVisible && !WaterDispenserFound) //Wci¹¿ tu nie dzia³a, mimo poprawki
                        {
                            manager.SetDialogueText("Tak, to wiem.Tylko nie widzê rêki z wod¹");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Wypi³eœ wodê");
                            isIterationTextVisible = true;
                            WaterDispenserFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "microwave")
                    {
                        if (!isIterationTextVisible && !microwaveFound)
                        {
                            manager.SetDialogueText("Mmm, ale pachnie ta Hawajsk");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Odgrza³eœ pizze");
                            isIterationTextVisible = true;
                            microwaveFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "CoffeeMachine")
                    {
                        if (!playerTextVisible && !CoffeeMachineFound)
                        {
                            manager.SetDialogueText("Jakie dobre Latte");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Wypi³eœ kawê");
                            isIterationTextVisible = true;
                            CoffeeMachineFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "BoomBox") //1
                    {
                        if (!isIterationTextVisible && !BoomBoxFound)
                        {
                            manager.SetIteractionText("W³¹czy³eœ radio");
                            isIterationTextVisible = true;
                            if (audioMananger.boomBox != null)
                            {
                                audioMananger.PlayMusic();
                            }
                            BoomBoxFound = true;
                        }
                    }

                    if (collider.gameObject.tag == "EsterEnd") //4
                    {
                        if (!playerTextVisible)
                        {
                            manager.SetDialogueText("NIE POWINNO CIÊ TU BYÆ, JULIO!"); // Tu daæ tekst na kolizjê ze œcian¹
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;

                        }
                    }






                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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