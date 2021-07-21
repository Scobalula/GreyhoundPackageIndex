# Community Asset Naming Specification

Below is the specification for our community effort for identifying and naming model, animation, and image assets in Black Ops Cold War and Black Ops 4. It is also suggested that you attempt to try and guess the names, hash the names using the hash algorithm then see if it matches with the hash in-game. This way you will get hash corrected names.

When submitting name changes, you must copy the hash portion of the asset name, Ex: "xmodel\_<260921f6390e9cb>" you would copy just the part inside of <>, then separate the actual name with a comma like so:

```
260921f6390e9cb,p8_rock_snowy_01 // Example (not valid name)
```

## Models

### Player Body Parts

```
c_t8_<game mode>_<player name>_<body part name>_<index not already specified>
Example:
c_t8_mp_seraph_head_01
```

### AI and AI Parts

```
c_<game mode>_<map specific name>_<name>_<index if not unique>
Example:
c_zom_botd_zombie_body_01
```

### Weapons

```
wpn_t8_<weapon name>_<world or view>
Example:
wpn_t8_mx9_view
```

### Weapon Attachments

```
<attach or wpn for modifiers>_t8_<type>_<name>_<view or world>
Example:
attach_t8_optic_reflex_view
```

### Misc Models

```
p8_<map specific name>_<name>_<index if not unique>
Example:
p8_global_rock_snowy_01
```

## Animations

### Player Animations

```
pb_<action>_<description>
Example:
pb_hole_run_slide
```

### AI Animations

```
ai_<name>_<description>
Example:
ai_zombie_base_death_pose
```

### Weapon Animations

```
vm_<weapon name>_<description>
Example:
vm_mx9_reload_empty
```

## Images

### Player Bodies

```
i_c_<player name>_<body part>_<usage>
Example:
i_c_seraph_arms_c
```

### Weapons

```
i_wpn_t8_<name>_<part>_<usage>
Example:
i_wpn_t8_mx9_barrel_c
```

### Misc Images

```
i_mtl_p8_<name>_<usage>
Example:
i_mtl_p8_rock_snowy_01_c
```
