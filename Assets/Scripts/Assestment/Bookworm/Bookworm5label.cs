using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bookworm5label : MonoBehaviour
{
    [SerializeField] private Text[] correctLeterLabel;

    [SerializeField] private Text[] buttonTextChoices;

    [SerializeField] private Button[] buttonChoices;
    [SerializeField] private Button selectedButton;

    [SerializeField] private GameObject currentQuestion;

   
    //[SerializeField] private GameObject wrongPopup;

    [SerializeField] private List<char> Answer5label = new List<char>();

    [SerializeField] private List<char> AnswerToButtons = new List<char>();

    private char letterCorrect;

    [SerializeField] private char[] wrongLetters;
    [SerializeField] private char[] correctLetters;
    private int totalLabel;

    private bool isCorrect;
    private bool isAnswerEmpty;

    public static float currentTime = 0f;
    [SerializeField] private float startingTime;
    playerBookWormHealth PlayerBookWormHealth;

    public static bool isTimeIsUp = false;
    [SerializeField] Text countdownText;

    private void Awake()
    {
        PlayerBookWormHealth = GameObject.Find("Main Camera").GetComponent<playerBookWormHealth>();
    }
    private void Start()
    {
        selectedButton.Select();
        totalLabel = correctLeterLabel.Count();
        breakWrongLetters();
        breakCorrectLetters();
        buttonClicked();

        currentTime = startingTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            buttonOk();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            buttonClear();
            Actions.clearSoundEffect?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            selectedButton.Select();
        }


        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            Actions.BWBossAttackSoundEffect?.Invoke();
            buttonClear();
            currentQuestion.SetActive(false);
            PlayerBookWormHealth.bookwormTakeDamage(.5f);
            currentTime = 30;
        }

    }
    private void buttonClicked()
    {
        if (totalLabel == 5)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));

            buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[1].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[7].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[8]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[9]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[10]));
        }
        if (totalLabel == 6)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));
            buttonChoices[3].onClick.AddListener(() => btnCorrectChoices(correctLetters[5]));

            buttonChoices[1].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[7].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[8]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[9]));
        }
        else if (totalLabel == 3)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));   

            buttonChoices[1].onClick.AddListener(() => btnWrongChoices(wrongLetters[12]));
            buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[4].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[5].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[7].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));

            buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));

            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[8]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[9]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[10]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[11]));
        }
        else if (totalLabel == 4)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));

            buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[4].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[5].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[7].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));

            buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));

            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[8]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[9]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[10]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[11]));
        }
        else if (totalLabel == 2)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));

            buttonChoices[1].onClick.AddListener(() => btnWrongChoices(wrongLetters[13]));
            buttonChoices[6].onClick.AddListener(() => btnWrongChoices(wrongLetters[12]));
            buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[4].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[5].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[7].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
            buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));
            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[8]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[9]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[10]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[11]));
        }
        else if (totalLabel == 10)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));
            buttonChoices[3].onClick.AddListener(() => btnCorrectChoices(correctLetters[5]));
            buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[6]));
            buttonChoices[7].onClick.AddListener(() => btnCorrectChoices(correctLetters[7]));
            buttonChoices[8].onClick.AddListener(() => btnCorrectChoices(correctLetters[8]));
            buttonChoices[9].onClick.AddListener(() => btnCorrectChoices(correctLetters[9]));

            
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
        }
        else if (totalLabel == 9)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));
            buttonChoices[3].onClick.AddListener(() => btnCorrectChoices(correctLetters[5]));
            buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[6]));
            buttonChoices[7].onClick.AddListener(() => btnCorrectChoices(correctLetters[7]));
            buttonChoices[8].onClick.AddListener(() => btnCorrectChoices(correctLetters[8]));

            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
        }
        else if (totalLabel == 8)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));
            buttonChoices[3].onClick.AddListener(() => btnCorrectChoices(correctLetters[5]));
            buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[6]));
            buttonChoices[7].onClick.AddListener(() => btnCorrectChoices(correctLetters[7]));

            buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));
        }
        else if (totalLabel == 7)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));
            buttonChoices[3].onClick.AddListener(() => btnCorrectChoices(correctLetters[5]));
            buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[6]));  

            buttonChoices[7].onClick.AddListener(() => btnWrongChoices(wrongLetters[8]));
            buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));
        }
        else if (totalLabel == 12)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));
            buttonChoices[3].onClick.AddListener(() => btnCorrectChoices(correctLetters[5]));
            buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[6]));
            buttonChoices[7].onClick.AddListener(() => btnCorrectChoices(correctLetters[7]));
            buttonChoices[8].onClick.AddListener(() => btnCorrectChoices(correctLetters[8]));
            buttonChoices[9].onClick.AddListener(() => btnCorrectChoices(correctLetters[9]));
            buttonChoices[10].onClick.AddListener(() => btnCorrectChoices(correctLetters[10]));
            buttonChoices[11].onClick.AddListener(() => btnCorrectChoices(correctLetters[11]));

            buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
        }
        else if (totalLabel == 14)
        {
            buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
            buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
            buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
            buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
            buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));
            buttonChoices[3].onClick.AddListener(() => btnCorrectChoices(correctLetters[5]));
            buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[6]));
            buttonChoices[7].onClick.AddListener(() => btnCorrectChoices(correctLetters[7]));
            buttonChoices[8].onClick.AddListener(() => btnCorrectChoices(correctLetters[8]));
            buttonChoices[9].onClick.AddListener(() => btnCorrectChoices(correctLetters[9]));
            buttonChoices[10].onClick.AddListener(() => btnCorrectChoices(correctLetters[10]));
            buttonChoices[11].onClick.AddListener(() => btnCorrectChoices(correctLetters[11]));
            buttonChoices[12].onClick.AddListener(() => btnCorrectChoices(correctLetters[12]));
            buttonChoices[13].onClick.AddListener(() => btnCorrectChoices(correctLetters[13]));

            buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
            buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
        }
      
    }
    private void breakCorrectLetters()
    {
        if (totalLabel == 5)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString();
            buttonTextChoices[4].text = correctLetters[4].ToString();
        } 
        else if (totalLabel == 6)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString(); 
            buttonTextChoices[4].text = correctLetters[4].ToString(); 
            buttonTextChoices[3].text = correctLetters[5].ToString(); 
        } 
        else if (totalLabel == 3)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }

            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();  
        }
        else if (totalLabel == 4)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }

            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[1].text = correctLetters[3].ToString();
        }
        else if (totalLabel == 2)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }

            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();  
        }
        else if (totalLabel == 10)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString();
            buttonTextChoices[4].text = correctLetters[4].ToString();
            buttonTextChoices[3].text = correctLetters[5].ToString();
            buttonTextChoices[1].text = correctLetters[6].ToString();
            buttonTextChoices[7].text = correctLetters[7].ToString();
            buttonTextChoices[8].text = correctLetters[8].ToString();  
            buttonTextChoices[9].text = correctLetters[9].ToString();
        }
        else if (totalLabel == 9)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString();
            buttonTextChoices[4].text = correctLetters[4].ToString();
            buttonTextChoices[3].text = correctLetters[5].ToString();
            buttonTextChoices[1].text = correctLetters[6].ToString();
            buttonTextChoices[7].text = correctLetters[7].ToString();
            buttonTextChoices[8].text = correctLetters[8].ToString();  
        }
        else if (totalLabel == 7)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString();
            buttonTextChoices[4].text = correctLetters[4].ToString();
            buttonTextChoices[3].text = correctLetters[5].ToString();
            buttonTextChoices[1].text = correctLetters[6].ToString();      
        }
        else if (totalLabel == 8)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString();
            buttonTextChoices[4].text = correctLetters[4].ToString();
            buttonTextChoices[3].text = correctLetters[5].ToString();
            buttonTextChoices[1].text = correctLetters[6].ToString();
            buttonTextChoices[7].text = correctLetters[7].ToString();  
        }
        else if (totalLabel == 12)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString();
            buttonTextChoices[4].text = correctLetters[4].ToString();
            buttonTextChoices[3].text = correctLetters[5].ToString();
            buttonTextChoices[1].text = correctLetters[6].ToString();
            buttonTextChoices[7].text = correctLetters[7].ToString();
            buttonTextChoices[8].text = correctLetters[8].ToString();
            buttonTextChoices[9].text = correctLetters[9].ToString();
            buttonTextChoices[10].text = correctLetters[10].ToString();
            buttonTextChoices[11].text = correctLetters[11].ToString();
        }
        else if (totalLabel == 14)
        {
            for (int i = 0; i < correctLetters.Length; i++)
            {
                correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerToButtons, letterCorrect);
            }
            buttonTextChoices[0].text = correctLetters[0].ToString();
            buttonTextChoices[2].text = correctLetters[1].ToString();
            buttonTextChoices[6].text = correctLetters[2].ToString();
            buttonTextChoices[5].text = correctLetters[3].ToString();
            buttonTextChoices[4].text = correctLetters[4].ToString();
            buttonTextChoices[3].text = correctLetters[5].ToString();
            buttonTextChoices[1].text = correctLetters[6].ToString();
            buttonTextChoices[7].text = correctLetters[7].ToString();
            buttonTextChoices[8].text = correctLetters[8].ToString();
            buttonTextChoices[9].text = correctLetters[9].ToString();
            buttonTextChoices[10].text = correctLetters[10].ToString();
            buttonTextChoices[11].text = correctLetters[11].ToString();
            buttonTextChoices[12].text = correctLetters[12].ToString();
            buttonTextChoices[13].text = correctLetters[13].ToString();
        }



    }
    private void breakWrongLetters()
    {
        if (totalLabel == 5)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }
            buttonTextChoices[3].text = wrongLetters[0].ToString();
            buttonTextChoices[1].text = wrongLetters[1].ToString();
            buttonTextChoices[7].text = wrongLetters[2].ToString();
            buttonTextChoices[8].text = wrongLetters[3].ToString();
            buttonTextChoices[9].text = wrongLetters[4].ToString();
            buttonTextChoices[10].text = wrongLetters[5].ToString();
            buttonTextChoices[11].text = wrongLetters[6].ToString();
            buttonTextChoices[12].text = wrongLetters[7].ToString();
            buttonTextChoices[13].text = wrongLetters[8].ToString();
            buttonTextChoices[14].text = wrongLetters[9].ToString();
            buttonTextChoices[15].text = wrongLetters[10].ToString();
        }
        else if (totalLabel == 6)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }  
            buttonTextChoices[1].text = wrongLetters[0].ToString();
            buttonTextChoices[7].text = wrongLetters[1].ToString();
            buttonTextChoices[8].text = wrongLetters[2].ToString();
            buttonTextChoices[9].text = wrongLetters[3].ToString();
            buttonTextChoices[10].text = wrongLetters[4].ToString();
            buttonTextChoices[11].text = wrongLetters[5].ToString();
            buttonTextChoices[12].text = wrongLetters[6].ToString();
            buttonTextChoices[13].text = wrongLetters[7].ToString();
            buttonTextChoices[14].text = wrongLetters[8].ToString();
            buttonTextChoices[15].text = wrongLetters[9].ToString();
        }
        else if (totalLabel == 3)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }

            buttonTextChoices[1].text = wrongLetters[12].ToString();
            buttonTextChoices[3].text = wrongLetters[0].ToString();
            buttonTextChoices[4].text = wrongLetters[1].ToString();
            buttonTextChoices[5].text = wrongLetters[2].ToString();
            buttonTextChoices[7].text = wrongLetters[3].ToString();
            buttonTextChoices[8].text = wrongLetters[4].ToString();
            buttonTextChoices[9].text = wrongLetters[5].ToString();
            buttonTextChoices[10].text = wrongLetters[6].ToString();
            buttonTextChoices[11].text = wrongLetters[7].ToString();
            buttonTextChoices[12].text = wrongLetters[8].ToString();
            buttonTextChoices[13].text = wrongLetters[9].ToString();
            buttonTextChoices[14].text = wrongLetters[10].ToString();
            buttonTextChoices[15].text = wrongLetters[11].ToString();
        }
        else if (totalLabel == 4)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }

            buttonTextChoices[3].text = wrongLetters[0].ToString();
            buttonTextChoices[4].text = wrongLetters[1].ToString();
            buttonTextChoices[5].text = wrongLetters[2].ToString();
            buttonTextChoices[7].text = wrongLetters[3].ToString();
            buttonTextChoices[8].text = wrongLetters[4].ToString();
            buttonTextChoices[9].text = wrongLetters[5].ToString();
            buttonTextChoices[10].text = wrongLetters[6].ToString();
            buttonTextChoices[11].text = wrongLetters[7].ToString();
            buttonTextChoices[12].text = wrongLetters[8].ToString();
            buttonTextChoices[13].text = wrongLetters[9].ToString();
            buttonTextChoices[14].text = wrongLetters[10].ToString();
            buttonTextChoices[15].text = wrongLetters[11].ToString();
        }
        else if (totalLabel == 2)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }

            buttonTextChoices[1].text = wrongLetters[13].ToString();
            buttonTextChoices[6].text = wrongLetters[12].ToString();
            buttonTextChoices[3].text = wrongLetters[0].ToString();
            buttonTextChoices[4].text = wrongLetters[1].ToString();
            buttonTextChoices[5].text = wrongLetters[2].ToString();
            buttonTextChoices[7].text = wrongLetters[3].ToString();
            buttonTextChoices[8].text = wrongLetters[4].ToString();
            buttonTextChoices[9].text = wrongLetters[5].ToString();
            buttonTextChoices[10].text = wrongLetters[6].ToString();
            buttonTextChoices[11].text = wrongLetters[7].ToString();
            buttonTextChoices[12].text = wrongLetters[8].ToString();
            buttonTextChoices[13].text = wrongLetters[9].ToString();
            buttonTextChoices[14].text = wrongLetters[10].ToString();
            buttonTextChoices[15].text = wrongLetters[11].ToString();
        }
        else if (totalLabel == 10)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }
            buttonTextChoices[10].text = wrongLetters[0].ToString();
            buttonTextChoices[11].text = wrongLetters[1].ToString();
            buttonTextChoices[12].text = wrongLetters[2].ToString();
            buttonTextChoices[13].text = wrongLetters[3].ToString();
            buttonTextChoices[14].text = wrongLetters[4].ToString();
            buttonTextChoices[15].text = wrongLetters[5].ToString();
        }
        else if (totalLabel == 9)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }
            buttonTextChoices[9].text = wrongLetters[0].ToString();
            buttonTextChoices[10].text = wrongLetters[1].ToString();
            buttonTextChoices[11].text = wrongLetters[2].ToString();
            buttonTextChoices[12].text = wrongLetters[3].ToString();
            buttonTextChoices[13].text = wrongLetters[4].ToString();
            buttonTextChoices[14].text = wrongLetters[5].ToString();
            buttonTextChoices[15].text = wrongLetters[6].ToString();
        }

        else if (totalLabel == 7)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }
            buttonTextChoices[7].text = wrongLetters[8].ToString();
            buttonTextChoices[8].text = wrongLetters[0].ToString();
            buttonTextChoices[9].text = wrongLetters[1].ToString();
            buttonTextChoices[10].text = wrongLetters[2].ToString();
            buttonTextChoices[11].text = wrongLetters[3].ToString();
            buttonTextChoices[12].text = wrongLetters[4].ToString();
            buttonTextChoices[13].text = wrongLetters[5].ToString();
            buttonTextChoices[14].text = wrongLetters[6].ToString();
            buttonTextChoices[15].text = wrongLetters[7].ToString();
        }
        else if (totalLabel == 8)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }
            buttonTextChoices[8].text = wrongLetters[0].ToString();
            buttonTextChoices[9].text = wrongLetters[1].ToString();
            buttonTextChoices[10].text = wrongLetters[2].ToString();
            buttonTextChoices[11].text = wrongLetters[3].ToString();
            buttonTextChoices[12].text = wrongLetters[4].ToString();
            buttonTextChoices[13].text = wrongLetters[5].ToString();
            buttonTextChoices[14].text = wrongLetters[6].ToString();
            buttonTextChoices[15].text = wrongLetters[7].ToString();
        }
        else if (totalLabel == 12)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }
            buttonTextChoices[12].text = wrongLetters[0].ToString();
            buttonTextChoices[13].text = wrongLetters[1].ToString();
            buttonTextChoices[14].text = wrongLetters[2].ToString();
            buttonTextChoices[15].text = wrongLetters[3].ToString(); 
        }
        else if (totalLabel == 14)
        {
            for (int i = 0; i < wrongLetters.Length; i++)
            {
                wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
            }
            buttonTextChoices[14].text = wrongLetters[0].ToString();
            buttonTextChoices[15].text = wrongLetters[1].ToString(); 
        }


    }
    public void btnCorrectChoices(char CollectLetters)
    {
        if (totalLabel == 5)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
        }
        else if (totalLabel == 6)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = CollectLetters.ToString();
            }
        }
        else if (totalLabel == 3)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();
            }
        }
        else if (totalLabel == 4)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
        }
        else if (totalLabel == 2)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }      
        }
        else if (totalLabel == 10)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = CollectLetters.ToString();
            } 
            else if (correctLeterLabel[9].text == "_")
            {
                correctLeterLabel[9].text = CollectLetters.ToString();
            } 
        }
        else if (totalLabel == 9)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = CollectLetters.ToString();
            } 
        }

        else if (totalLabel == 7)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = CollectLetters.ToString();
            }        
        }
        else if (totalLabel == 8)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = CollectLetters.ToString();
            }         
        }
        else if (totalLabel == 12)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[9].text == "_")
            {
                correctLeterLabel[9].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[10].text == "_")
            {
                correctLeterLabel[10].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[11].text == "_")
            {
                correctLeterLabel[11].text = CollectLetters.ToString();
            }  
        }
        else if (totalLabel == 14)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = CollectLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[9].text == "_")
            {
                correctLeterLabel[9].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[10].text == "_")
            {
                correctLeterLabel[10].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[11].text == "_")
            {
                correctLeterLabel[11].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[12].text == "_")
            {
                correctLeterLabel[12].text = CollectLetters.ToString();
            }
            else if (correctLeterLabel[13].text == "_")
            {
                correctLeterLabel[13].text = CollectLetters.ToString();
            }
        }

    }
    public void btnWrongChoices(char WrongLetters)
    {
        if (totalLabel == 5)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
        }
        else if (totalLabel == 6)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = WrongLetters.ToString();
            }
        }
        else if (totalLabel == 3)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
        }
        else if (totalLabel == 4)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();

            }
        }
        else if (totalLabel == 2)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();
            }
        }
        else if (totalLabel == 10)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[9].text == "_")
            {
                correctLeterLabel[9].text = WrongLetters.ToString();
            }
        }
        else if (totalLabel == 9)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = WrongLetters.ToString();
            }
        }

        else if (totalLabel == 7)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = WrongLetters.ToString();
            }       
        }
        else if (totalLabel == 8)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = WrongLetters.ToString();
            }
        }
        else if (totalLabel == 12)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[9].text == "_")
            {
                correctLeterLabel[9].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[10].text == "_")
            {
                correctLeterLabel[10].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[11].text == "_")
            {
                correctLeterLabel[11].text = WrongLetters.ToString();
            }
        }
        else if (totalLabel == 14)
        {
            if (correctLeterLabel[0].text == "_")
            {
                correctLeterLabel[0].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[1].text == "_")
            {
                correctLeterLabel[1].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[2].text == "_")
            {
                correctLeterLabel[2].text = WrongLetters.ToString();

            }
            else if (correctLeterLabel[3].text == "_")
            {
                correctLeterLabel[3].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[4].text == "_")
            {
                correctLeterLabel[4].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[5].text == "_")
            {
                correctLeterLabel[5].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[6].text == "_")
            {
                correctLeterLabel[6].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[7].text == "_")
            {
                correctLeterLabel[7].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[8].text == "_")
            {
                correctLeterLabel[8].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[9].text == "_")
            {
                correctLeterLabel[9].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[10].text == "_")
            {
                correctLeterLabel[10].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[11].text == "_")
            {
                correctLeterLabel[11].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[12].text == "_")
            {
                correctLeterLabel[12].text = WrongLetters.ToString();
            }
            else if (correctLeterLabel[13].text == "_")
            {
                correctLeterLabel[13].text = WrongLetters.ToString();
            }
        }


    }
    public void buttonClear()
    {
        if (totalLabel == 5)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
        }
        else if (totalLabel == 6)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
            correctLeterLabel[5].text = "_";
        }
        else if (totalLabel == 4)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
        }
        else if (totalLabel == 3)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
        }
        else if (totalLabel == 2)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";  
        }
        else if (totalLabel == 10)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
            correctLeterLabel[5].text = "_";
            correctLeterLabel[6].text = "_";
            correctLeterLabel[7].text = "_";
            correctLeterLabel[8].text = "_";
            correctLeterLabel[9].text = "_";
        }
        else if (totalLabel == 9)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
            correctLeterLabel[5].text = "_";
            correctLeterLabel[6].text = "_";
            correctLeterLabel[7].text = "_";
            correctLeterLabel[8].text = "_";
        }
        else if (totalLabel == 8)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
            correctLeterLabel[5].text = "_";
            correctLeterLabel[6].text = "_";
            correctLeterLabel[7].text = "_";
        }
        else if (totalLabel == 7)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
            correctLeterLabel[5].text = "_";
            correctLeterLabel[6].text = "_";
        }
        else if (totalLabel == 12)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
            correctLeterLabel[5].text = "_";
            correctLeterLabel[6].text = "_";
            correctLeterLabel[7].text = "_";
            correctLeterLabel[8].text = "_";
            correctLeterLabel[9].text = "_";
            correctLeterLabel[10].text = "_";
            correctLeterLabel[11].text = "_";
        }
        else if (totalLabel == 14)
        {
            correctLeterLabel[0].text = "_";
            correctLeterLabel[1].text = "_";
            correctLeterLabel[2].text = "_";
            correctLeterLabel[3].text = "_";
            correctLeterLabel[4].text = "_";
            correctLeterLabel[5].text = "_";
            correctLeterLabel[6].text = "_";
            correctLeterLabel[7].text = "_";
            correctLeterLabel[8].text = "_";
            correctLeterLabel[9].text = "_";
            correctLeterLabel[10].text = "_";
            correctLeterLabel[11].text = "_";
            correctLeterLabel[12].text = "_";
            correctLeterLabel[13].text = "_";
        }

    }
    public bool checkAnswerBreak()
    {     
        if (totalLabel == 5)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString();
        }
        else if (totalLabel == 6)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString() 
           && correctLeterLabel[5].text == Answer5label[5].ToString();
        }
        else if (totalLabel == 4)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString();
        }
        else if (totalLabel == 3)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString();
        }
        else if (totalLabel == 2)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString();
        }
        else if (totalLabel == 10)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString()
           && correctLeterLabel[5].text == Answer5label[5].ToString() && correctLeterLabel[6].text == Answer5label[6].ToString()
           && correctLeterLabel[7].text == Answer5label[7].ToString() && correctLeterLabel[8].text == Answer5label[8].ToString() && correctLeterLabel[9].text == Answer5label[9].ToString();
        }
        else if (totalLabel == 9)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString()
           && correctLeterLabel[5].text == Answer5label[5].ToString() && correctLeterLabel[6].text == Answer5label[6].ToString()
           && correctLeterLabel[7].text == Answer5label[7].ToString() && correctLeterLabel[8].text == Answer5label[8].ToString();
        }
        else if (totalLabel == 7)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString()
           && correctLeterLabel[5].text == Answer5label[5].ToString() && correctLeterLabel[6].text == Answer5label[6].ToString();
        } 
        else if (totalLabel == 8)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString()
           && correctLeterLabel[5].text == Answer5label[5].ToString() && correctLeterLabel[6].text == Answer5label[6].ToString()
           && correctLeterLabel[7].text == Answer5label[7].ToString();
        }
        else if (totalLabel == 12)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString()
           && correctLeterLabel[5].text == Answer5label[5].ToString() && correctLeterLabel[6].text == Answer5label[6].ToString() && correctLeterLabel[7].text == Answer5label[7].ToString() 
           && correctLeterLabel[8].text == Answer5label[8].ToString() && correctLeterLabel[9].text == Answer5label[9].ToString() && correctLeterLabel[10].text == Answer5label[10].ToString() 
           && correctLeterLabel[11].text == Answer5label[11].ToString();
        }
        else if (totalLabel == 14)
        {
            isCorrect = correctLeterLabel[0].text == Answer5label[0].ToString() && correctLeterLabel[1].text == Answer5label[1].ToString() &&
           correctLeterLabel[2].text == Answer5label[2].ToString() && correctLeterLabel[3].text == Answer5label[3].ToString() && correctLeterLabel[4].text == Answer5label[4].ToString()
           && correctLeterLabel[5].text == Answer5label[5].ToString() && correctLeterLabel[6].text == Answer5label[6].ToString() && correctLeterLabel[7].text == Answer5label[7].ToString() 
           && correctLeterLabel[8].text == Answer5label[8].ToString() && correctLeterLabel[9].text == Answer5label[9].ToString() && correctLeterLabel[10].text == Answer5label[10].ToString() 
           && correctLeterLabel[11].text == Answer5label[11].ToString() && correctLeterLabel[12].text == Answer5label[12].ToString() && correctLeterLabel[13].text == Answer5label[13].ToString();
        }

        return isCorrect;
    }
    public bool checkAnswerIfEmpty()
    {      
        if (totalLabel == 5)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
            && correctLeterLabel[4].text == "_";
        }
        else if (totalLabel == 6)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
            && correctLeterLabel[4].text == "_" && correctLeterLabel[5].text == "_";
        }
        else if (totalLabel == 3)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_";
        }
        else if (totalLabel == 4)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_";
        }
        else if (totalLabel == 2)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_";
        }
        else if (totalLabel == 10)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
            && correctLeterLabel[4].text == "_" && correctLeterLabel[5].text == "_" && correctLeterLabel[6].text == "_"
            && correctLeterLabel[7].text == "_" && correctLeterLabel[8].text == "_" && correctLeterLabel[9].text == "_";
        }
        else if (totalLabel == 9)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
            && correctLeterLabel[4].text == "_" && correctLeterLabel[5].text == "_" && correctLeterLabel[6].text == "_"
            && correctLeterLabel[7].text == "_" && correctLeterLabel[8].text == "_";
        }
        else if (totalLabel == 7)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
            && correctLeterLabel[4].text == "_" && correctLeterLabel[5].text == "_" && correctLeterLabel[6].text == "_"; 
        }
        else if (totalLabel == 8)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
            && correctLeterLabel[4].text == "_" && correctLeterLabel[5].text == "_" && correctLeterLabel[6].text == "_" && correctLeterLabel[7].text == "_";
        }

        else if (totalLabel == 12)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
            && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
            && correctLeterLabel[4].text == "_" && correctLeterLabel[5].text == "_" && correctLeterLabel[6].text == "_"
            && correctLeterLabel[7].text == "_" && correctLeterLabel[8].text == "_" && correctLeterLabel[9].text == "_" && correctLeterLabel[10].text == "_"
            && correctLeterLabel[11].text == "_";
        }
        else if (totalLabel == 14)
        {
            isAnswerEmpty = correctLeterLabel[0].text == "_" && correctLeterLabel[1].text == "_"
           && correctLeterLabel[2].text == "_" && correctLeterLabel[3].text == "_"
           && correctLeterLabel[4].text == "_" && correctLeterLabel[5].text == "_" && correctLeterLabel[6].text == "_"
           && correctLeterLabel[7].text == "_" && correctLeterLabel[8].text == "_" && correctLeterLabel[9].text == "_" && correctLeterLabel[10].text == "_"
           && correctLeterLabel[11].text == "_" && correctLeterLabel[12].text == "_" && correctLeterLabel[13].text == "_";
        }
        return isAnswerEmpty;
            
    }
    public void buttonOk()
    {
        Actions.onCheckAnswerBW(currentQuestion, checkAnswerBreak, checkAnswerIfEmpty, buttonClear);
        buttonClear();
    }
    public void tryAgainButton()
    {
       // wrongPopup.SetActive(false);
        buttonClear();
    }
}
