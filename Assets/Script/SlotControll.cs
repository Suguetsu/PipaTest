
using UnityEngine;
using UnityEngine.UI;


namespace Sugue
{
    [RequireComponent(typeof(InputField))]
    public class SlotControll : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gm;

        public static event System.Action<int> diag;
        public static event System.Action<int> vert;
        public static event System.Action<int> hor;




        [SerializeField] private string column;
        [SerializeField] private int ID_vert;
        [SerializeField] private int ID_pos;
        [SerializeField] private int ID_hor;
        [SerializeField] private int num;
        [SerializeField] private Text texto;
        [SerializeField] private GameObject activeImg;       // pega a imagem de click
        [SerializeField] private bool ismidle;               //  verifica se esse slote é o meio
        [SerializeField] public bool isSelect { private set; get; }

        [SerializeField] private Vector2 ID_pos_vetor;  //retorna porsição.


        int aleatorio;



        private void Start()
        {

            aleatorio = -1;
            activeImg.SetActive(false);
            isSelect = false;

            Startup.SetColor += ActiveColor;


        }
        private void OnDestroy()
        {
            Startup.SetColor -= ActiveColor;
        }

        #region Metodo de Retorno
        public string RetornaColumn() => column;     // retorna a letra do slote
        public int Num_Return() => num;                     // retorna o ID do slote
        public int ID_Linha_Return() => ID_pos;             // retorna a posição na linha
        public int ID_VertC_Return() => ID_vert;         // retorna o id da letra
        public int ID_Hor_Return() => ID_hor;         // retorna o id da letra

        public bool IsMiddle() => ismidle;           // retorna o meio da tabela

        #endregion


        #region Metodo de setagem
        public void SetID(int pos)
        {


            ID_pos = pos;


        }
        public void SetHor(int pos)
        {


            ID_hor = pos;


        }

        public void SetVector(int posx, int posy)
        {
            ID_pos_vetor.x = posx;
            ID_pos_vetor.y = posy;
        }

        public void SetColumn()
        {
            int mult;
            int soma = 0;

            for (int j = 0; j < 5; j++)
            {


                for (int i = 0; i < 5; i++)
                {
                    mult = 5 * i;




                    soma = mult + j;

                    Debug.Log(soma);


                    switch (j)
                    {
                        case 0:

                            if (soma == ID_pos)
                            {
                                column = "B";
                                ID_vert = 0;
                                ID_hor = ID_vert;


                                RamdomAgain(column);
                            }

                            break;
                        case 1:
                            if (soma == ID_pos)
                            {
                                column = "I";



                                ID_vert = 1;
                                ID_hor = ID_vert;
                                RamdomAgain(column);


                            }

                            break;
                        case 2:
                            if (soma == ID_pos)
                            {


                                ID_vert = 2;
                                ID_hor = ID_vert;


                                column = "N";

                                RamdomAgain(column);

                            }


                            break;
                        case 3:
                            if (soma == ID_pos)
                            {

                                ID_vert = 3;
                                ID_hor = ID_vert;

                                column = "G";


                                RamdomAgain(column);


                            }

                            break;
                        case 4:
                            if (soma == ID_pos)
                            {

                                ID_vert = 4;
                                ID_hor = ID_vert;

                                column = "O";


                                RamdomAgain(column);


                            }

                            break;
                    }


                    texto.text = num.ToString();
                }




            }






        }
        public void SetNumber(int a, int b)
        {



            if (ID_pos == 12)
            {
                ismidle = true;
                num = 0;
            }
            else
            {
                aleatorio = Random.Range(a, b);
                num = aleatorio;

            }



            texto.text = num.ToString();

        }

        #endregion


        public void RamdomAgain(string a)
        {

            switch (a)
            {
                case "B":
                    SetNumber(1, 16);

                    break;
                case "I":
                    SetNumber(16, 31);

                    break;
                case "N":
                    SetNumber(31, 46);

                    break;
                case "G":

                    SetNumber(46, 61);
                    break;
                case "O":

                    SetNumber(61, 76);

                    break;
            }




        }   // Defini o numero do slote pela letra

        public void FindNumber()
        {
            Vector2[] D1 = { new Vector2(0, 0), new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3) };
            Vector2[] D2 = { new Vector2(4, 0), new Vector2(3, 1), new Vector2(2, 2), new Vector2(1, 3) };

            if (ismidle) return;

            if (GameManager.instance.SearchNumber(num))
                activeImg.gameObject.SetActive(true);
            else return;

            isSelect = activeImg.gameObject.activeSelf;



            for (int i = 0; i < D1.Length; i++)
            {
                if (D1[i] == ID_pos_vetor)
                    diag?.Invoke(0);
                else if (D2[i] == ID_pos_vetor)
                    diag?.Invoke(1);

            }

            vert?.Invoke((int)ID_pos_vetor.x); // soma os valores de x = numeros verticais
            hor?.Invoke((int)ID_pos_vetor.y); // soma os valores de y = numeros horizontais



        }            // ativa o botão clicado

        public void ActiveColor(int pos, int id)
        {
            Vector2[] D1 = { new Vector2(0, 0), new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3) };
            Vector2[] D2 = { new Vector2(4, 0), new Vector2(3, 1), new Vector2(2, 2), new Vector2(1, 3) };


            Color A = Color.green;


            if (pos == ID_pos_vetor.y && id == 0)
            {

                GetComponent<Image>().color = A;

                Debug.Log("Vertical");

            }
            else if (pos == ID_pos_vetor.x && id == 1)
            {
                GetComponent<Image>().color = A;

                Debug.Log("Horizontal");
            }
            else if (id == 3)
            {

                for (int i = 0; i < D1.Length; i++)
                {
                    if (pos == 1)
                    {
                        if (ID_pos_vetor == D2[i])
                        {
                            GetComponent<Image>().color = A;
                        }
                        else if (pos == 0)
                        {

                            if (ID_pos_vetor == D1[i])
                            {
                                GetComponent<Image>().color = A;
                            }
                        }
                    }














                }


            }

            //if ((a == "Vertical") && pos == ID_pos_vetor.y)
            //{

            //    GetComponent<Image>().color =A;

            //    Debug.Log("Vertical");

            //}
            //else if ((a == "Horizontal") && pos == ID_pos_vetor.x)
            //{
            //    GetComponent<Image>().color = A;

            //    Debug.Log("Horizontal");
            //}
            //else if (a == "Diagonal")
            //{

            //    for (int i = 0; i < D1.Length; i++)
            //    {
            //        if (pos == 1)
            //        {
            //            if (ID_pos_vetor == D2[i])
            //            {
            //                GetComponent<Image>().color = A;
            //            }
            //        }
            //        else if (pos == 0)
            //        {

            //            if (ID_pos_vetor == D1[i])
            //            {
            //                GetComponent<Image>().color = A;
            //            }
            //        }
            //    }






        }
    }
}


