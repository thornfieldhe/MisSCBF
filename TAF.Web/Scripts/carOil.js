var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        $("#searchCarInfoId").select2()
            .on("change", function (e) {
                $this.queryEntity.carInfoId = $("#searchCarInfoId").val();
            });
        $("#editCarInfoId").select2()
            .on("change", function (e) {
                $this.item.carInfoId = $("#editCarInfoId").val();
            });
        $("#editMonth").select2()
            .on("change", function (e) {
                $this.item.month = $("#editMonth").val();
            });
    },
    data: {
        queryEntity: {
            carInfoId: "",
            year : "",
            month : ""
        },
        list: {
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: taf.defatulPageSize, //每页显示1项  
                callback: function (index, jq) {
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total ? main.list.pageSize * (index + 1) : main.list.total;
                    main.queryEntity.skipCount = taf.defatulPageSize * index;
                }
            }
        },
        item: {
            id : "",
            carInfoId : "00000000-0000-0000-0000-000000000000",
            kilometres : 0,
            year : 0,
            month :0,
            amount : 0,
        }
    },
    methods: {
        showDeleteDialog: function (id, name) {
            var $this = this;
            $("#deleteCarOilDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.carOil.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteCarOilDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name, id) {
            var $this = this;
            $("#modifyCarOilDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !== null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.carOil.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editCarInfoId").select2().val($this.item.carInfoId).trigger("change");
                        $("#editMonth").select2().val($this.item.month).trigger("change");
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            } else {
                $this.modifyEntity.editModel = false;
                $this.clear();
            }
        },
        save: function () {
            var $this = this;
            abp.services.app.carOil.saveAsync($this.item)
                .done(function (m) {
                    $this.query(0);
                    $("#modifyCarOilDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        saveNew: function () {
            var $this = this;
            abp.services.app.carOil.saveAsync($this.item)
                .done(function (m) {
                    $this.query(0);
                    $this.clear();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        clear: function () {
            this.item.id = "";
            this.item.carInfoId = "00000000-0000-0000-0000-000000000000";
            $("#editCarInfoId").select2().val("").trigger("change");
            $("#editMonth").select2().val("").trigger("change");
            this.item.kilometres = 0;
            this.item.year = 0;
            this.item.month = 0;
            this.item.amount = 0;
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.carOil.getAll($this.queryEntity)
                .done(function (r) {
                    $this.list.items = r.items;
                    $this.list.total = r.totalCount;
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total ? main.list.pageSize * (index + 1) : main.list.total;
                    $this.list.index = index;
                    $(".pagination").pagination(r.totalCount, $this.list.options);
                })
                .fail(function (r) {
                    $this.fail(r);
                });
        },
        resetSearch: function () {
            this.queryEntity.carInfoId = "";
            this.queryEntity.year = "";
            this.queryEntity.month = "";
            $("#searchCarInfoId").select2().val("").trigger("change");
        }
    }
});



