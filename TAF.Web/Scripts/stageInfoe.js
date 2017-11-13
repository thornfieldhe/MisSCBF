var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        $("#searchCompany").select2()
            .on("change", function (e) {
                $this.queryEntity.company = $("#searchCompany").val(); 
        });  
        $("#editCompany").select2()
            .on("change", function (e) {
                $this.item.company = $("#editCompany").val(); 
        });            
        $("#searchProcurementPlanId").select2()
            .on("change", function (e) {
                $this.queryEntity.procurementPlanId = $("#searchProcurementPlanId").val(); 
        });  
        $("#editProcurementPlanId").select2()
            .on("change", function (e) {
                $this.item.procurementPlanId = $("#editProcurementPlanId").val(); 
        });            
    },
    data: {
        queryEntity: {
            company:"00000000-0000-0000-0000-000000000000",
            procurementPlanId:"00000000-0000-0000-0000-000000000000",
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
            category:0,
            company:"00000000-0000-0000-0000-000000000000",
            cost:0,
            status:0,
            procurementPlanId:"00000000-0000-0000-0000-000000000000",
        }
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteStageInfoeDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.stageInfoe.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteStageInfoeDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyStageInfoeDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.stageInfoe.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editCompany").select2().val($this.item.company).trigger("change");
                        $("#editProcurementPlanId").select2().val($this.item.procurementPlanId).trigger("change");
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }else {
                $this.modifyEntity.editModel = false;
                $this.clear();
            }
        },
        save:function() {
            var $this = this;
            abp.services.app.stageInfoe.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyStageInfoeDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        saveNew:function() {
            var $this = this;
            abp.services.app.stageInfoe.saveAsync($this.item)
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
            this.item.category= 0;
            this.item.company= "00000000-0000-0000-0000-000000000000";
            $("#editCompany").select2().val("").trigger("change");
            this.item.cost= 0;
            this.item.status= 0;
            this.item.procurementPlanId= "00000000-0000-0000-0000-000000000000";
            $("#editProcurementPlanId").select2().val("").trigger("change");
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.stageInfoe.getAll($this.queryEntity)
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
                this.queryEntity.category="";
                this.queryEntity.company="";
                this.queryEntity.cost="";
                this.queryEntity.status="";
                this.queryEntity.procurementPlanId="";
                $("#searchCompany").select2().val("").trigger("change");
                $("#searchProcurementPlanId").select2().val("").trigger("change");
        }
    }
});



