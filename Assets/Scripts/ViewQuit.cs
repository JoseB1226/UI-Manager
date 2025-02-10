using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewQuit : view, IView<ViewQuit>
{
    public override void Initialize()
    {
        IView<ViewQuit>.Instance = this;
    }
    public void OnViewLoad()
    {
        ViewManager.Show<ViewQuit>();

    }
}