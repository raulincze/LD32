using UnityEngine;
using System.Collections;

public class KillPlayerAction : Action {

	public override void Execute()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
