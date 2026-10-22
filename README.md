<p align="center"> 
  <img align="center" src="https://github.com/0xLaileb/Fan-Bots/blob/master/GITHUB_RESOURCES/logo.png?raw=true" width="150"/> 
</p>

<h1><div align="center">Fan-Bot's</h1>
<p align="center">
  <img src="https://img.shields.io/badge/PRICE-free-%231DC8EE"/>
  <img src="https://img.shields.io/badge/.NET_FRAMEWORK-4.7-%231DC8EE"/>
  <img src="https://img.shields.io/badge/SUPPORT-no-%231DC8EE"/>
</p>

<p align="center">
  <img src="https://img.shields.io/github/last-commit/0xLaileb/Fan-Bots?color=%231DC8EE&label=LAST%20COMMIT&style=flat"/>
</p>

<p align="center">
  This <b>free software</b> launches bots on Warface game servers.<br>
  The bot executable (<code>wb.exe</code>) is a modification of <a href="https://github.com/Levak/warfacebot" target="_blank">warfacebot</a> by Levak.<br>
</p>

> **Note:** this project is archived and no longer maintained. There is no technical support.

[wf_ru]: https://ru.warface.com/
[commands]: https://github.com/0xLaileb/Fan-Bots/blob/master/RELEASE/COMMANDS.txt

## 🤖 Features

- Launches bots (a modified warfacebot) on Warface game servers.
- Authorization through MailRu, MyCom and GoPlay.
- Two-factor authorization support.
- Configurable launch options, bots, colors, and more.
- Automatic commands (executed when a bot starts).
- Automatic key updates.
- Start all bots at once and restart them.
- Saves account data, settings and logs (for authorization and for the bots).

## 🔎 Main launcher
![](https://github.com/0xLaileb/Fan-Bots/blob/master/GITHUB_RESOURCES/gui.gif?raw=true)

## 🚀 How to use

- ### Safe launch
Run the launcher on a **virtual machine** that has **neither Warface nor the Game Center** installed. Otherwise you may get your **main account banned** (the one currently running in the game).

- ### Supported email domains (RU region): @mail.ru | @inbox.ru | @list.ru | @bk.ru | other domains may be added in the future

- ### You need a Warface game account

1. Register on the server you want to use (for the RU region: **[ru.warface.com][wf_ru]**).
2. The game account you use for a bot must not be in use elsewhere.
3. It must not be banned.

- ### Starting a bot
1. Build the project (see [For developers](#-for-developers)). The build output goes into the `RELEASE` folder.
2. Move the `RELEASE` folder to a convenient location.
3. Run `START.exe` from it.
4. Select a `server`.
5. Enter the `login` and `password` of the game account that will act as the bot.
6. Click `LOG IN`.

- ### The list of bot commands is available [here][commands].

## 🔧 For developers
- ### Project information
1. Target runtime: `.NET Framework 4.7`
2. Development environment: `Visual Studio 2019`

- ### Building the project
1. Install Visual Studio (make sure to include C# and .NET Framework 4.7).
2. Download the source code (`Code` -> `Download ZIP`).
3. Build the projects in this order: `AUTHORIZATION` -> `LAUNCHER_FANBOT` -> `START`.
4. Run it following the [usage instructions](https://github.com/0xLaileb/Fan-Bots#-how-to-use).

- ### Known issues and to-do list
1. Rewrite the EU authorization.
2. Add support for @yandex, @gmail, etc. to the RU authorization.

## 📄 License

Released under the GNU Affero General Public License v3.0. See [LICENSE](LICENSE).
