using UnityEngine;

public class ButtonFirstPuzzle : ButtonBase
{
    [SerializeField] GameObject Door;
    bool openDoor;
    public override void pressButton()
    {
        if (!doorIsOpen)
        {
            openDoor = towerBase.CheckWinCondition();

            if (openDoor)
            {
                Door.GetComponent<OpenDoor>().UpTheDoor();
                treeGrowth.UpTree();
                doorIsOpen = true;
            }
        }

        lightButton.ChangeLigthColor(openDoor);
    }
}
