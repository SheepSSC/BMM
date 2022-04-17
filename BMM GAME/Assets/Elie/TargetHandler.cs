using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TargetHandler : MonoBehaviour
{
    public List<Target> targets;
    public List<Transform> positions;
    public List<MeshRenderer> papers;
    public Material matSelected;
    public Material matUnselected;
    public Animator door;
    List<int> anwser0 = new List<int> { 1, 5, 3, 2};
    List<int> anwser1 = new List<int> { 4, 5, 2, 3};
    List<int> anwser2 = new List<int> { 1, 3, 4, 5};
    List<int> anwser3 = new List<int> { 4, 1, 5, 2};
    List<int> anwser4 = new List<int> { 2, 1, 5, 4};
    List<int> currentList;
    int currentIndex = 0;

    // ======================================================================
    // MONOBEHAVIOUR
    // ======================================================================

    private void Start()
    {
        int temp = Random.Range(0, 5);
        switch (temp)
        {
            case 0:
                currentList = anwser0;
                papers[0].material = matSelected;
                papers[1].material = matUnselected;
                papers[2].material = matUnselected;
                papers[3].material = matUnselected;
                papers[4].material = matUnselected;
                break;
            case 1:
                currentList = anwser1;
                papers[0].material = matUnselected;
                papers[1].material = matSelected;
                papers[2].material = matUnselected;
                papers[3].material = matUnselected;
                papers[4].material = matUnselected;
                break;
            case 2:
                papers[0].material = matUnselected;
                papers[1].material = matUnselected;
                papers[2].material = matSelected;
                papers[3].material = matUnselected;
                papers[4].material = matUnselected;
                currentList = anwser2;
                break;
            case 3:
                papers[0].material = matUnselected;
                papers[1].material = matUnselected;
                papers[2].material = matUnselected;
                papers[3].material = matSelected;
                papers[4].material = matUnselected;
                currentList = anwser3;
                break;
            case 4:
                papers[0].material = matUnselected;
                papers[1].material = matUnselected;
                papers[2].material = matUnselected;
                papers[3].material = matUnselected;
                papers[4].material = matSelected;
                currentList = anwser4;
                break;
            default:
                break;

        }

        foreach (var a in currentList)
        {
            print(a);
        }

        int i = 0;

        foreach (Target t in targets)
        {
            if(t.number == currentList[3])
            {
                t.transform.position = positions[0].position;
                t.transform.rotation = positions[0].rotation;
            }
            else
            {
                i++;
                t.transform.position = positions[i].position;
                t.transform.rotation = positions[i].rotation;
            }
        }
    }

    // ======================================================================
    // PUBLIC METHODS
    // ======================================================================

    public void AddToHandler(Target target)
    {
        targets.Add(target);
    }

    public void CheckTargetOrder(int number)
    {
        if(number == currentList[currentIndex]) // Bon numéro
        {
            currentIndex++;

            if(currentIndex == 4)
            {
                Victory();
            }
        }
        else // Mauvais numéro
        {
            currentIndex = 0;
            Defeat();
        }
            print(currentIndex);
    }

    // ======================================================================
    // PRIVATE METHODS
    // ======================================================================

    private void Victory()
    {
        door.SetTrigger("open");
    }

    private void Defeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
