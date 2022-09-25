using UnityEngine;

public class ButtonFirstPuzzle : ButtonBase
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
