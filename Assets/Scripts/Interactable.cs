using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    private float maxVisibleTime = 4f;
    private float timeSinceInfoVisible = 0f;
    private bool isIterationTextVisible = false;
    public UIManager manager;
    public MouseLook mouseLook;
    public PlayerMovment playerMovment;
    public AudioManager audioMananger;
    public EndGameScreen endGameScreen;
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
    private bool PianoFound = false;
    private bool CameraFound = false;
    private bool PilloFound = false;
    private bool LaundryBasketFound = false;
    private bool MugFound = false;
    private bool WeatFloorFound = false;
    private bool NewsFound = false;
    private float maxDialogTextVisible = 4f;
    private float timeSinceDialogVisible = 0f;
    private bool endGame = false;

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
            float interactRange =1.5f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                if (collider is not BoxCollider)
                {
                    if (collider.gameObject.tag == "VendingMachine")  // "Object" zamieni� na warto�� tagu przypisan� do konkretnego obiektu
                                                                      // dzi�ki temu b�dzie mo�na ustali� dla konkretnych obiekt�w wyswietlane teskty
                    {
                        if (!isIterationTextVisible && !VendingMachineFound)
                        {
                            manager.SetDialogueText("Musi, tu by� kto�, kto to wyja�ni. To bo nie mo�e by� prawdziwa gra.");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            audioMananger.PlaySFX(audioMananger.drinkWater);
                            manager.SetIteractionText("Napi�a� si�!"); //JEST DZWIEK
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f; // doda� dla wszystkich znajdowanych obiekt�w to zerowanie!
                            VendingMachineFound = true; //nowa zmienna!


                            //DO WBICIA DO G�OWY

                            //DODA� DO INNYCH OBIEKT�W TAK JAK TU. Czyli 1 - na g�r� i da� Private Bool,
                            //2 do tego fragmentu kodu 'if (!isIterationTextVisible' doda� -> && oraz now� nazw� <dopisa� Found>
                            //3 na samym dole da� t� now� nazw� ze znakiem '=' i dopiskiem 'true'


                        }
                    }
                    if (collider.gameObject.tag == "TrashCan") // tu tag obiektu, dla ktorego wysw. bedze tekst
                    {
                        if (!isIterationTextVisible && !TrashCanFound)
                        {
                            manager.SetDialogueText("Serio? Kto to wymy�li�");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Znalaz�a� znajd�k�");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            TrashCanFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "LoungeChair2")
                    {
                        if (!isIterationTextVisible && !LoungeChair2Found)
                        {
                            manager.SetDialogueText("Jeszcze jedna. Chwila, jak to wygl�da?");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Znalaz�a� znajd�k�");
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
                            manager.SetIteractionText("Znalaz�a� znajd�k�");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            CoffeTableFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Plant2")
                    {
                        if (!playerTextVisible && !Plant2Found)
                        {
                            manager.SetDialogueText("Co? Znajd�ka? To ...to gra?");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Znalaz�a� znajd�k�");
                            isIterationTextVisible = true;
                            playerMovment.points++;
                            Plant2Found = true;
                        }
                    }
                    if (collider.gameObject.tag == "BookOpen") // JEST DZWIEK
                    {
                        if (!playerTextVisible && !BookOpenFound)
                        {

                            manager.SetDialogueText("'Przeczyts�a� ksi��k�?' Jak?! Nie ruszy�am tego!");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            audioMananger.PlaySFX(audioMananger.paper);
                            manager.SetIteractionText("Przeczyta� ksi��k�");
                            isIterationTextVisible = true;
                            BookOpenFound = true;
                        }
                    }

                    if (collider.gameObject.tag == "WaterDispenser")
                    {
                        if (!isIterationTextVisible && !WaterDispenserFound)
                        {
                            manager.SetDialogueText("Tak, to wiem. Tylko nie widz� r�ki z wod�");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            audioMananger.PlaySFX(audioMananger.bubbles);
                            manager.SetIteractionText("Wypi�a� wod�");
                            isIterationTextVisible = true;
                            WaterDispenserFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "microwave")
                    {
                        if (!isIterationTextVisible && !microwaveFound)
                        {
                            manager.SetDialogueText("Mmm, ale pachnie ta Hawajska");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Odgrza�a� pizze");
                            isIterationTextVisible = true;
                            microwaveFound = true;
                            audioMananger.PlaySFX(audioMananger.microvawe);
                        }
                    }
                    if (collider.gameObject.tag == "CoffeeMachine")
                    {
                        if (!playerTextVisible && !CoffeeMachineFound)
                        {
                            manager.SetDialogueText("Jakie dobre Latte");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Wypi�a� kaw�");
                            isIterationTextVisible = true;
                            CoffeeMachineFound = true;
                            audioMananger.PlaySFX(audioMananger.makingCaffee);
                        }
                    }
                    if (collider.gameObject.tag == "BoomBox")
                    {
                        if (!isIterationTextVisible && !BoomBoxFound)
                        {
                            manager.SetIteractionText("W��czy�a� radio");
                            isIterationTextVisible = true;
                            if (audioMananger.boomBox != null)
                            {
                                audioMananger.PlayMusic(audioMananger.boomBox);
                            }
                            BoomBoxFound = true;
                        }
                    }

                    if (collider.gameObject.tag == "EsterEnd" && playerMovment.points >= 3) // co najmniej trzy znajdzki do zakonczenia gry
                    {
                        if (!playerTextVisible)
                        {
                            manager.SetDialogueText("NIE POWINNO CI� TU BY�, JULIO!");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            endGame = true;
                        }
                    }
                    if (collider.gameObject.tag == "Piano")
                    {
                        if (!playerTextVisible && !PianoFound)
                        {
                            manager.SetDialogueText("Ah, pianino. Jedyna normalna rzecz!");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Zagra�a� na pianinie");
                            isIterationTextVisible = true;
                            PianoFound = true;
                            if (audioMananger.Piano != null)
                            {
                                audioMananger.PlayMusic(audioMananger.Piano);
                            }
                            PianoFound = true;
                        }
                    }

                    if (collider.gameObject.tag == "Camera")
                    {
                        if (!playerTextVisible && !CameraFound)
                        {
                            manager.SetDialogueText("A, gdzie to zdj�cie?");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            audioMananger.PlaySFX(audioMananger.takePhoto);
                            manager.SetIteractionText("Zrobi�a� zdj�cie");
                            isIterationTextVisible = true;
                            CameraFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Pillow")
                    {
                        if (!playerTextVisible && !PilloFound)
                        {
                            manager.SetDialogueText("O jak mi�o i jak mi�kko");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Pufa");
                            isIterationTextVisible = true;
                            PilloFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "LaundryBasket")
                    {
                        if (!playerTextVisible && !LaundryBasketFound)
                        {
                            manager.SetDialogueText("Co?");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("!au$jd@w#ed%hg^*$yjd8ts");
                            isIterationTextVisible = true;
                            LaundryBasketFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Mug")
                    {
                        if (!playerTextVisible && !MugFound)
                        {
                            manager.SetDialogueText("Umyj�, co mi szkodzi");
                            playerTextVisible = true;
                            audioMananger.PlaySFX(audioMananger.dishes);
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Brudne naczynia");
                            isIterationTextVisible = true;
                            MugFound = true;
                        }

                    }
                    if (collider.gameObject.tag == "WeatFloor")
                    {
                        if (!playerTextVisible && !WeatFloorFound)
                        {
                            manager.SetDialogueText("Co? Jak? Pod�oga jest sucha");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText(" 'Mokra Pod�oga' ");
                            isIterationTextVisible = true;
                            WeatFloorFound = true;
                        }

                    }
                    if (collider.gameObject.tag == "News")
                    {
                        if (!playerTextVisible && !NewsFound)
                        {
                            manager.SetDialogueText("Co? Czemu m�j cie� jest walcem?");
                            playerTextVisible = true;
                            timeSinceDialogVisible = 0f;
                            manager.SetIteractionText("Nie ma tu znajdziek");
                            isIterationTextVisible = true;
                            NewsFound = true;
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
                if (endGame)
                {
                    endGameScreen.showEndGameScreen();
                }
            }
            timeSinceDialogVisible = 0f;
        }
    }

}