using UnityEngine;


namespace Owlligence
{
    public class ColumnTutorialLogic : ColumnLogicBase
    {
        int indexColum;



        void Awake()
		{
            indexColum = 0;
		}

        void Start()
        {
            columnsCount = 10;
        }



        public override void CheckColumnInCorrectPivot(Transform currentColum)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i] == currentColum)
                {
                    indexColum = i;
                    break;
                }
            }

            if (Vector3.Distance(currentColum.position, pivotsColumns[indexColum].position) < 4f)
            {
                currentColum.transform.position = pivotsColumns[indexColum].position;
                //currentColum.tag = null; //Tengo que modificar la layer, pero esto hace que no la pueda agarrar mas
            }
        }

        public override bool CheckWincondition()
        {
            int count = 0;


            for (int i = 0; i < columns.Length - 1; i++)
            {
                if (columns[i].position == pivotsColumns[i].position)
                {
                    count++;

                    if (count >= columns.Length - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        }
    }
}
