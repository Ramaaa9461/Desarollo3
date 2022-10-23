using System.Collections;
using UnityEngine;

public class ButtonBase : MonoBehaviour
{
    [SerializeField] protected LigthButton lightButton;
    [SerializeField] protected TowersLogicBase towerBase;
    [SerializeField] protected ColumnLogicBase columBase;
    [SerializeField] protected TreeGrowth treeGrowth;
    [SerializeField] GameObject Door;
    protected bool doorIsOpen = false;
    bool openDoor;
    public void pressButton()
    {
        if (!doorIsOpen)
        {
            if (columBase == null)
            {
                openDoor = towerBase.CheckWinCondition();
            }
            else
            {
                openDoor = towerBase.CheckWinCondition() && columBase.CheckWincondition();

            }

            if (openDoor)
            {
                treeGrowth.UpTree();

                StartCoroutine(WaitGrowthTree());

                doorIsOpen = true;
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
