using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This will be picked up automatically by the wrist watch when it get spawn in the scene by the Interaction toolkit
/// and setup the buttons and the linked events on the canvas
/// </summary>
public class WitchHouseUIHook : WatchScript.IUIHook
{
    public GameObject LeftUILineRenderer;
    public GameObject RightUILineRenderer;
    
    public override void GetHook(WatchScript watch)
    {
        watch.AddButton("Reset level", () => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        watch.AddButton("Unlock Teleporters", () => {MasterController.Instance.TeleporterParent.SetActive(true);});
       // watch.AddToggle("Closed Caption", (state) => { CCManager.Instance.gameObject.SetActive(state); });
        watch.AddButton("Relax room", () => { GameManager.instance.TeleportRelaxRoom(); });
        watch.AddButton("Office room",() => { GameManager.instance.TeleportOfficeRoom(); });


        //    LeftUILineRenderer.SetActive(false);
        //  RightUILineRenderer.SetActive(false);

        LeftUILineRenderer.SetActive(true);
        watch.UILineRenderer = LeftUILineRenderer;
        LeftUILineRenderer.SetActive(true);
    }
}
