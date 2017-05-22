﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskService_Test.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   TaskService_Test
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Tests.BaseInfo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Castle.Core.Logging;

    using NSubstitute.Core;

    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
    using SCBF.Users.Dto;

    using Shouldly;

    using Xunit;

    /// <summary>
    /// 
    /// </summary>
    public class TaskService_Test : TAFTestBase
    {
        private readonly ISysDictionaryAppService sysDictionaryAppService;
        private readonly IHisStockAppService hisStockAppService;
        private readonly ILogger logger;

        public TaskService_Test()
        {
            sysDictionaryAppService = Resolve<ISysDictionaryAppService>();
            hisStockAppService = Resolve<IHisStockAppService>();
        }

        [Fact]
        public void BackupData_Test()
        {
            // Act
            hisStockAppService.BackupData();

            // Assert

            this.hisStockAppService.GetAll(
                    new HisStockQueryDto() { DateFrom = DateTime.Today.AddDays(-1), DateTo = DateTime.Today })
                .Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task SaveYearAsync_Test()
        {
            // Act
          await  sysDictionaryAppService.SaveYearAsync(new SysDictionaryEditDto() { Value = "2018", Category = DictionaryCategory.Material_Year });

            // Assert

          var result=  this.sysDictionaryAppService.GetAll(
                new SysDictionaryQueryDto()
                {
                    Category = DictionaryCategory.Material_Year,
                    Value4 = true.ToString()
                }).Items[0];
            result.Value.ShouldBe("2018");
        }
    }
}