using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMainMenuUI : view, IView<ViewMainMenuUI>
{
    public override void Initialize()
    {
        IView<ViewMainMenuUI>.Instance = this;
    }
    public void OnViewLoad()
    {
        ViewManager.Show<ViewMainMenuUI>();
        
    }
}

