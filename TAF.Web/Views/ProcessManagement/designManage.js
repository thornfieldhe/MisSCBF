var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        $("#searchUnit").select2()
            .on("change", function (e) {
                $this.queryEntity.unit = $("#searchUnit").val(); 
        });  
        $("#editUnit").select2()
            .on("change", function (e) {
                $this.item.unit = $("#editUnit").val(); 
        }); 
        $("#editPurchaseId").select2()
            .on("change", function (e) {
                $this.item.purchaseId = $("#editPurchaseId").val(); 
        });  
        $("#searchProject").select2()
            .on("change", function (e) {
                $this.queryEntity.procurementPlanId = $("#searchProject").val(); 
        });            
    },
    data: {
        queryEntity: {
            procurementPlanId:"", 
            type:"Purchase_DesignUnit",
            unit:"",
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
            type:"Purchase_DesignUnit", 
            price:0,
            status:0,
            users:[],
            unit:"",
            unitName:"",
            purchaseId:"",
        }
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteProcessManagementDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.processManagement.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteProcessManagementDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyProcessManagementDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.processManagement.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editUnit").select2().val($this.item.unit).trigger("change");
                        $("#editPurchaseId").select2().val($this.item.purchaseId).trigger("change");
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
            abp.services.app.processManagement.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyProcessManagementDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        print:function() {
            var $this = this;

            abp.services.app.processManagement.saveAsync($this.item)
                .done(function (m) {

                    var url = "/ProcessManagement/Print/"+$this.item.id;
                   taf.download(url);
                    $this.query(0);
                    $("#modifyProcessManagementDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
 
        },
        clear: function () {
            this.item.id = "";
            this.item.users = [];
            this.item.price= 0;
            this.item.unit= "";
            this.item.purchaseId= "";
            $("#editUnit").select2().val("").trigger("change");
            $("#editPurchaseId").select2().val("").trigger("change");
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.processManagement.getAll($this.queryEntity)
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
                this.queryEntity.unit="";
                this.queryEntity.procurementPlanId="";
                $("#searchUnit").select2().val("").trigger("change");
                $("#searchProject").select2().val("").trigger("change");
        },
        getUnit: function() {
            var $this = this;
            abp.services.app.unitPool.getRandomItem("Purchase_DesignUnit")
                .done(function(r) {
                    $this.item.unit = r.key;
                    $this.item.unitName = r.value;
                });
        }
    }
});



