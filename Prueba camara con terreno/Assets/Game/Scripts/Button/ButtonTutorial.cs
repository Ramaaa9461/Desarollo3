using UnityEngine;

public class ButtonTutorial : ButtonBase
{
    [SerializeField] GameObject Door;

    bool openDoor;
    public override void pressButton()
    {
        if (!doorIsOpen)
        {
            openDoor = towerBase.CheckWinCondition() && columBase.CheckWincondition();

            if (openDoor)
            {
                Door.GetComponent<OpenDoor>().UpTheDoor();
                treeGrowth.UpTree();
                doorIsOpen =true;
            }
        }

        lightButton.ChangeLigthColor(openDoor);
    }
}
