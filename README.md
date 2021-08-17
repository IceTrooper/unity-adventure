# Adventure Game

![adventure-game-cutscene](https://user-images.githubusercontent.com/51023959/129758308-047de712-4890-48c1-9132-ee06cba022dd.gif)

## About

The project was to include various functionalities popular in 3d games. It was decided to create an adventure game set in a dark and hostile world while maintaining a fairy-tale atmosphere. The aim of the game is to find the brightest crystal. During the way to the crystal you can encounter monsters. You should avoid trouble, but fighting is sometimes unavoidable, so we carry a big sword to help solve some problems. The game allows you to join another player in split-screen mode, so that together we can overcome the difficulties that stand in our way.

The project is part of a game development course in Unity and is designed for classroom courses where multiple people can participate. Ask me in the DMs for a link to course (only Polish version).

### PL version

Projekt miał zawierać różne funkcjonalności popularne w grach 3d. Postanowiono stworzyć grę przygodową osadzoną w mrocznym i nieprzyjaznym świecie zachowując jednak bajkowy klimat. Celem gry jest znalezienie najjaśniejszego z kryształów. Podczas drogi do kryształu można napotkać potwory. Należy unikać kłopotów, jednak walka jest czasami nieunikniona, dlatego też nosimy przy sobie wielki miecz ułatwiający rozwiązywanie pewnych problemów. Gra pozwala na dołączenie drugiego gracza w trybie podzielonego ekranu, aby móc wspólnie pokonywać trudności, które staną na naszej drodze.

Projekt jest częścią kursu tworzenia gier w Unity i został zaprojektowany z myślą o kursach stacjonarnych, w których może uczestniczyć wiele osób. Napisz do mnie wiadomość prywatną, aby uzyskać link do kursu (tylko w wersji polskiej).

![adventure-game-1280x640](https://user-images.githubusercontent.com/51023959/129801694-c718d060-2585-4c1f-bb72-f76caabac358.jpg)

## Main features

* Sculpted terrain - using new **[Terrain Tools package](https://docs.unity3d.com/Packages/com.unity.terrain-tools@4.0/manual/index.html)**

* 3D objects made with **ProBuilder**

* Two fully animated characters based on **CharacterController**, controlled with the new **Input System**

* Split screen - custom solution for the two players simultanously playing on the same keyboard

* Enemies - animated enemies got a basic AI, trying to spot the player and moving with the support of NavMeshSystem and [NavMeshComponents](https://github.com/Unity-Technologies/NavMeshComponents)

* Damage system - players and enemies can attack each other

* Smooth following camera - using a **Cinemachine** 

* Cutscene - using a **Timeline**

* Main music and basic sounds - for players and spiders

## Worth to mention

* The project was designed for stationary courses in which many people can participate. The standard equipment for the station is a computer, monitor, keyboard and mouse. I wanted to show the possibilities of multiplayer mode on a split screen, so it was required to design a system of moving players using only the keyboard (without the mouse).

* It was challenging to make two players playing on the same keyboard. There are two Control Schemes for players. The task was even more tedious because players are using Cinemachine virtual cameras and the new input system (version 1.0.2) doesn't support them. That required a new Layer for every player and correct setup for virtual cameras.

* Attack action, Footsteps sounds, etc. are using Animation Events to know the point where something should happen.

## Assets

* [Mixamo](https://www.mixamo.com/) - Characters and animations

* [AllSky Free](https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014) - Skybox

* [FREE Stylized PBR Textures Pack](https://assetstore.unity.com/packages/2d/textures-materials/free-stylized-pbr-textures-pack-111778) - Textures for terrain

* [Translucent Crystals](https://assetstore.unity.com/packages/3d/environments/fantasy/translucent-crystals-106274) - Crystals

* [Environment Pack: Free Forest Sample](https://assetstore.unity.com/packages/3d/vegetation/environment-pack-free-forest-sample-168396) - Environment (trees, stones, ...)

* [Standard Assets (for Unity 2018.4)](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2018-4-32351) - Water

* [Magic swords](https://assetstore.unity.com/packages/3d/props/weapons/magic-swords-97694) - Sword

* [Meshtint Free Polygonal Metalon](https://assetstore.unity.com/packages/3d/characters/creatures/meshtint-free-polygonal-metalon-151383) - Spider enemies
