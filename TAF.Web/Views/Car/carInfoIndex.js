Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#carFormBody",
    data: function () {
        return {
            item: {
                id: "",
                category: "",
                value: "",
                title: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.sysDictionary.saveAsync($this.item)
                .done(function (m) {
                    $this.done(closeModal);
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.sysDictionary.get(id)
                .done(function (m) {
                    $this.item = m;
                    $this.item.title = main.title;
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    },
    methods: {
        clearItem: function () {
            this.item = { category: main.category, title: main.title };
            this.$resetValidation();
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var $this = this;
        $this.title = "车辆状态";
        $this.category = "Car_Status";
        $this.queryEntity.category = $this.category;
        $("#myTab").on("shown.bs.tab", function (e) {
            var id = $(e.target).attr("id");
            if (id === "pstatus") {
                $this.title = "车辆状态";
                $this.category = "Car_Status";
            } else if (id === "pdrivelevel") {
                $this.title = "驾驶等级";
                $this.category = "Car_DriveLevel";
            } else if (id === "pyear") {
                $this.title = "会计年度";
                $this.category = "Car_Year";
            } else if (id === "pminister") {
                $this.title = "部长";
                $this.category = "Car_Minister";
            } else if (id === "pattendant") {
                $this.title = "助理员";
                $this.category = "Car_Attendant";
            } else if (id === "poilHostingUnit") {
                $this.title = "油料代管单位";
                $this.category = "Car_OilHostingUnit";
            } else if (id === "poilWearSummary") {
                $this.title = "夏季起止时间";
                $this.category = "Car_OilWearSummary";
            } else if (id === "poilWearWinter") {
                $this.title = "冬季起止时间";
                $this.category = "Car_OilWearWinter";
            } else if (id === "poctaneRating") {
                $this.title = "油料标号";
                $this.category = "Car_OctaneRating";
            } else if (id === "poverhaulAmount") {
                $this.title = "大修控制额";
                $this.category = "Car_Overhaul";
            } else if (id === "prepairAmount") {
                $this.title = "中修控制额";
                $this.category = "Car_Repair";
            } else if (id === "pminorRepairAmount") {
                $this.title = "小修控制额";
                $this.category = "Car_MinorRepair";
            }  else if (id === "pmanHours") {
                $this.title = "工时";
                $this.category = "Car_ManHours";
            } else if (id === "pservicingMaterials") {
                $this.title = "维修材料";
                $this.category = "Car_ServicingMaterials";
            }
            $this.queryEntity.category = $this.category;
            $this.query(0);
        });
    },
    data: {
        queryEntity: {
            category: "",
            value: ""
        },
        category: '',
        title: ''
    },
    events: {

    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.sysDictionary.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.sysDictionary.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        newItem: function (title, category) {
            this.title = title;
            this.category = category;
            $("#addItemModal").modal("show");
            this.$broadcast('onAddItem', title);
        }
    }
});


main.query(0);



