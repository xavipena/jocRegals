using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace JocRegals.Configuration
{
    internal class Constants
    {
        // General
        public const string YES = "Y";
        public const string NO = "N";

        public const string SAY_YES = "Sí";
        public const string SAY_NO = "No";
        public const string SAY_OK = "OK";

        // Various
        public const char Blank = ' ';
        public const char Period = '.';
        public const char Comma = ',';

        public const string Space = " ";
        public const string _Comma = ",";
        public const string Prompt = " :-> ";
        public const string Separator = "  ";
        public const string Slash = "/";
        public const string SingleQuote = "'";
        public const string Percent = "%";
        public const string Star = "*";
        public const string NOD = "#N/D";
        public const string INVALID_KEY = "*Err";
        public const string EMPTY_QUOTE = "''";
        public const string EMPTY_DATE = "00/00/0000";
        public const string NOT_FOUND = "x";
    }

    public static class Language
    {
        public const string Spanish = "es_ES";
        public const string Catalan = "ca_ES";
        public const string Basque = "eu_ES";

        public static class Short
        {
            public const string Spanish = "CAS";
            public const string Catalan = "CAT";
            public const string Basque = "EUS";
        }
    }

    public static class Culture
    {
        public const string Spanish = "es-ES";
        public const string English = "en-US";
    }

    public static class Delimiters
    {
        public const string Data = ";";
        public const string Token = "|";
        public const string Slash = "/";
        public const string Date = "/";
        public const string Unique = "|-|";
        public const string Description = " - ";
    }

    public static class Days
    {
        public const int WEEK = 7;
        public const int MONTH = 30;
    }
    public static class Currency
    {
        public const string Euro = "€";
        public const string Dollar = "$";
    }
    public static class Types
    {
        public static class Pickers
        {
            public const int MONTH = 1;
            public const int YEAR = 2;
        }
    }
    public static class Options
    {
        public const int PLAYERS = 1;
        public const int TIMERS = 2;
        public const int GIFTS = 3;
    }

    public static class Round
    {
        public const int Start = 0;
        public const int First = 1;
        public const int Second = 2;
        public const int End = 9;
    }
    public static class Sound
    {
        public const string Success = "tadafanfare.mp3";
        public const string Failure = "wahwahwah.mp3";
        public const string Surprise = "surprise.mp3";
        public const string Final = "christmas.mp3";
        public const string Intro = "we-wish-you.mp3";
    }
}
