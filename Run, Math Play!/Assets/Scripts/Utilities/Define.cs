using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : Define
    @date   : 2022-08-28
    @author : 
    @brief  : 
    @warning: 
 */

public class Define
{
    public enum WJAPI
    {
        DiagnosisStart,
        DiagnosisProgress,
        DiagnosisEnd,
        Learning
    }

    // 
    public enum Scene
    {
        Unknown,
        
        Login,
        Home,
        Collection,
        Shop,
        Review,
        Ranking,
        Reward,

        CrossTheBridge,
        CatchTheSpy,
        MacMan,
    }

    public enum UI
    {
        Click,
        BeginDrag,
        Drag,
        EndDrag,
    }

    public enum Sound
    {
        BGM,
        Effect,
        Count,
    }

    public enum Mouse
    {
        Click,
        Press,
    }

    public enum Camera
    {
        CrossTheBridgeView,
        QuarterView,
        SideView,
        BackView,
        TopView,
        MacManView,
    }
}
