﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LylekGames {
[CustomEditor(typeof(CombineMeshes))]
	public class CombineMeshesEditor : Editor {
		CombineMeshes myCombine;

        public void OnEnable()
        {
            myCombine = (CombineMeshes)target;
            myCombine.Start();
        }
        public override void OnInspectorGUI() {
			myCombine = (CombineMeshes)target;
			DrawDefaultInspector();
            if (GUILayout.Button("Combine Meshes - Preserve Colliders"))
            {
                myCombine.EnableMeshPreserveColliders();
            }
            if (GUILayout.Button("Combine Meshes - New Collider")) {
				myCombine.EnableMeshNewCollider();
			}
			if(GUILayout.Button("Disable Meshes")) {
				myCombine.DisableMesh();
                EditorGUIUtility.ExitGUI();

            }
        }
	}
}
