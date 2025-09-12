using TMPro;
using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UObject = UnityEngine.Object;
using UnityEngine.PlayerLoop;

namespace HideDialogText
{
    internal class HideDialogText : Mod
    {
        private GameObject DialogManagerGO;

        public HideDialogText() : base("HideDialogText") { }

        public override string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public override void Initialize()
        {
            Log("Initializing");

            On.HeroController.Awake += HeroAwake;
            On.HeroController.Update += HeroUpdate;

            Log("Initialized");
        }

        private void HeroAwake(On.HeroController.orig_Awake orig, HeroController self)
        {
            orig(self);
        }

        private void HeroUpdate(On.HeroController.orig_Update orig, HeroController self)
        {
            orig(self);
            if (Input.GetKeyDown(KeyCode.F3))
            {
                DialogManagerGO = GameObject.Find("DialogueManager");

                foreach (var r in DialogManagerGO.GetComponentsInChildren<Renderer>(true))
                    r.enabled = !r.enabled;

                Log($"Toggled! {DialogManagerGO.activeSelf}");
            }
        }
    }
}