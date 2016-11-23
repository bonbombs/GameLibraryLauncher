GameLibraryLauncher
===================
Probably named something else in the near future...?

Developing GameLibraryLauncher
===================
Fork this repo and develop from the forked repo.
Submit pull requests into the development branch when adding features, fixing bugs, and so on to this repo. 


Setting Up
===================
For copyright and decency purposes, games made by other people should not be added to this repo unless given express permission.

### Adding Games
Games are located in `Assets/StreamingAssets`. When adding a new game, make a folder for that game and within it copy the exe file along with any additional folders the exe file needs to run on. Also in this folder, include thumbnail images and any files that may be needed by GameLibraryLauncher.

Also as of now, you will need to manually add in game metadata by editing `Assets/Resources/gamelibrary.json` with the game's name, description, executable path, and thumbnail path relative to its folder within the StreamingAssets folder.

_(Granted, this is probably not the most secure solution...)_
