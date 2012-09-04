﻿/*
 * Copyright (C) 2012 Interactive Lab
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
 * 
 */

using System.Collections.Generic;
using UnityEngine;

namespace TouchScript {
    /// <summary>
    /// Component to configure and update TouchManager's options.
    /// </summary>
    internal class TouchOptions : MonoBehaviour {
        #region Unity fields

        /// <summary>
        /// Active cameras to look for touch targets in specific order.
        /// </summary>
        public Camera[] HitCameras;

        /// <summary>
        /// Current touch device DPI.
        /// </summary>
        public float DPI = 72;

        /// <summary>
        /// Current DPI to test in editor.
        /// </summary>
        public float EditorDPI = 72;

        /// <summary>
        /// Radius of single touch point on device in cm.
        /// </summary>
        public float TouchRadius = .75f;

        #endregion

        #region Private variables

        private TouchManager manager;

        #endregion

        #region Unity

        private void Awake() {
            if (TouchManager.Instance == null) {
                gameObject.AddComponent<TouchManager>();
            }
            manager = TouchManager.Instance;
            updateManager();
        }

        private void Update() {
            if (HitCameras.Length == 0 && Camera.mainCamera != null) HitCameras = new Camera[] {Camera.mainCamera};
            updateManager();
        }

        #endregion

        #region Private functions

        private void updateManager() {
            if (Application.isEditor) {
                manager.DPI = EditorDPI;
            } else {
                manager.DPI = DPI;
            }
            manager.TouchRadius = TouchRadius;
            manager.HitCameras = new List<Camera>(HitCameras);
        }

        #endregion
    }
}