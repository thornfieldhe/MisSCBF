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
        $("#searchDriverId").select2()
            .on("change", function (e) {
                $this.queryEntity.driverId = $("#searchDriverId").val(); 
            });

        $("#searchStatus").select2()
            .on("change", function (e) {
                $this.queryEntity.status = $("#searchStatus").val(); 
            });   
         
        $("#searchServiceDepotId").select2()
            .on("change", function (e) {
                $this.queryEntity.serviceDepotId = $("#searchServiceDepotId").val(); 
            });  
        $("#editCarInfoId").select2()
            .on("change", function (e) {
                $this.item.carInfoId = $("#editCarInfoId").val(); 
            });  
        $("#editDriverId").select2()
            .on("change", function (e) {
                $this.item.driverId = $("#editDriverId").val(); 
        });  
        $("#editServiceDepotId").select2()
            .on("change", function (e) {
                $this.item.serviceDepotId = $("#editServiceDepotId").val(); 
        });           
    },
    data: {
        queryEntity: {
            carInfoId:"",
            driverId:"",
            status:"",
            serviceDepotId:""
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
                    abp.services.app.applyForVehicleMaintenance.getAll(main.queryEntity)
                        .done(function (r) {
                            main.list.items = r.items;
                            main.list.total = r.totalCount;

                        })
                        .fail(function (r) {
                            $this.fail(r);
                        });
                }
            }
        },
        item: {
            killomiters: 0,
            note: "",
            driverId: "00000000-0000-0000-0000-000000000000",
            carInfoId: "00000000-0000-0000-0000-000000000000",
            code: "",
            status:"",
            serviceDepotId:""
        }
    },
    methods: {
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyApplyForVehicleMaintenanceDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.applyForVehicleMaintenance.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editCarInfoId").select2().val($this.item.carInfoId).trigger("change");
                        $("#editDriverId").select2().val($this.item.driverId).trigger("change");
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }else {
                $this.clear();
            }
        },
        save:function() {
            var $this = this;
            abp.services.app.applyForVehicleMaintenance.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyApplyForVehicleMaintenanceDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        saveNew:function() {
            var $this = this;
            abp.services.app.applyForVehicleMaintenance.saveAsync($this.item)
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
            this.item.carInfoId= "00000000-0000-0000-0000-000000000000";
            $("#editCarInfoId").select2().val("").trigger("change");
            this.item.killomiters= 0;
            this.item.driverId= "00000000-0000-0000-0000-000000000000";
            $("#editDriverId").select2().val("").trigger("change");
            this.item.note= "";
            this.item.status= 0;

        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.applyForVehicleMaintenance.getAll($this.queryEntity)
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
            this.queryEntity.driverId = "";
            this.queryEntity.status = "";
            this.queryEntity.code = "";
            this.queryEntity.serviceDepotId = "";
            $("#searchStatus").select2().val("").trigger("change");
            $("#searchCarInfoId").select2().val("").trigger("change");
            $("#searchDriverId").select2().val("").trigger("change");
            $("#searchServiceDepotId").select2().val("").trigger("change");
        }
    }
});



