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

                //The Location card row (top)
                gameObject = GameObject.Find("MainCanvas/ShakeParent/SlotsCanvas/Environment/Locations");
                gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);
                rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(625, 0);

                //The base's inventory (Middle)
                gameObject = GameObject.Find("MainCanvas/ShakeParent/SlotsCanvas/Base/BaseViewport");
                gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);
                rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(700, 0);

                //Character equipment
                gameObject = GameObject.Find("MainCanvas/ShakeParent/PopupWindowsCanvas/CharacterWindow/DarkBG/ShadowAndPopupWithTitle/Content" +
                    "/Cards/CharacterSlotsViewport");
                gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);
                rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(500, 0);

                //---Blueprints cards
                gameObject = GameObject.Find("MainCanvas/ShakeParent/PopupWindowsCanvas/BlueprintModelsWindow/ShadowAndPopupWithTitle/Content" +
                    "/Blueprints/BlueprintsViewport");

                gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);
                rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(960, 0);


                ResizeContainerScreen();

            }
            catch (Exception ex)
            {
                Plugin.LogInfo($"error changing canvas: {ex}");
            }

        }

        private static void ResizeContainerScreen()
        {
            RectTransform rect;
            GameObject gameObject;

            //--Inventory for a container.
            //Note - Some layout is automatically repositioning the contents.  This works, but I'm sure there is an easier way
            //to adjust the area as a whole.

            //The cards in the inventory (the right of the container card)
            gameObject = GameObject.Find("MainCanvas/ShakeParent/PopupWindowsCanvas/InventoryInspectionWindow/ShadowAndPopupWithTitle/Content/" +
                "InspectionGroup/InventoryGroup/Inventory");
            gameObject.transform.localScale = new Vector3(.6f, .6f, 1f);

            //The box around the cards
            gameObject = GameObject.Find("MainCanvas/ShakeParent/PopupWindowsCanvas/InventoryInspectionWindow/ShadowAndPopupWithTitle/Content/" +
                "InspectionGroup/InventoryGroup/Inventory/Frame");
            rect = gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(800, 0);

            //The Cards area
            gameObject = GameObject.Find("MainCanvas/ShakeParent/PopupWindowsCanvas/InventoryInspectionWindow/ShadowAndPopupWithTitle/Content/" +
                "InspectionGroup/InventoryGroup/Inventory/InventoryViewport");
            rect = gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(790, 0);

            gameObject = GameObject.Find("MainCanvas/ShakeParent/PopupWindowsCanvas/InventoryInspectionWindow/ShadowAndPopupWithTitle/Content/InspectionGroup/InventoryGroup/Inventory/ScrollbarHorizontal");
            gameObject.transform.localPosition = new Vector3(-992, 0, 0);
            rect = gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(790, 20);
        }
    }
}
