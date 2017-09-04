Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#purchaseUnitFormBody",
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
        $this.title = "责任单位";
        $this.category = "Purchase_Unit";
        $this.queryEntity.category = $this.category;
        $("#myTab").on("shown.bs.tab", function (e) {
            var id = $(e.target).attr("id");
            if (id === "punit") {
                $this.title = "责任单位";
                $this.category = "Purchase_Unit";
            } else if (id === "pusers") {
                $this.title = "采购办人员库";
                $this.category = "Purchase_Users";
            } else if (id === "pdesignUnit") {
                $this.title = "设计单位";
                $this.category = "Purchase_DesignUnit";
            } else if (id === "ppartyA") {
                $this.title = "甲方人员";
                $this.category = "Purchase_PartyA";
            } else if (id === "pcategory") {
                $this.title = "采购类型";
                $this.category = "Purchase_Category";
            } else if (id === "pcostUnit") {
                $this.title = "造价单位";
                $this.category = "Purchase_CostUnit";
            } else if (id === "pconstructionControlUnit") {
                $this.title = "监理单位";
                $this.category = "Purchase_ConstructionControlUnit";
            } else if (id === "pbiddingAgency") {
                $this.title = "招标代理单位";
                $this.category = "Purchase_BiddingAgency";
            } else if (id === "pexpert") {
                $this.title = "评标专家";
                $this.category = "Purchase_Expert";
            } else if (id === "ppriceConsistency") {
                $this.title = "清单综合单价一致率";
                $this.category = "Purchase_PriceConsistency";
            } else if (id === "psystemscore") {
                $this.title = "质量评价体系评分";
                $this.category = "Purchase_SystemScore";
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
        search: function (category) {
            this.queryEntity.category = category;
            this.query(0);
        },
        excuteQuery: function ($this) {
            abp.services.app.sysDictionary.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        resetSearch: function () {
            this.queryEntity.value = "";
            this.queryEntity.value2 = "";
            this.queryEntity.note = "";
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



