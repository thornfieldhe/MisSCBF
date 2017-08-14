// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairCostAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.UI;
using System.Linq;

namespace SCBF.Car
{
    using Abp.Authorization;
    using Abp.AutoMapper;
    using AutoMapper;
    using SCBF.Car.Dto;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// 车辆维修审批单服务
    /// </summary>
    [AbpAuthorize]
    public class RepairCostAppService : TAFAppServiceBase, IRepairCostAppService
    {
        private readonly IRepairCostRepository _repairCostRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;

        public RepairCostAppService(IRepairCostRepository repairCostRepository,
            ISysDictionaryRepository sysDictionaryRepository
            )
        {
            this._repairCostRepository = repairCostRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
        }

        public decimal GetBalance(string category)
        {
            var year = DateTime.Now.Year;
            var repairBalance = this._sysDictionaryRepository.FirstOrDefault(r => r.Category == category && r.Value2 == year.ToString());
            if (repairBalance == null)
            {
                throw new UserFriendlyException("年度维修预算金额不能为空");
            }
            var total = decimal.Parse(repairBalance.Value);
            var cost = _repairCostRepository.GetAllList(r => r.Year == year && r.Category == category).Sum(r => r.Cost);
            return total - cost;
        }

        public async Task SaveAsync(RepairCostEditDto input)
        {
            var item = input.MapTo<RepairCost>();
            if (!input.Id.HasValue)
            {
                await this._repairCostRepository.InsertAsync(item);
            }
            else
            {
                var old = this._repairCostRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._repairCostRepository.UpdateAsync(old);
            }
        }
    }
}



