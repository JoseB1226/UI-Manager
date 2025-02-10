using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCredits : view, IView<ViewCredits>
{
    public override void Initialize()
    {
        IView<ViewCredits>.Instance = this;
    }
    public void OnViewLoad()
    {
        ViewManager.Show<ViewCredits>();

    }
}