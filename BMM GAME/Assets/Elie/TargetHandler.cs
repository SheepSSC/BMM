using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetHandler : MonoBehaviour
{
    public List<Target> targets;
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
                break;
            case 1:
                currentList = anwser1;
                break;
            case 2:
                currentList = anwser2;
                break;
            case 3:
                currentList = anwser3;
                break;
            case 4:
                currentList = anwser4;
                break;
            default:
                break;
        }

        // DONNER LA BONNE AFFICHE DEHORS
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
        if(currentIndex == currentList[currentIndex]) // Bon numéro
        {
            currentIndex++;

            if(currentIndex == currentList.Count-1)
            {
                Victory();
            }
        }
        else // Mauvais numéro
        {
            currentIndex = 0;
            Defeat();
        }
    }

    // ======================================================================
    // PRIVATE METHODS
    // ======================================================================

    private void Victory()
    {
        print("yeah");
    }

    private void Defeat()
    {
        foreach (Target t in targets)
        {
            t.ResetTarget();
        }
    }
}
