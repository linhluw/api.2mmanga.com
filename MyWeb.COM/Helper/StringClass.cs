using System;
using System.Text.RegularExpressions;

namespace MyWeb.COM.Helper
{
    public class StringClass
    {
        public static string NameToSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string NameToTag(string strName)
        {
            string strReturn = "";
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            strReturn = Regex.Replace(strName, "[^\\w\\s]", string.Empty).Replace(" ", "-").ToLower();
            string strFormD = strReturn.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
        }

        public static string HtmlDecodeUTF8(string item)
        {
            return System.Net.WebUtility.HtmlDecode(item);
        }

        public static string CropDomain(string item)
        {
            return Regex.Match(item.Trim(), "http.*?//(.*?)/")?.Groups[1].Value ?? string.Empty;
        }

        /// <summary>
        /// Kiểm tra link out và gán nofollow
        /// </summary>
        /// <param name="dauvao"></param>
        /// <returns></returns>
        public static string ChangeNofollow(string dauvao,string domain)
        {
            string content = dauvao;
            try
            {
                MatchCollection matches;
                string _timchuoi = @"<a[^>]*? href=""(?<url>[^""]+)""[^>]*?>(?<text>.*?)</a>";
                Regex myRegex = new Regex(_timchuoi);
                matches = myRegex.Matches(dauvao);
                foreach (Match m in matches)
                {
                    if (!m.Groups["url"].Value.Contains(domain))
                    {
                        var nofollow = "<a href=\"" + m.Groups["url"].Value + "\" rel=\"nofollow\" target=\"_blank\">" + m.Groups["text"].Value + "</a>";

                        content = content.Replace(m.Value, nofollow);
                    }
                }
            }
            catch (Exception ex)
            {
                return dauvao;
            }
            return content;
        }

        /// <summary>
        /// Kiểm tra link img xem có gán thẻ mổ ta alt chưa
        /// </summary>
        /// <param name="dauvao"></param>
        /// <returns></returns>
        public static string ChangeAltIMG(string dauvao, string altname)
        {
            string content = dauvao;
            try
            {
                MatchCollection matches;
                string _timchuoi = @"<img.*?src=""(?<url>.*?)"".*?>";
                Regex myRegex = new Regex(_timchuoi);
                matches = myRegex.Matches(dauvao);
                foreach (Match m in matches)
                {
                    var alt = altname;
                    var m2 = Regex.Match(m.Value, @"<img.*?alt=""(?<text>.*?)"".*?>");
                    if (m2 != null)
                    {
                        alt = !string.IsNullOrEmpty(m2.Groups["text"].Value) ? m2.Groups["text"].Value : altname;
                    }

                    var img = "<img src=\"" + m.Groups["url"].Value + "\" alt=\"" + alt + "\" />";

                    content = content.Replace(m.Value, img);
                }

            }
            catch (Exception ex)
            {
                return dauvao;
            }
            return content;
        }
    }
}
