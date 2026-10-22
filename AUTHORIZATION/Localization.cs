using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ElTennGenLocalization
{
    /*
        This Is Localization File Created by ElTennGen Program
    */
    public static class L10n
    {
        private static readonly Localization Set = new Localization();

        public static string login_error_447 => Set.Strings[0];
        public static string initialstatetokens_error => Set.Strings[1];
        public static string initialbindingtokens_error => Set.Strings[2];
        public static string secstepempty_error => Set.Strings[3];
        public static string userabandone2fa => Set.Strings[4];
        public static string banreason_error => Set.Strings[6];
        public static string notermsaccepted => Set.Strings[7];
        public static string autoacceptterms => Set.Strings[8];
        public static string userabandoneterms => Set.Strings[9];
        public static string termstoken_error => Set.Strings[10];
        public static string button1 => Set.Strings[11];
        public static string button2 => Set.Strings[12];
        public static string account_banned => Set.Strings[13];
        public static string sessionkey_error => Set.Strings[14];
        public static string autherror => Set.Strings[15];
        public static string wrongpassword => Set.Strings[16];
        public static string reqsblocked_error => Set.Strings[17];
        public static string captchablock_error => Set.Strings[18];
        public static string autoaccbindblock_error => Set.Strings[19];
        public static string autoacceptterms_error => Set.Strings[20];
        public static string tfaformcap => Set.Strings[21];
        public static string tfacaptcha_error => Set.Strings[22];
        public static string tfawrongcode => Set.Strings[23];
        public static string tfasaveaccount => Set.Strings[24];
        public static string oauthtokens_error => Set.Strings[25];
        public static string tfaentercode => Set.Strings[26];
        public static string tfacaptchaenter => Set.Strings[27];
        public static string portal_sesreg_error => Set.Strings[28];

        private class Localization
        {
            public readonly string[] Strings;
            public Localization(string Language = null)
            {
                if (Localizations.TryGetValue(string.IsNullOrEmpty(Language) ? CultureInfo.CurrentCulture.ToString() : Language, out string[] Value))
                {
                    Strings = Value;
                }
                else
                {
                    Strings = Localizations.Count > 0 ? Localizations.ElementAt(0).Value : new string[29];
                }
            }

            private static readonly Dictionary<string, string[]> Localizations = new Dictionary<string, string[]>
            {
                // Default
                {
                    "Default",
                    new []
                    {
                        "Error 447. The Warface account may not be registered.",
                        "Failed to get the initial client state tokens (state, clientid)",
                        "Failed to get the initial client binding tokens (act, mrcu)",
                        "Two-factor authentication error: the secstep token is empty",
                        "The user cancelled entering the two-factor authentication code",
                        "Unexpected unknown error while getting the authorization tokens",
                        "Failed to get the account ban reason",
                        "The my.games user agreement (EULA) has not been accepted on your account.\nThe bot can accept it automatically, but you need to read it first.\nDo you want to read the:\nUser Agreement\nPrivacy Policy\nCookie Policy\nGames License Agreement\nGame Center License Agreement?\nYes - open the my.games user agreement pages in the browser\nNo - do not open the user agreement and accept it automatically\nCancel - decline and stop the authorization",
                        "The my.games user agreement pages have been opened in your browser. Read them and decide whether to accept or decline the agreement.\nYes - accept the my.games user agreement\nNo - decline and stop the authorization",
                        "The user declined the my.games user agreement",
                        "Failed to get the token for accepting the user agreement: %%var%% is empty",
                        "PLEASE WAIT..",
                        "LOG IN",
                        "Account Banned",
                        "Failed to get the SessionKey",
                        "Authorization error. %%var%% is empty",
                        "Authorization error. The login or password may be incorrect",
                        "Requests are blocked by the authorization server.",
                        "The authorization server requires passing ReCaptcha.",
                        "Unable to link the mail.ru account to the my.games account.\nYou need to sign in to the account once manually via account.my.games",
                        "Failed to accept the user agreement automatically\nPlease sign in to the account once via account.my.games and accept the user agreement manually.",
                        "Two-factor authentication",
                        "Failed to load the captcha from the server",
                        "Invalid authorization code",
                        "Remember account",
                        "OAuth authorization error. Failed to get the Mpop, ssdc, ssdc_info tokens",
                        "Enter the two-factor authentication code",
                        "Enter captcha",
                        "Session registration error. The server did not respond with a token link",
                    }
                }
            };
        }
    }
}