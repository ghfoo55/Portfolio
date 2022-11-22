using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BlockWallView))]
public class BlockWallView_Editor : Editor
{
    private void OnSceneGUI()
    {
        BlockWallView bwv = (BlockWallView)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(bwv.transform.position, Vector3.up, Vector3.forward, 360, bwv.viewRaidus);

        Vector3 viewAngleA = bwv.DirFromAngle(-bwv.viewAngle / 2, false);
        Vector3 viewAngleB = bwv.DirFromAngle(bwv.viewAngle / 2, false);

        Handles.DrawLine(bwv.transform.position, bwv.transform.position + viewAngleA * bwv.viewRaidus);
        Handles.DrawLine(bwv.transform.position, bwv.transform.position + viewAngleB * bwv.viewRaidus);

        Handles.color = Color.red;
        foreach(Transform visibleTargets in bwv.VisibleTargets)
        {
            Handles.DrawLine(bwv.transform.position, visibleTargets.position);
        }       
    }    
}
