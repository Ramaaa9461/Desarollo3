using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] TowersLogicBase logicParent;
    [SerializeField] LigthButton lightButton;
    bool openDoor = false;


    public void pressButton()
    {
        openDoor = logicParent.CheckWinCondition();

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
