var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        $("#searchDepartment").select2()
            .on("change", function (e) {
                $this.queryEntity.department = $("#searchDepartment").val(); 
        });  
        $("#editDepartment").select2()
            .on("change", function (e) {
                $this.item.department = $("#editDepartment").val(); 
        });            
        $("#searchUser").select2()
            .on("change", function (e) {
                $this.queryEntity.user = $("#searchUser").val(); 
        });  
        $("#editUser").select2()
            .on("change", function (e) {
                $this.item.user = $("#editUser").val(); 
        });             
        $("#searchMonth").select2()
            .on("change", function (e) {
                $this.queryEntity.month = $("#searchMonth").val(); 
        });  
        $("#editMonth").select2()
            .on("change", function (e) {
                $this.item.month = $("#editMonth").val(); 
        });             
        $("#searchMode").select2()
            .on("change", function (e) {
                $this.queryEntity.mode = $("#searchMode").val(); 
        });  
        $("#editMode").select2()
            .on("change", function (e) {
                $this.item.mode = $("#editMode").val(); 
        });              
        $("#editCategory").select2()
            .on("change", function (e) {
                $this.item.category = $("#editCategory").val(); 
        });  
        $("#serarchCategory").select2()
            .on("change", function (e) {
                $this.queryEntity.category = $("#serarchCategory").val(); 
        });            
    },
    data: {
        queryEntity: {
            category:"", 
            mode:"", 
            code:"", 
            name:"", 
            year:"", 
            month:"", 
            department:"",
            user:"",
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
            category:"", 
            mode:"", 
            code:"", 
            name:"", 
            year:0,
            month:0,
            department:"",
            user:"",
        }
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteProcurementPlanDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.procurementPlan.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteProcurementPlanDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyProcurementPlanDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.procurementPlan.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editDepartment").select2().val($this.item.department).trigger("change");
                        $("#editUser").select2().val($this.item.user).trigger("change");
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
            abp.services.app.procurementPlan.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyProcurementPlanDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        saveNew:function() {
            var $this = this;
            abp.services.app.procurementPlan.saveAsync($this.item)
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
            this.item.category= "";
            this.item.mode= "";
            this.item.code= "";
            this.item.name= "";
            this.item.year= 0;
            this.item.month= 0;
            this.item.department= "";
            $("#editDepartment").select2().val("").trigger("change");
            this.item.user= "";
            $("#editUser").select2().val("").trigger("change");
            $("#editMode").select2().val("").trigger("change");
            $("#editCategory").select2().val("").trigger("change");
            $("#editMonth").select2().val("").trigger("change");
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.procurementPlan.getAll($this.queryEntity)
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
                this.queryEntity.mode="";
                this.queryEntity.code="";
                this.queryEntity.name="";
                this.queryEntity.year="";
                this.queryEntity.month="";
                this.queryEntity.department="";
                this.queryEntity.user="";
                $("#searchDepartment").select2().val("").trigger("change");
                $("#searchUser").select2().val("").trigger("change");
                $("#searchMonth").select2().val("").trigger("change");
                $("#searchMode").select2().val("").trigger("change");
                $("#searchCategory").select2().val("").trigger("change");
        }
    }
});



