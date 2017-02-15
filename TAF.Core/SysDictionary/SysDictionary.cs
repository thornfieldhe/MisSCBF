// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dictionary.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统字典表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Dictionary
{
    /// <summary>
    /// 系统字典表
    /// </summary>
    public class SysDictionary : TAFEntity
    {
        /// <summary>
        /// 使用DictionaryCategory的分类属性
        /// </summary>
        public string Key
        {
            get; set;
        }

        public string Value
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }
    }
}