[h1]Quasimorph Mouse Move Transfer[/h1]



Holding control while moving the mouse over items will cause those items to be moved.
This allows the user to quickly move items without having to click each individual item.

Can also move an item to the recycler tab by holding down R instead.
Keys can be configure.

The recycler move functionality was commissioned by The Jabberwocky.

[h1]Configuration[/h1]

The configuration file will be created on the first game run and can be found at [i]%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\MouseMoveTransfer\config.json[/i].

[h2]Disable Sound[/h2]

By default the transfer sound is disabled, but can be re-enabled to the game's default:
[table]
[tr]
[td]Name
[/td]
[td]Default
[/td]
[td]Description
[/td]
[/tr]
[tr]
[td]DisableMoveSound
[/td]
[td]true
[/td]
[td]If true, items transferred will not make a sound
[/td]
[/tr]
[tr]
[td]Keys
[/td]
[td]Ctrl + Left mouse button
[/td]
[td]The key or keys to hold down to transfer the hovered item. See the Keys and/or Mouse Buttons
[/td]
[/tr]
[tr]
[td]RecyclerKey
[/td]
[td]R
[/td]
[td]The key or keys to hold down to move the hovered item to the recycler. See the Keys and/or Mouse Buttons section below for format.
[/td]
[/tr]
[/table]

[h2]Keys and/or Mouse Buttons[/h2]

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

[h2]1.3.0[/h2]
[list]
[*]Added the "move to recycler" functionality.
[/list]

[h2]1.2.1[/h2]
[list]
[*]Fix for the audio incorrectly being muted too much.
[/list]

[h2]1.2.0[/h2]
[list]
[*]Upgraded the activation keys to key chords.
[*]Added the option to not disable the transfer sound.
[/list]

[h2]1.1.0[/h2]
[list]
[*]Added config for modifier key.
[/list]
