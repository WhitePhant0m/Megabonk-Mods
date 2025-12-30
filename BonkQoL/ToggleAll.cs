using System;
using UnityEngine.SceneManagement;

namespace BonkQoL;

public class ToggleAll {
    private bool _init;

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (_init) return;
        if (scene.name != "MainMenu") return;

        _init = true;
        var dataManager = DataManager.Instance;

        foreach (var weapon in dataManager.unsortedWeapons) weapon.canAlwaysToggle = true;
        foreach (var tome in dataManager.unsortedTomes) tome.canAlwaysToggle       = true;
        foreach (var item in dataManager.unsortedItems) item.canAlwaysToggle       = true;
    }
}