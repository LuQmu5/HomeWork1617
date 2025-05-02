using System.Collections;
using UnityEngine;

public class StandStillBehaviour : IBehaviour
{
    public void Enter()
    {
        Debug.Log("Встал и стою как истукан, может быть я он и есть");
    }

    public void Exit()
    {
        Debug.Log("ХВАТИТ БЫТЬ ИСТУКАНОМ!");
    }

    public void Update()
    {
        Debug.Log("Я все еще стою");
    }
}
