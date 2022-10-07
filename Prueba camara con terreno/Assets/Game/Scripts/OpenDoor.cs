using System.Collections;

using UnityEngine;


namespace Owlligence
{
    public class OpenDoor : MonoBehaviour
    {
        [SerializeField] float duration;


        Coroutine doorOpen;
        new Collider collider;
        float DistanceY;



        void Awake()
        {
            collider = GetComponent<Collider>();

            DistanceY = collider.bounds.size.y - 0.2f;
        }



        public void UpTheDoor()
        {
            if (doorOpen == null)
            {
                doorOpen = StartCoroutine(DoorOpen(DistanceY));
            }
        }

        IEnumerator DoorOpened(float distanceUp)
        {
            float progress = 0;

            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + distanceUp, transform.position.z);

            while (progress <= 1)
            {
                transform.position = Vector3.Lerp(transform.position, newPosition, progress);
                progress += Time.deltaTime; //De aca se limita la velocidad del Lerp
                yield return null;
            }
            transform.position = newPosition;
        }
        IEnumerator DoorOpen(float distanceUp)
        {
            float timer = 0;
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + distanceUp, transform.position.z);


            while (timer <= duration)
            {
                float interpolationValue = timer / duration;

                transform.position = Vector3.Lerp(transform.position, newPosition, interpolationValue);

                timer += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            transform.position = newPosition;
        
            //doorOpen = null;
        }
    }
}
