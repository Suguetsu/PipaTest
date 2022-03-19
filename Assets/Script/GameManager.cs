using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// responsável por gerenciar o jogo.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;                 // torna a classe global

    [SerializeField] private Ball _ball;                // ball
    [SerializeField] private Transform ballParentT;     // referencia para insrancia
    [SerializeField] private MiniBall _ballMIni;        // mini ball
    [SerializeField] private Transform miniballParentT; // referencia para instancia
    [SerializeField] private Startup _start;


    [SerializeField] [Tooltip("Numeros jogados")] private List<int> playedNumber;
    [SerializeField] [Tooltip("Numeros armazenados")] private List<int> storeNumber;
    [SerializeField] [Tooltip("GameOver")] private GameObject endGameObj;


    public bool isEndGame { private set; get; }


    private int time;
    int rand;




    private void Awake()
    {
        instance = this; // torna essa classe statica

        endGameObj.gameObject.SetActive(false);
    }

    void Start()
    {
        time = 5;
        rand = Random.Range(1, 76);

        playedNumber = new List<int>();
        storeNumber = new List<int>();


        // enche a lista do numeros a serem jogaos.
        for (int i = 1; i < 76; i++)
        {

            storeNumber.Add(i);

        }




        StartCoroutine(Sorter());

      
    }



    private void Update()
    {



        if (isEndGame)
        {

            StopAllCoroutines();
            endGameObj.SetActive(true);
            return;
        }

        // verifica se o numero rando setado ja foi jogado
        // caso retorne true randomiza denovo
        for (int i = 0; i < playedNumber.Count; i++)
        {
            if (playedNumber[i] == rand)
                rand = Random.Range(1, 76);
            else
            {

                continue;
            }
        }
    }


    // responsável por gerenciar as listas do numero guardado e numero jogado.
    // instancia as ball, e as miniballs
    private IEnumerator Sorter()
    {

        yield return new WaitForSecondsRealtime(time);


        if (!storeNumber.Contains(rand))
        {
            rand = Random.Range(1, 76);
        }


        playedNumber.Insert(0, rand);



        if (playedNumber.Count > 1)
        {


            MiniBall temp = Instantiate(_ballMIni, miniballParentT.transform);
            temp.SetMiniBall(playedNumber[1]);

            for (int i = 0; i < storeNumber.Count; i++)
            {

                if (storeNumber[i] == playedNumber[1])
                {
                    storeNumber.Remove(storeNumber[i]);
                    storeNumber.Sort();
                    //playedNumber.Sort(); //>> tirar dps

                }

            }


            if (playedNumber.Count > 5)
            {
                Destroy(miniballParentT.GetChild(0).gameObject);
            }



        }
        else if (playedNumber.Count == 0)
        {


            if (miniballParentT.childCount > 0)
            {
                for (int i = 0; i < miniballParentT.childCount; i++)
                {
                    Destroy(miniballParentT.GetChild(i).gameObject);
                }
            }
        }

        if (ballParentT.childCount > 0)
        {

            Destroy(ballParentT.GetChild(0).gameObject);

        }

        Ball temp2 = Instantiate(_ball, ballParentT.transform);
        temp2.Set(playedNumber[0]);



        if (storeNumber.Count > 1)
        {
            StartCoroutine(Sorter());
        }
        else
        {
            StopAllCoroutines();
            playedNumber.Sort();

            if (storeNumber.Count > 0)
                storeNumber[0] = 0;

            Debug.Log("FIM DE JOGO");
        }
    }

    // responsável por verificar se o numero clicado ja foi jogado
    public bool SearchNumber(int a)
    {


        for (int i = 0; i < playedNumber.Count; i++)
        {

            if (playedNumber[i] == a)
            {
                return true;
            }
        }

        return false;


    }

    public void SetBoolEnd(bool isEnd) => isEndGame = isEnd; // Seta fim do jogo

    public void Resetd()
    {
        Start();
        SetBoolEnd(false);

    }





}
