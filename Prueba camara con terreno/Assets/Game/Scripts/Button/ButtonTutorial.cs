using UnityEngine;

public class ButtonTutorial : ButtonBase
{
    [SerializeField] GameObject Door;
  
    public override void pressButton()
    {
        openDoor = towerBase.CheckWinCondition() && columBase.CheckWincondition();

        if (Door)
        {
            if (openDoor)
            {
                Door.GetComponent<OpenDoor>().UpTheDoor();
                treeGrowth.UpTree();
            }
        }

        lightButton.ChangeLigthColor(openDoor);
    }
}
