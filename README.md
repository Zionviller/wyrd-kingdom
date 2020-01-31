# Wyrd Kingdom

## Description
Wyrd kingdom is a turn based RPG where the player assumes the life of a witch living their life in a magical forest. Currently, no detailed plans for the direction of the game, but it is Roguelike-like-like-like inspired and may have a Kingdom-like game loop.

### Controls
- Press 'R' to to cast World Regeneration spell. (Apples will survive the apocalypse..)
- Control Player with 'WASD'
- Pickup apples with 'E'
- Check inventory with 'I'

## Changelog
### [0.0.6] - 2020-01-30
- Renamed stuff
- Further separated map generation from map gameobject
- Fixed apple growing and pickup

### [0.0.5] - 2020-01-29
- Separated Random map generation from map view generation
- Added prop field to tiles
- Reworked tile gameobject instantiation to operate as a pool (probably a waste of time as map sizes arent changed/generated often)

### [0.0.4] - 2020-01-21
- Created Inventory component
- Items added to inventory on pickup

### [0.0.3] - 2020-01-21
- Created Item component
- Added simple item spawning
- Added eating apples
- Moved some of the game initialization to Game Manager

### [0.0.2] - 2020-01-20
- Cleaned up Actor / Controller relationship
- Cleaned up map generation, made for faster map regeneration
- Removed first attempt to work with Perlin noise

### [0.0.1] - 2020-01-19
- Added basic player controls
- Added basic random map generation

## TODO:
- Add Item effects
- Add other Actors. NPCs, Enemies, Animals.. etc.
- Turn Management
- Make map generation look more natural. Coasts, clumps of trees, rivers, etc.
