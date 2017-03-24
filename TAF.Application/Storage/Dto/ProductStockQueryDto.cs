// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   入库查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.Runtime.Validation;

    /// <summary>
    /// 商品库存查询对象
    /// </summary>
    public class ProductStockQueryDto : ICustomValidate
    {
        /// <summary>
        /// StorageId
        /// </summary>
        public Guid StorageId
        {
            get; set;
        }

        /// <summary>
        /// Code
        /// </summary>
        [Required(ErrorMessage = "商品编码不能为空")]
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// IsSpecial
        /// </summary>
        public bool IsSpecial
        {
            get; set;
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (this.StorageId == Guid.Empty)
            {
                context.Results.Add(new ValidationResult("仓库不能为空"));
            }
        }
    }
}



