using System.Collections;
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
                treeGrowth.UpTree();

                StartCoroutine(WaitGrowthTree());

                doorIsOpen =true;
            }
        }

        lightButton.ChangeLigthColor(openDoor);
    }

    IEnumerator WaitGrowthTree()
    {
        yield return new WaitForSeconds(3);

        Door.GetComponent<OpenDoor>().UpTheDoor();
    }
}
