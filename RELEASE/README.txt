Answers to popular questions:

[REMINDER]
1. There are now 3 ways to launch Fan-Bot's: A) DANGEROUS B) SAFE C) SAFE+.
A - launch Fan-Bot's on your main machine (PC), where Warface, the MRAC anti-cheat and the Game Center (GC) are present.
The chance of a ban is high, because you can be detected by signature analysis.
B - launch Fan-Bot's on a virtual machine (on a 2nd PC or a dedicated server) where Warface, the MRAC anti-cheat and the GC are NOT present.
The chance of a ban is medium: you cannot be detected by signature analysis, but you can be detected by IP.
C - launch Fan-Bot's on a virtual machine (on a 2nd PC or a dedicated server) where Warface, the MRAC anti-cheat and the GC are NOT present, and also use a VPN or proxy.
The chance of a ban is low: you can be detected neither by signature analysis nor by IP.
2. Fan-Bot's supports Windows 7 - 10 (x64 & x86 (x32)).
3. We are not responsible for your accounts. You are violating the rules of the Warface game, which you agreed to, so everything is at YOUR OWN RISK!
4. Links to the source code of the modification (wb.exe) and to the source code of the launchers can be found in the file: SOURCE_CODE.FANBOT
5. There is no technical support!

The project page is: https://github.com/0xLaileb/Fan-Bots
We recommend installing / updating to the latest version of:
1. Windows 10
2. Microsoft Visual C++
3. .NET Framework
4. Drivers

1. I run "Start.exe", a console window opens and closes immediately. What should I do?
> This is a built-in safeguard against running Fan-Bot's on a machine where Warface or the Game Center is running. Just run Fan-Bot's where there is no Warface and no GC (you can use a virtual machine).

2. What should I do if the executable "Start.exe" does not start (I run Fan-Bot's where there is no Warface and no GC)?
> 1) Check whether ".NET Framework 4.7" and "Microsoft Visual C++ 2010" are installed.
> 2) If they are not installed, download and install them:
https://www.microsoft.com/en-US/download/details.aspx?id=55170
https://www.microsoft.com/en-US/download/details.aspx?id=5555
> 3) Restart your PC after the installation.
> 4) Try starting again.

3. I click "LOG IN" and get an authorization error.
> 1) Check your account details (login / password).
> 2) Try typing your login and password in lower case.
> 3) Change your password to a strong password that consists only of English letters and digits.
> 4) Disable your antivirus.
> 5) Check your network connection.

4. Can I get banned for this?
> 1) Twinks (bots): Yes. They can be banned if someone files a complaint against them. The account will then be checked, and things like launches without reports (that is, without MRAC) will be found, which is evidence that the account is a bot. If no complaint is filed, the chance is still low (as of 16.07.2020).
> 2) Main account: Your main account can be banned if you are caught using bots, or if Fan-Bot's is detected on your PC. For example, if you launched it on the machine where the game is running, the account that is running in the game at the same time as Fan-Bot's will be banned (for example, you launched your main account and Fan-Bot's with bots: the anti-cheat will detect Fan-Bot's by its signatures and ban the account that is currently running in the game / GC).

5. I click "LOG IN" and the console starts, but no account information (profile ID, nickname) appears.
> 1) This means that a game update has been released or the servers are unavailable at the moment. Check the news of the Warface project you play. If an update has been released, wait for Levak to update the keys (it takes from a few minutes to a couple of days).
> 2) If there was no game update and the servers are available, the authorization may have been changed. In that case, wait for news from the project.

6. Is my account data sent anywhere? Is there a risk of losing my account when using Fan-Bot's?
> 1) Our software does not steal your account data. You can verify this by reading the source code (the source code of the launchers and wb.exe).
> 2) Your account information is stored in the file "accounts.ini", so that you do not have to enter your login and password every time. There is also an authorization log, "MailRuAuthLog.log". It is created to help find out why an authorization error occurs for specific users, and it is overwritten on every new authorization.
> 3) Before giving Fan-Bot's to someone else, delete the files "accounts.ini" and "MailRuAuthLog.log" and the folder "QueryCache" (all of them are in the bin folder; you can also delete these files through the authorization launcher), and reset the settings through the authorization launcher.

7. I want to log in to EU, but I get an authorization error.
> 1) Check whether your VPN is enabled.
> 2) Check your account details (login / password).
> 3) Try typing your login and password in lower case.
> 4) Change your password to a strong password that consists only of English letters and digits.
> 5) Disable your antivirus.
> 6) Check your network connection.

8. I cannot open the Fan-Bot's archive.
> 1) Check whether WinRAR or 7-Zip is installed. If not, install one of them.
> 2) Check whether your antivirus has deleted the archive.

9. Why does the bot leave the room when the lobby starts?
> 1) Remember that the bot cannot enter the game itself, so it leaves the room after the lobby starts. You can change this with the command: wb_leave_on_start 0

10. Why does the bot disconnect after 30 seconds?
> 1) MRAC is partly to blame. The Warface server expects reports from MRAC (PC data and so on). If they do not arrive, the player is kicked. The bot joins without MRAC, hence the disconnect.

11. I get an "Account blocked" message.
> 1) This means that the account you tried to launch is banned.

12. Why can't the bots enter the match itself to farm kills?
> 1) The way the bots are launched does not allow it: a player in a match cannot be emulated.

13. My game crashes when I start Fan-Bot's. What should I do?
> 1) Make sure you run Fan-Bot's where there is no game and no GC (for example, on a virtual machine).
> 2) If you run Fan-Bot's in a separate environment (virtual machine / dedicated server / 2nd PC), your main machine may have received a hardware ban.
> 3) Make sure you are not launching the same account that is running in the game itself.
> 4) Make sure your system meets the requirements of Warface.

14. The message "Error starting CMD!" appears.
> 1) Delete all versions of Fan-Bot's and download the latest version.

15. How do I farm Meat Grinder / Survival / Team Deathmatch modes?
> 1) Wait until the end of the match.
or
> 2) Farm together with a friend.
or
> 3) Have a 2nd PC.

16. How do I run Fan-Bot's so that my main account is not banned?
> Read the reminder above.

17. What should I do if the message "Perhaps you have no Internet access, or the mode of obtaining keys is not available!" appears?
> 1) Run the authorization launcher.
> 2) Open "GLOBAL SETTINGS".
> 3) In the "Keys" group, select "Custom Keys".
> 4) Follow the link: https://github.com/Levak/warfacebot
> 5) Click the green "Code" button (formerly "Clone or download") and select "Download ZIP".
> 6) The archive is downloaded.
> 7) Open the archive and copy the "cfg" folder to your desktop.
> 8) Open the folder where Fan-Bot's is located.
> 9) Go to: "Fan-Bot's\bin\cfg\server".
> 10) Now open the "cfg" folder on your desktop.
> 11) Go to "cfg\server".
> 12) Copy all the files.
> 13) Paste them into "Fan-Bot's\bin\cfg\server" (the folder you opened), replacing the existing files.
> 14) Launch Fan-Bot's and the bots.
> 15) Thanks to the Fan-Bot's team and Levak.

FAN-BOT'S SUPPORTS WINDOWS 7, 8, 8.1, 10 (x64 \ x86 (x32)).
