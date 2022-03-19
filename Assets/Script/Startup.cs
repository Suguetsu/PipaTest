using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using Sugue;


public enum coluna { B, I, N, G, O };

// Responsável por gerenciar a tabela.
[RequireComponent(typeof(Patherns))]

public class Startup : MonoBehaviour
{
    public static event System.Action<int, int> SetColor;

    [Header("Objects")] [SerializeField] SlotControll prefab;
    [SerializeField] protected List<SlotControll> bgCard;
    [SerializeField] private List<int> interager;
    [SerializeField] public GameObject mark;

    [Tooltip("Table config")]
    private int length = 25;                               // defini o tamanho das listas

    [SerializeField]
    [Tooltip("Seleciona coluna")] protected coluna Select;   // seletor teste pra verificar se as colunas funcionam


    [SerializeField]
    [Tooltip("Ativa e desativa o selecionador de coluna")]
    protected bool isSelectON;

    // uso local.
    private bool isMidlleSeted;


    private void Start()
    {
        bgCard = new List<SlotControll>();
        interager = new List<int>();



    }
    private void Update()
    {
        if (!GameManager.instance.isEndGame)
            MakeCartela();

    }


    private void MakeCartela()
    {
        int posx = 0;
        int posy = 0;

        for (int i = 0; i < length; i++)
        {




            if (bgCard.Count < length)
            {


                bgCard.Add(((Instantiate(prefab, transform)) as SlotControll));

                bgCard[i].GetComponent<SlotControll>().SetID(i);
                bgCard[i].GetComponent<SlotControll>().SetColumn();
                bgCard[i].GetComponent<SlotControll>().SetVector(posx, posy);


                if (posx < 4)
                {
                    posx++;

                }
                else
                {
                    posy++;
                    posx = 0;
                }



                // armzena os numeros sorteados
                interager.Add(bgCard[i].Num_Return());



            }  // seta id e letra dos slotes




        }        // instancia e seta  parametros


        interager.Sort();                           //ordena em ordem crescente





        for (int i = 0; i < bgCard.Count; i++)
        {
            // reponsável por procurar numero repetidos

            if (i != 0)
            {

                if ((interager[i] == interager[i - 1]))
                {
                    interager[i] = -1;

                }


            }

            // posiciona os filhos do slote.

            if (!isMidlleSeted && bgCard[i].IsMiddle())
            {
                isMidlleSeted = true;
                GameObject temp = Instantiate(mark);
                temp.transform.SetParent(bgCard[i].transform);
                temp.GetComponent<RectTransform>().transform.localScale = new Vector2(1, 1);
                temp.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;



            }

            //if (!GameManager.instance.isEndGame)

            //    // responsável por ativar a cor das colunas caso setada.

            //    if (!isSelectON)
            //    {
            //        bgCard[i].GetComponent<Image>().color = Color.white;
            //        continue;
            //    }
            //    else
            //    {

            //        if (bgCard[i].RetornaColumn().ToString() == Select.ToString())
            //        {
            //            Color A = new Color32(130, 130, 130, 255);

            //            bgCard[i].GetComponent<Image>().color = A;

            //        }
            //    }






        } // Gerencia os cards.


        // responsável por procurar numeros repetidos na tabela
        for (int j = 0; j < 5; j++)
        {



            foreach (SlotControll s in bgCard.ToArray())
            {
                if (s.ID_VertC_Return() == j)
                {
                    int coutn = 0;

                    for (int i = 0; i < bgCard.Count; i++)
                    {

                        if (s.Num_Return() == bgCard[i].Num_Return())
                        {
                            coutn++;

                            if (coutn > 1)
                            {
                                s.RamdomAgain(s.RetornaColumn());


                                interager.Add(s.Num_Return());


                            }

                            if (interager[0] < 0)
                            {
                                interager.Remove(interager[0]);
                            }



                        }





                    }



                }

            }
        }









    }  // controla a  Cartela

    public void FimDeJogo(int pos, int id)
    {


        SetColor?.Invoke(pos, id);





    }

    public void ResetALL()
    {
        this.Start();
        GetComponent<Patherns>().Reestart();

    }

}
