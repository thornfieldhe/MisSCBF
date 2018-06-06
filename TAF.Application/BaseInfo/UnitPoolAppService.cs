// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPoolAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   模块附件关联服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using TAF.Utility;

namespace SCBF.BaseInfo
{
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 模块附件关联服务
    /// </summary>
    [AbpAuthorize]
    public class UnitPoolAppService : TAFAppServiceBase, IUnitPoolAppService
    {
        private readonly IUnitPoolRepository      _unitPoolRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;

        public UnitPoolAppService(IUnitPoolRepository unitPoolRepository,
            ISysDictionaryRepository                  sysDictionaryRepository)
        {
            this._unitPoolRepository      = unitPoolRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
        }

        public PagedResultDto<UnitPoolListDto> GetAll(string category)
        {
            var query = (from u in this._sysDictionaryRepository.GetAll().Where(r => r.Category == category)
                join d in this._unitPoolRepository.GetAll() on u.Id equals d.ItemId into go
                from gi in go.DefaultIfEmpty()
                select new UnitPoolListDto()
                {
                    Name       = u.Value,
                    Category   = u.Category,
                    ItemId     = u.Id,
                    IsSelected = ! string.IsNullOrEmpty(gi.Category)
                }).ToList();
            var list = query.ToList();

            return new PagedResultDto<UnitPoolListDto>(list.Count, list);
        }

        public async Task SaveAsync(UnitPoolEditDto input)
        {
            await this._unitPoolRepository.DeleteAsync(r => r.Category == input.Category);
            var list = input.Ids.Select(r => new UnitPool() {Category = input.Category, ItemId = r});
            this._unitPoolRepository.InsertRange(list);
        }

        /// <summary>
        /// 随机获取对象池内对象
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public KeyValue<Guid, string> GetRandomItem(string category)
        {
            var list =(from u in this._unitPoolRepository.GetAll()
                join s in this._sysDictionaryRepository.GetAll() on u.ItemId equals  s.Id
                where u.Category==category
                select       new KeyValue<Guid,string>(){Key= s.Id,Value=s.Value}).ToList();
            if (list.Count == 0)
            {
                list = this._sysDictionaryRepository.GetAllList(r => r.Category == category)
                    .Select(r => new KeyValue<Guid, string>() {Key = r.Id, Value = r.Value}).ToList();
            }
           var index= Randoms.GetRandomInt(0, list.Count - 1);

            return list[index];
        }
    }
}
