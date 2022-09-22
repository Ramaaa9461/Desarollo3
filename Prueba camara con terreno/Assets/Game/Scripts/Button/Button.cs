using UnityEngine;

public class ButtonTutorial : ButtonBase
{
    [SerializeField] GameObject Door;
  
    public override void pressButton()
    {
        openDoor = towerBase.CheckWinCondition();

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
