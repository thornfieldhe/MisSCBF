// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   字符串扩展方法
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Tools
{
    /// <summary>
    /// 字符串扩展方法
    /// </summary>
    public  class StringExtensions
    {
        public static string NumberToChinese(string numberStr)
        {
            string numStr     = "0123456789";
            string chineseStr = "零一二三四五六七八九";
            char[] c          = numberStr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                int index = numStr.IndexOf(c[i]);
                if (index != -1)
                    c[i] = chineseStr.ToCharArray()[index];
            }
            numStr     = null;
            chineseStr = null;
            return new string(c);
        } 

        public static string ChineseTONumber(string chineseStr1)
        {
            string numStr     = "0123456789";
            string chineseStr = "零一二三四五六七八九";
            char[] c          = chineseStr1.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                int index = chineseStr.IndexOf(c[i]);
                if (index != -1)
                    c[i] = numStr.ToCharArray()[index];
            }
            numStr     = null;
            chineseStr = null;
            return new string(c);
        }
    }
}
