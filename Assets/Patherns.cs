
using UnityEngine;

namespace Sugue
{
    public class Patherns : MonoBehaviour
    {
        private Startup _start;


        [SerializeField]
        private int[] diag;
        [SerializeField]
        private int[] vert;
        [SerializeField]
        private int[] hor;



        private void Start()
        {


            diag = new int[2];
            vert = new int[5];
            hor = new int[5];

            SlotControll.vert += Vertical;
            SlotControll.hor += Horizontal;
            SlotControll.diag += Diagonal;

            _start = GetComponent<Startup>();

        }

        private void OnDestroy()
        {
            SlotControll.vert -= Vertical;
            SlotControll.hor -= Horizontal;
            SlotControll.diag -= Diagonal;
        }


       

        public void Vertical(int a)
        {
            vert[a] += 1;

            for (int i = 0; i < vert.Length; i++)
            {
                if (vert[i] > 4 && i != 2)
                {

                    Debug.Log(vert[i] + "Ganhou!" + i + " vert ");
                    GameManager.instance.SetBoolEnd(true);




                    _start.FimDeJogo(i, 1);

                }

                if (vert[2] > 3)
                {
                    Debug.Log(vert[2] + "Ganhou!" + i + " vert ");


                    _start.FimDeJogo(i,1);

                    GameManager.instance.SetBoolEnd(true);
                }


            }
        }

        public void Horizontal(int a)
        {
            hor[a] += 1;

            for (int i = 0; i < hor.Length; i++)
            {
                if (hor[i] > 4 && i != 2)
                {

                    _start.FimDeJogo(i, 0);
                    Debug.Log(hor[i] + "Ganhou!" + i + " hor ");



                    GameManager.instance.SetBoolEnd(true);
                }

                if (hor[2] > 3)
                {
                    Debug.Log(hor[2] + "Ganhou!" + i + " hor ");

                    _start.FimDeJogo(i, 0);
                    GameManager.instance.SetBoolEnd(true);


                }
            }

        }

        public void Diagonal(int a)
        {


            diag[a] += 1;

            for (int i = 0; i < diag.Length; i++)
            {
                if (diag[i] > 3)
                {


                    Debug.Log(diag[i] + "diag!" + i + " diag ");
                    GameManager.instance.SetBoolEnd(true);
                    _start.FimDeJogo(i,3);
                }

            }
        }

        public void Reestart() => this.Start();

    }






}
