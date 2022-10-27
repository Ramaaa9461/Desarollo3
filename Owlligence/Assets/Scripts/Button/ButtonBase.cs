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
            else if (towerBase == null)
            {
                openDoor = columBase.CheckWincondition();
            }
            else
            {
                openDoor = towerBase.CheckWinCondition() && columBase.CheckWincondition();

            }

            if (openDoor)
            {
                if (treeGrowth != null)
                {
                    treeGrowth.UpTree();
                }

                StartCoroutine(WaitGrowthTree());

                doorIsOpen = true;  
            }

            if (lightButton != null)
            {
                lightButton.ChangeLigthColor(openDoor);
            }
        }

    }


    IEnumerator WaitGrowthTree()
    {
        yield return new WaitForSeconds(1);

        Door.GetComponent<OpenDoor>().UpTheDoor();
    }

}
