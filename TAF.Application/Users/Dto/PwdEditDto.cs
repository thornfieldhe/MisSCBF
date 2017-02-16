// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PwdEditDto.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the PwdEditDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Users.Dto
{
    public class PwdEditDto
    {
        /// <summary>
        ///  �û�Id
        /// </summary>
        public long UserId
        {
            get; set;
        }

        /// <summary>
        /// ������
        /// </summary>
        public string OldPwd
        {
            get; set;
        }

        /// <summary>
        /// ������
        /// </summary>
        public string NewPwd
        {
            get; set;
        }
    }
}