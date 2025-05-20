[h1]Quasimorph Mouse Move Transfer[/h1]



Holding control while moving the mouse over items will cause those items to be moved.
This allows the user to quickly move items without having to click each individual item.

[h1]Configuration[/h1]

The configuration file will be created on the first game run and can be found at [i]%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\MouseMoveTransfer\config.json[/i].

The mouse and keys to activate the mouse move are set in the "Keys" area.
A "chord" is one or more keys and/or mouse buttons that have to be held down at the same to to invoke the move.
There can be more than one "chord" configured.

For example, adding the middle mouse button, would be adding a new Chord with Mouse2 as the value.
Mouse0 is left button, Mouse1 right, etc.

Example of adding middle mouse button:
[code]
//...
    "Chords": [
      [
        "Mouse2"
      ],
//Existing entry...
      [
        "LeftControl",
        "Mouse0"
      ],
//...
[/code]

[h2]Key List[/h2]

The list of valid keyboard keys can be found  at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

[h1]Buy Me a Coffee[/h1]

If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.
Thanks!

[h1]Source Code[/h1]

Source code is available on GitHub at https://github.com/NBKRedSpy/QM_MouseMoveTransfer

[h1]Credits[/h1]

Thanks to Discord users Kashmyrr and Raigir for the mod idea.

[h1]Change Log[/h1]

[h2]1.1.0[/h2]

Added config for modifier key.
