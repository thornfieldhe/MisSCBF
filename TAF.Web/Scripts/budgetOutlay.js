﻿var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var $this = this;
        $("#searchSheet").select2().on("change", function(e) {
            abp.services.app.budgetOutlay.get($("#searchSheet").val())
                .done(function (r) {
                    $this.list = r;
            });
        });
        $(".fileUpload").liteUploader({
            script: defaultUrl + "BudgetOutlay/Upload"
        })
        .on("lu:success", function (e, response) {
                $this.loadSheets();
            taf.notify.success("年度预算支出导入成功");    
        });

        $(".fileUpload").change(function () {
            $(this).data("liteUploader").startUpload();
        });
        $this.loadSheets();
        $this.loadReceipt();
    },
    data: {
        sheet: { key: "", value: "" },
        selectItems:[],
        selectItem: "",
        list: {},
        list2:{}
    },
    methods: {
        loadSheets: function () {
            var $this = this;
            abp.services.app.budgetOutlay.getSheetNames()
                .done(function (r) {
                    taf.successiveBindSelect($("#searchSheet"), r);
                });
        },
        loadReceipt: function () {
            var $this = this;
            abp.services.app.budgetReceipt.get(0)
                .done(function (r) {
                    $this.list2 = r;
                });
        },
        update: function () {
            var $this = this;
            if ($this.selectItem === "" || $this.selectItems.length == 0) {
                taf.notify.danger("收入项或支出项不能为空");
            } else {
                abp.services.app.budgetOutlay.update({ id: $this.selectItem, outlayIds: $this.selectItems, code: _.find($this.list2, function (m) { return m.id === $this.selectItem }).code })
                    .done(function (r) {
                        abp.services.app.budgetOutlay.getSheetNames()
                            .done(function (s) {
                                taf.successiveBindSelect($("#searchSheet"), s);
                                $this.list = [];
                                $("#searchSheet").select2().val("").trigger("change");
                                taf.notify.success("年度预算支出更新成功");
                            });
                    }); 
            }
        }
    }
});



