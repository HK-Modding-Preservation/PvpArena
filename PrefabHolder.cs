﻿using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;
using SFCore.Utils;

namespace PvpArena
{
    class PrefabHolder
    {
        public static GameObject wpFlyPrefab { get; private set; }
        public static GameObject wpSawWithSoundPrefab { get; private set; }
        public static GameObject wpSawNoSoundPrefab { get; private set; }
        public static GameObject wpInfSoulTotemPrefab { get; private set; }
        public static GameObject wpSpikesPrefab { get; private set; }
        public static TinkEffect wpTinkEffectPrefab { get; private set; }
        public static GameObject popAreaTitleCtrlPrefab { get; private set; }
        public static GameObject popTabletInspectPrefab { get; private set; }
        public static GameObject popSceneManagerPrefab { get; private set; }
        public static GameObject popPmU2dPrefab { get; private set; }
        public static GameObject popMusicRegionPrefab { get; private set; }
        public static MusicCue popEnterMusicCuePrefab { get; private set; }
        public static GameObject popQuakeFloorPrefab { get; private set; }
        public static GameObject whiteBenchPrefab { get; private set; }
        public static GameObject breakableWallPrefab { get; private set; }

        public static void preloaded(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            wpFlyPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["White Palace Fly"]);
            SetInactive(wpFlyPrefab);
            wpSawWithSoundPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["saw_collection/wp_saw"]);
            SetInactive(wpSawWithSoundPrefab);
            wpSawNoSoundPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["saw_collection/wp_saw (2)"]);
            SetInactive(wpSawNoSoundPrefab);
            wpInfSoulTotemPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["Soul Totem white_Infinte"]);
            SetInactive(wpInfSoulTotemPrefab);
            wpSpikesPrefab = UObject.Instantiate(preloadedObjects["White_Palace_17"]["White_ Spikes"]);
            SetInactive(wpSpikesPrefab);
            wpTinkEffectPrefab = new TinkEffect();
            {
                var tmp = UObject.Instantiate(preloadedObjects["White_Palace_17"]["Cave Spikes Invis"]);
                var tmpTE = tmp.GetComponent<TinkEffect>();
                wpTinkEffectPrefab.blockEffect = tmpTE.blockEffect;
                wpTinkEffectPrefab.useNailPosition = tmpTE.useNailPosition;
                wpTinkEffectPrefab.sendFSMEvent = tmpTE.sendFSMEvent;
                wpTinkEffectPrefab.FSMEvent = tmpTE.FSMEvent;
                wpTinkEffectPrefab.fsm = tmpTE.fsm;
                wpTinkEffectPrefab.sendDirectionalFSMEvents = tmpTE.sendDirectionalFSMEvents;
            }
            popAreaTitleCtrlPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["Area Title Controller"]);
            SetInactive(popAreaTitleCtrlPrefab);
            popTabletInspectPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["Inspect Region"]);
            SetInactive(popTabletInspectPrefab);
            popSceneManagerPrefab = UObject.Instantiate(preloadedObjects["Town"]["_SceneManager"]);
            {
                var sm = popSceneManagerPrefab.GetComponent<SceneManager>();
                sm.SetAttr("musicTransitionTime", 3.0f);
            }
            SetInactive(popSceneManagerPrefab);
            popPmU2dPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["_Managers/PlayMaker Unity 2D"]);
            SetInactive(popPmU2dPrefab);
            popMusicRegionPrefab = UObject.Instantiate(preloadedObjects["White_Palace_18"]["Music Region (1)"]);
            SetInactive(popMusicRegionPrefab);
            popEnterMusicCuePrefab = UObject.Instantiate(popMusicRegionPrefab.GetComponent<MusicRegion>().enterMusicCue);
            SetInactive(popEnterMusicCuePrefab);
            whiteBenchPrefab = UObject.Instantiate(preloadedObjects["White_Palace_03_hub"]["WhiteBench"]);
            SetInactive(whiteBenchPrefab);
            breakableWallPrefab = UObject.Instantiate(preloadedObjects["Crossroads_07"]["Breakable Wall_Silhouette"]);
            {
                UObject.Destroy(breakableWallPrefab.GetComponent<PersistentBoolItem>());
            }
            SetInactive(breakableWallPrefab);
            popQuakeFloorPrefab = UObject.Instantiate(preloadedObjects["White_Palace_09"]["Quake Floor"]);
            {
                UObject.Destroy(popQuakeFloorPrefab.GetComponent<PersistentBoolItem>());
                var t = popQuakeFloorPrefab.transform.Find("Active");
                for (int c = t.childCount - 1; c >= 0; c--)
                {
                    UObject.Destroy(t.GetChild(c).gameObject);
                }
                t = popQuakeFloorPrefab.transform.Find("Inactive");
                for (int c = t.childCount - 1; c >= 0; c--)
                {
                    UObject.Destroy(t.GetChild(c).gameObject);
                }
            }
            SetInactive(popQuakeFloorPrefab);
        }
        private static void SetInactive(GameObject go)
        {
            if (go != null)
            {
                UObject.DontDestroyOnLoad(go);
                go.SetActive(false);
            }
        }
        private static void SetInactive(UObject go)
        {
            if (go != null)
            {
                UObject.DontDestroyOnLoad(go);
            }
        }
    }
}
