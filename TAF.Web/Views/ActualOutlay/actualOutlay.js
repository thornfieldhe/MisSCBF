var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var $this = this;
        $(".fileUpload").liteUploader({
            script: defaultUrl + "ActualOutlay/Upload"
        })
            .on("lu:success", function (e, response) {
                $this.loadActualOutlay();
                taf.notify.success("凭证导入成功");

            });

        $(".fileUpload").change(function () {
            $(this).data("liteUploader").startUpload();
        });
        $this.loadOutlay();
        $this.loadActualOutlay();
    },
    data: {
        sheet: { key: "", value: "" },
        selectItems: [],
        selectItem: "",
        list: {},
        list2: {},
        list3: {},
        queryEntity: {name:""}
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.name = "";
            this.list2 = this.list3;

        }
    },
    methods: {
        excuteQuery: function($this) {
            $this.loadOutlay();
            if ($this.queryEntity.name != '') {
                $this.list3 = $this.list2;
                return $this.list2 = $this.list2.filter(function(item) {
                    return item.name.indexOf($this.queryEntity.name) >= 0;

                });
            }
        },
        loadOutlay: function () {
            var $this = this;
            abp.services.app.budgetOutlay.getSimple()
                .done(function (r) {
                    $this.list2 = r;
                });
        },
        loadActualOutlay: function () {
            var $this = this;
            abp.services.app.actualOutlay.get()
                .done(function (r) {
                    $this.list = r;
                });
        },
        update: function () {
            var $this = this;
            if ($this.selectItem === "" || $this.selectItems.length == 0) {
                taf.notify.danger("预算支出项或凭证不能为空");
            } else {
                abp.services.app.actualOutlay.update({ id: $this.selectItem, outlayIds: $this.selectItems })
                    .done(function (r) {
                        $this.loadActualOutlay();
                        $this.loadOutlay();
                        taf.notify.success("实际支出更新成功");
                    });
            }
        }
    }
});




