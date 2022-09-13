using UnityEngine;

public class CheckWinFirstPuzzle : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] BaseTower baseTower;
    [SerializeField] LigthButton lightButton;
    bool openDoor = false;


    public void pressButton()
    {
        openDoor = baseTower.checkWinCondition();

        if (Door)
        {
            if (openDoor)
            {
                Destroy(Door);
            }
        }

        lightButton.ChangeLigthColor(openDoor);
    }
}
