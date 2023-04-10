using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NormalDoor : MonoBehaviour, IRequire
{
    public UnityEvent Unlocked;

    public bool Interact(GameObject requiredItem)
    {
        Key key = requiredItem.GetComponent<Key>(); ;

        print(key.HasRightColor);

        if (key != null)
        {
            if (key.HasRightColor)
            {
                Unlocked.Invoke();
                return false;
            }
        }

        return false;
    }

}
