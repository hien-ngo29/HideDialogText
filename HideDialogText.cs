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

        private bool toggled = false;

        public HideDialogText() : base("HideDialogText") { }

        public override string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public override void Initialize()
        {
            Log("Initializing");

            On.HeroController.Update += HeroUpdate;

            Log("Initialized");
        }

        private void HeroUpdate(On.HeroController.orig_Update orig, HeroController self)
        {
            orig(self);
            if (Input.GetKeyDown(KeyCode.F3))
            {
                toggled = !toggled;
                DialogManagerGO = GameObject.Find("DialogueManager");

                /* A "hacky" way to hide the text without deactivating the game object as 
                you would stuck talking to the NPC */
                if (toggled)
                    DialogManagerGO.transform.localScale = Vector3.zero;
                else
                    DialogManagerGO.transform.localScale = Vector3.one;

                Log($"Toggled! {DialogManagerGO.activeSelf}");
            }
        }
    }
}