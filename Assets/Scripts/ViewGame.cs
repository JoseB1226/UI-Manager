using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewGame : view, IView<ViewGame>
{
    public override void Initialize()
    {
        IView<ViewGame>.Instance = this;
    }
    public void OnViewLoad()
    {
        ViewManager.Show<ViewGame>();

    }
}