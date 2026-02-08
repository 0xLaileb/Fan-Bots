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
                        "Ошибка 447. Возможно аккаунт Warface не зарегистрирован.",
                        "Ошибка получения начальных токенов состояния клиента (state, clientid)",
                        "Ошибка получения начальных токенов привязки клиента (act, mrcu)",
                        "Ошибка двухфакторной аутентификации: Токен secstep оказался пустым",
                        "Пользователь отказался от ввода кода двухфакторной аутентификации",
                        "Внезапная неизвестная ошибка получения токенов авторизации",
                        "Ошибка получения причины блокировки аккаунта",
                        "На вашем аккаунте не принято пользовательское соглашение (EULA) my.games.\nБот может сделать это автоматически, но вам необходимо с ним ознакомиться.\nВы желаете ознакомиться с:\nПользовательским соглашением.\nПолитикой конфиденциальности.\nПолитикой использования файлов cookie.\nЛицензионным соглашением Игр.\nЛицензионным соглашением Игрового центра?\nДа - открыть в браузере страницы с пользовательским соглашением my.games\nНет - Не открывать пользовательское соглашение и провести автоматическое принятие\nОтмена - отказаться и остановить авторизацию",
                        "В вашем браузере сейчас открылись страницы с пользовательским соглашением my.games. Ознакомьтесь с ним и примите решение о соглашении или отказе от него.\nДа - принять пользовательское соглашение my.games\nНет - отказаться и остановить авторизацию",
                        "Пользователь отказался принимать пользовательское соглашение my.games",
                        "Ошибка получения токена для принятия пользовательского соглашения %%var%% оказался пустым",
                        "ПОДОЖДИТЕ..",
                        "ВОЙТИ",
                        "Аккаунт Заблокирован",
                        "Ошибка получения SessionKey",
                        "Ошибка авторизации. %%var%% оказался пустым",
                        "Ошибка авторизации. Возможно неверный логин или пароль",
                        "Запросы блокируются сервером авторизации.",
                        "Сервер авторизации требует прохождения ReCaptcha.",
                        "Невозомжно провести привязку аккаунта mail.ru к аккаунту my.games.\nВам потребуется выполнить разовый вход в аккаунт через account.my.games вручную",
                        "Не удалось выполнить автоматическое принятие пользовательского соглашения\nПожалуйста выполните разовый вход в аккаунт через account.my.games и примите пользовательское соглашение вручную.",
                        "Двухфакторная аутентификация",
                        "Ошибка загрузки капчи с сервера",
                        "Неверный код авторизации",
                        "Запомнить аккаунт",
                        "Ошибка авторизации OAuth. Не удалось получить токены Mpop, ssdc, ssdc_info",
                        "Введите код двухфакторной аутентификации",
                        "Ввод капчи",
                        "Ошибка регистрации сессии. Сервер не ответил ссылкой с токеном",
                    }
                }
            };
        }
    }
}