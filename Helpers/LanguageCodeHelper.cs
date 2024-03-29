﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Translator
{
    internal class LanguageCodeHelper
    {
        public static string GetLanguageLabelByLCID(int lcId)
        {
            #region Language Codes
            Dictionary<int, string> lcIds = new Dictionary<int, string>();

            lcIds.Add(1025, "Arabic - Saudi Arabia");
            lcIds.Add(1026, "Bulgarian");
            lcIds.Add(1027, "Catalan");
            lcIds.Add(1028, "Chinese - Taiwan");
            lcIds.Add(1029, "Czech");
            lcIds.Add(1030, "Danish");
            lcIds.Add(1031, "German - Germany");
            lcIds.Add(1032, "Greek");
            lcIds.Add(1033, "English - United States");
            lcIds.Add(1034, "Spanish - Spain (Traditional Sort)");
            lcIds.Add(1035, "Finnish");
            lcIds.Add(1036, "French - France");
            lcIds.Add(1037, "Hebrew");
            lcIds.Add(1038, "Hungarian");
            lcIds.Add(1039, "Icelandic");
            lcIds.Add(1040, "Italian - Italy");
            lcIds.Add(1041, "Japanese");
            lcIds.Add(1042, "Korean");
            lcIds.Add(1043, "Dutch - Netherlands");
            lcIds.Add(1044, "Norwegian (Bokmål)");
            lcIds.Add(1045, "Polish");
            lcIds.Add(1046, "Portuguese - Brazil");
            lcIds.Add(1047, "Rhaeto-Romanic");
            lcIds.Add(1048, "Romanian");
            lcIds.Add(1049, "Russian");
            lcIds.Add(1050, "Croatian");
            lcIds.Add(1051, "Slovak");
            lcIds.Add(1052, "Albanian - Albania");
            lcIds.Add(1053, "Swedish");
            lcIds.Add(1054, "Thai");
            lcIds.Add(1055, "Turkish");
            lcIds.Add(1056, "Urdu - Pakistan");
            lcIds.Add(1057, "Indonesian");
            lcIds.Add(1058, "Ukrainian");
            lcIds.Add(1059, "Belarusian");
            lcIds.Add(1060, "Slovenian");
            lcIds.Add(1061, "Estonian");
            lcIds.Add(1062, "Latvian");
            lcIds.Add(1063, "Lithuanian");
            lcIds.Add(1064, "Tajik");
            lcIds.Add(1065, "Persian");
            lcIds.Add(1066, "Vietnamese");
            lcIds.Add(1067, "Armenian - Armenia");
            lcIds.Add(1068, "Azeri (Latin)");
            lcIds.Add(1069, "Basque");
            lcIds.Add(1070, "Sorbian");
            lcIds.Add(1071, "F.Y.R.O. Macedonian");
            lcIds.Add(1072, "Sutu");
            lcIds.Add(1073, "Tsonga");
            lcIds.Add(1074, "Tswana");
            lcIds.Add(1075, "Venda");
            lcIds.Add(1076, "Xhosa");
            lcIds.Add(1077, "Zulu");
            lcIds.Add(1078, "Afrikaans - South Africa");
            lcIds.Add(1079, "Georgian");
            lcIds.Add(1080, "Faroese");
            lcIds.Add(1081, "Hindi");
            lcIds.Add(1082, "Maltese");
            lcIds.Add(1083, "Sami");
            lcIds.Add(1084, "Gaelic (Scotland)");
            lcIds.Add(1085, "Yiddish");
            lcIds.Add(1086, "Malay - Malaysia");
            lcIds.Add(1087, "Kazakh");
            lcIds.Add(1088, "Kyrgyz (Cyrillic)");
            lcIds.Add(1089, "Swahili");
            lcIds.Add(1090, "Turkmen");
            lcIds.Add(1091, "Uzbek (Latin)");
            lcIds.Add(1092, "Tatar");
            lcIds.Add(1093, "Bengali (India)");
            lcIds.Add(1094, "Punjabi");
            lcIds.Add(1095, "Gujarati");
            lcIds.Add(1096, "Oriya");
            lcIds.Add(1097, "Tamil");
            lcIds.Add(1098, "Telugu");
            lcIds.Add(1099, "Kannada");
            lcIds.Add(1100, "Malayalam");
            lcIds.Add(1101, "Assamese");
            lcIds.Add(1102, "Marathi");
            lcIds.Add(1103, "Sanskrit");
            lcIds.Add(1104, "Mongolian (Cyrillic)");
            lcIds.Add(1105, "Tibetan - People's Republic of China");
            lcIds.Add(1106, "Welsh");
            lcIds.Add(1107, "Khmer");
            lcIds.Add(1108, "Lao");
            lcIds.Add(1109, "Burmese");
            lcIds.Add(1110, "Galician");
            lcIds.Add(1111, "Konkani");
            lcIds.Add(1112, "Manipuri");
            lcIds.Add(1113, "Sindhi - India");
            lcIds.Add(1114, "Syriac");
            lcIds.Add(1115, "Sinhalese - Sri Lanka");
            lcIds.Add(1116, "Cherokee - United States");
            lcIds.Add(1117, "Inuktitut");
            lcIds.Add(1118, "Amharic - Ethiopia");
            lcIds.Add(1119, "Tamazight (Arabic)");
            lcIds.Add(1120, "Kashmiri (Arabic)");
            lcIds.Add(1121, "Nepali");
            lcIds.Add(1122, "Frisian - Netherlands");
            lcIds.Add(1123, "Pashto");
            lcIds.Add(1124, "Filipino");
            lcIds.Add(1125, "Divehi");
            lcIds.Add(1126, "Edo");
            lcIds.Add(1127, "Fulfulde - Nigeria");
            lcIds.Add(1128, "Hausa - Nigeria");
            lcIds.Add(1129, "Ibibio - Nigeria");
            lcIds.Add(1130, "Yoruba");
            lcIds.Add(1131, "Quecha - Bolivia");
            lcIds.Add(1132, "Sepedi");
            lcIds.Add(1136, "Igbo - Nigeria");
            lcIds.Add(1137, "Kanuri - Nigeria");
            lcIds.Add(1138, "Oromo");
            lcIds.Add(1139, "Tigrigna - Ethiopia");
            lcIds.Add(1140, "Guarani - Paraguay");
            lcIds.Add(1141, "Hawaiian - United States");
            lcIds.Add(1142, "Latin");
            lcIds.Add(1143, "Somali");
            lcIds.Add(1144, "Yi");
            lcIds.Add(1145, "Papiamentu");
            lcIds.Add(1152, "Uighur - China");
            lcIds.Add(1153, "Maori - New Zealand");
            lcIds.Add(2049, "Arabic - Iraq");
            lcIds.Add(2052, "Chinese - People's Republic of China");
            lcIds.Add(2055, "German - Switzerland");
            lcIds.Add(2057, "English - United Kingdom");
            lcIds.Add(2058, "Spanish - Mexico");
            lcIds.Add(2060, "French - Belgium");
            lcIds.Add(2064, "Italian - Switzerland");
            lcIds.Add(2067, "Dutch - Belgium");
            lcIds.Add(2068, "Norwegian (Nynorsk)");
            lcIds.Add(2070, "Portuguese - Portugal");
            lcIds.Add(2072, "Romanian - Moldava");
            lcIds.Add(2073, "Russian - Moldava");
            lcIds.Add(2074, "Serbian (Latin)");
            lcIds.Add(2077, "Swedish - Finland");
            lcIds.Add(2080, "Urdu - India");
            lcIds.Add(2092, "Azeri (Cyrillic)");
            lcIds.Add(2108, "Gaelic (Ireland)");
            lcIds.Add(2110, "Malay - Brunei Darussalam");
            lcIds.Add(2115, "Uzbek (Cyrillic)");
            lcIds.Add(2117, "Bengali (Bangladesh)");
            lcIds.Add(2118, "Punjabi (Pakistan)");
            lcIds.Add(2128, "Mongolian (Mongolian)");
            lcIds.Add(2129, "Tibetan - Bhutan");
            lcIds.Add(2137, "Sindhi - Pakistan");
            lcIds.Add(2143, "Tamazight (Latin)");
            lcIds.Add(2144, "Kashmiri (Devanagari)");
            lcIds.Add(2145, "Nepali - India");
            lcIds.Add(2155, "Quecha - Ecuador");
            lcIds.Add(2163, "Tigrigna - Eritrea");
            lcIds.Add(3073, "Arabic - Egypt");
            lcIds.Add(3076, "Chinese - Hong Kong SAR");
            lcIds.Add(3079, "German - Austria");
            lcIds.Add(3081, "English - Australia");
            lcIds.Add(3082, "Spanish - Spain (Modern Sort)");
            lcIds.Add(3084, "French - Canada");
            lcIds.Add(3098, "Serbian (Cyrillic)");
            lcIds.Add(3179, "Quecha - Peru");
            lcIds.Add(4097, "Arabic - Libya");
            lcIds.Add(4100, "Chinese - Singapore");
            lcIds.Add(4103, "German - Luxembourg");
            lcIds.Add(4105, "English - Canada");
            lcIds.Add(4106, "Spanish - Guatemala");
            lcIds.Add(4108, "French - Switzerland");
            lcIds.Add(4122, "Croatian (Bosnia/Herzegovina)");
            lcIds.Add(5121, "Arabic - Algeria");
            lcIds.Add(5124, "Chinese - Macao SAR");
            lcIds.Add(5127, "German - Liechtenstein");
            lcIds.Add(5129, "English - New Zealand");
            lcIds.Add(5130, "Spanish - Costa Rica");
            lcIds.Add(5132, "French - Luxembourg");
            lcIds.Add(5146, "Bosnian (Bosnia/Herzegovina)");
            lcIds.Add(6145, "Arabic - Morocco");
            lcIds.Add(6153, "English - Ireland");
            lcIds.Add(6154, "Spanish - Panama");
            lcIds.Add(6156, "French - Monaco");
            lcIds.Add(7169, "Arabic - Tunisia");
            lcIds.Add(7177, "English - South Africa");
            lcIds.Add(7178, "Spanish - Dominican Republic");
            lcIds.Add(7180, "French - West Indies");
            lcIds.Add(8193, "Arabic - Oman");
            lcIds.Add(8201, "English - Jamaica");
            lcIds.Add(8202, "Spanish - Venezuela");
            lcIds.Add(8204, "French - Reunion");
            lcIds.Add(9217, "Arabic - Yemen");
            lcIds.Add(9225, "English - Caribbean");
            lcIds.Add(9226, "Spanish - Colombia");
            lcIds.Add(9228, "French - Democratic Rep. of Congo");
            lcIds.Add(10241, "Arabic - Syria");
            lcIds.Add(10249, "English - Belize");
            lcIds.Add(10250, "Spanish - Peru");
            lcIds.Add(10252, "French - Senegal");
            lcIds.Add(11265, "Arabic - Jordan");
            lcIds.Add(11273, "English - Trinidad");
            lcIds.Add(11274, "Spanish - Argentina");
            lcIds.Add(11276, "French - Cameroon");
            lcIds.Add(12289, "Arabic - Lebanon");
            lcIds.Add(12297, "English - Zimbabwe");
            lcIds.Add(12298, "Spanish - Ecuador");
            lcIds.Add(12300, "French - Cote d'Ivoire");
            lcIds.Add(13311, "Arabic - Kuwait");
            lcIds.Add(13321, "English - Philippines");
            lcIds.Add(13322, "Spanish - Chile");
            lcIds.Add(13324, "French - Mali");
            lcIds.Add(14337, "Arabic - U.A.E.");
            lcIds.Add(14345, "English - Indonesia");
            lcIds.Add(14346, "Spanish - Uruguay");
            lcIds.Add(14348, "French - Morocco");
            lcIds.Add(15361, "Arabic - Bahrain");
            lcIds.Add(15369, "English - Hong Kong SAR");
            lcIds.Add(15370, "Spanish - Paraguay");
            lcIds.Add(15372, "French - Haiti");
            lcIds.Add(16385, "Arabic - Qatar");
            lcIds.Add(16393, "English - India");
            lcIds.Add(16394, "Spanish - Bolivia");
            lcIds.Add(17417, "English - Malaysia");
            lcIds.Add(17418, "Spanish - El Salvador");
            lcIds.Add(18441, "English - Singapore");
            lcIds.Add(18442, "Spanish - Honduras");
            lcIds.Add(19466, "Spanish - Nicaragua");
            lcIds.Add(20490, "Spanish - Puerto Rico");
            lcIds.Add(21514, "Spanish - United States");
            lcIds.Add(58378, "Spanish - Latin America");
            lcIds.Add(58380, "French - North Africa");
            #endregion Language Codes

            return lcIds[lcId];
        }
    }
}
