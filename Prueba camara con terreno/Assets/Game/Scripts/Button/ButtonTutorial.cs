using UnityEngine;

public class Button : ButtonBase
{
    [SerializeField] GameObject Door;
  
    public override void pressButton()
    {
        openDoor = towerBase.CheckWinCondition();
        bool columdoor = columBase.CheckWincondition();


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
