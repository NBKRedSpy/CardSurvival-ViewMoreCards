using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace ViewMoreCards
{

    //Init didnt' work
    [HarmonyPatch(typeof(GraphicsManager), nameof(GraphicsManager.Init))]
    public static class GraphicsManager_CardLine_Patch
    {
        public static void Postfix(GraphicsManager __instance)
        {
            try
            {
                RectTransform rect;
                GameObject gameObject;

                gameObject = GameObject.Find("MainCanvas/SlotsCanvas/Base/BaseViewport");
                gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);
                rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(700, 0);

                gameObject = GameObject.Find("MainCanvas/SlotsCanvas/Environment/Locations");
                gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);
                rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(625, 0);


                gameObject = GameObject.Find("MainCanvas/PopupWindowsCanvas/CharacterWindow/DarkBG/ShadowAndPopupWithTitle/Content/Cards/CharacterSlotsViewport");
                gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);

                rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(500, 0);
            }
            catch (Exception ex)
            {
                Plugin.LogInfo($"error changing canvas: {ex}");
            }

        }
    }
}
