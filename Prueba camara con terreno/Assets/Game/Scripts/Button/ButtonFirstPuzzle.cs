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
                Door.GetComponent<OpenDoor>().UpTheDoor();
                treeGrowth.UpTree();
            }
        }

        lightButton.ChangeLigthColor(openDoor);
    }
}
