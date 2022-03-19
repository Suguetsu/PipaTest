
using UnityEngine;

public class MiniBall : MonoBehaviour
{
   

    [SerializeField]
    private TextMesh num;
    [SerializeField]
    private TextMesh letter;
    [SerializeField]
    MeshRenderer _rm;

    public void SetMiniBall(int numero)
    {

        SetBall(numero);
    }


    private void SetBall(int number)
    {

        num.text = number.ToString();

        if (number > 60)
        {
            _rm.material.color = new Color32(165, 44, 121, 255);

            letter.text = "O";

        }
        else if (number > 45)
        {
            _rm.material.color = new Color32(41, 65, 148, 255);


            letter.text = "G";


        }
        else if (number > 30)
        {
            _rm.material.color = new Color32(55, 147, 66, 255);

            letter.text = "N";


        }
        else if (number > 15)
        {
            _rm.material.color = new Color32(247, 112, 22, 255);

            letter.text = "I";

        }
        else
        {

            _rm.material.color = new Color32(209, 37, 13, 255);
            letter.text = "B";


        }




    }

}
