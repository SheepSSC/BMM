using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Solution : MonoBehaviour
{
    public Text textNumber;
    public Text textIndice;

    // ======================================================================
    // MONOBEHAVIOUR
    // ======================================================================

    private void Start()
    {
        GiveCode();
    }

    // ======================================================================
    // PUBLIC METHODS
    // ======================================================================

    public void GiveCode()
    {
        int random = Random.Range(0, 5);

        switch (random)
        {
            case 0:
                textNumber.text = "Indice 1 sur 5";
                textIndice.text = "\"N'importe quelle personne servant dans la caféteria avec un badge rouge, mais elle doit être de dos.\"";
                break;
            case 1:
                textNumber.text = "Indice 2 sur 5";
                textIndice.text = "\"Lorsque vous donnerez l'indice numéro 4, filmez la scène et tous ses participants.\"";
                break;
            case 2:
                textNumber.text = "Indice 3 sur 5";
                textIndice.text = "\"Postez l'indice numéro 2 sur le channel sonnette en taguant @everyone. Vous aurez alors vraiment gagné !\"";
                break;
            case 3:
                textNumber.text = "Indice 4 sur 5";
                textIndice.text = "\"Chuchotez l'indice numéro 5 à l'oreille de la personne indiquée dans l'indice numéro 1.\"";
                break;
            case 4:
                textNumber.text = "Indice 5 sur 5";
                textIndice.text = "\"Avez-vous du jambon ?\"";
                break;
            default:
                break;
        }
    }

    // ======================================================================
    // PRIVATE METHODS
    // ======================================================================
}
