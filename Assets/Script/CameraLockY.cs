using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class CameraLockY : CinemachineExtension
{
    [Tooltip("カメラのY座標を固定する値")]
    public float m_YPosition = 10;
    public float m_Rotation = 0;

    protected override void PostPipelineStageCallback( CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            var rot = state.RawOrientation;
            pos.y = m_YPosition;
            rot.y = m_Rotation;
            rot.z = m_Rotation;
            state.RawPosition = pos;
            state.RawOrientation = rot;
        }
    }
}
