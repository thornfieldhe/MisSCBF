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
        $("#searchCategory").select2()
            .on("change", function (e) {
                $this.queryEntity.category = $("#searchCategory").val(); 
        });   
        var datePickerDate = $('#datePickerDate').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
                datePickerDate.hide();
                $this.queryEntity.date = $("#datePickerDate").val();
            })   
            .on('hide', function (event) {
                event.preventDefault();
                event.stopPropagation();
            })
            .data('datepicker');
        var datePickerDate2 = $('#datePickerDate2').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
                datePickerDate2.hide();
                $this.item.date = $("#datePickerDate2").val();
            })
            .on('hide', function (event) {
                event.preventDefault();
                event.stopPropagation();
            })
            .data('datepicker');
    },
    data: {
        queryEntity: {
            category:"", 
            mode:"", 
            code:"", 
            name:"", 
            date:"", 
            department:"",
            user:"",
            type:0
        },
        queryEntity2: {
            name:"",
            pid:null,
            maxResultCount: 5,//每页条数
            skipCount: 0,//过滤条数
            sorting: '',
            type:0
        },
        queryEntity3: {
            name:"",
            pid:null,
            maxResultCount: 5,//每页条数
            skipCount: 0,//过滤条数
            sorting: '',
            type:0
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
                    abp.services.app.procurementPlan.getAll(main.queryEntity)
                        .done(function (r) {
                            main.list.items = r.items;
                            main.list.total = r.totalCount;
                        })
                        .fail(function (r) {
                            main.fail(r);
                        });
                }
            }
        },
        list2: {
            total: 0,
            from: 0,
            to: 0,
            index: 0,
            pageSize: 5,
            items: {},
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: 5, //每页显示1项  
                callback: function (index, jq) {
                    main.list2.from = main.list2.total === 0 ? 0 : main.list2.pageSize * index + 1;
                    main.list2.index = index;
                    main.list2.to = main.list2.pageSize * (index + 1) < main.list2.total ? main.list2.pageSize * (index + 1) : main.list2.total;
                    main.queryEntity2.skipCount = 5 * index;
                    abp.services.app.planWithBudgetOutlay.getUnCorrelatedOutlays(main.queryEntity2)
                        .done(function (r) {
                            main.list2.items = r.items;
                            main.list2.total = r.totalCount;
                        })
                        .fail(function (r) {
                            main.fail(r);
                        });
                }
            }
        },
        list3: {
            total: 0,
            from: 0,
            to: 0,
            index: 0,
            pageSize: 5,
            items: {},
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: 5, //每页显示1项  
                callback: function (index, jq) {
                    main.list3.from = main.list3.total === 0 ? 0 : main.list3.pageSize * index + 1;
                    main.list3.index = index;
                    main.list3.to = main.list3.pageSize * (index + 1) < main.list3.total ? main.list3.pageSize * (index + 1) : main.list3.total;
                    main.queryEntity3.skipCount = 5 * index;
                    abp.services.app.planWithBudgetOutlay.getCorrelatedOutlays(main.queryEntity3)
                        .done(function (r) {
                            main.list3.items = r.items;
                            main.list3.total = r.totalCount;
                        })
                        .fail(function (r) {
                            main.fail(r);
                        });
                }
            }
        },
        item: {
            id : "",
            category:"", 
            mode:"", 
            code:"", 
            name:"", 
            date:"",
            department:"",
            user:"",
            type:0,
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
 
                        $("#editCategory").select2().val($this.item.category).trigger("change");
                        $("#editMode").select2().val($this.item.mode).trigger("change");
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }else {
                $this.modifyEntity.editModel = false;
                $this.clear();
            }
        },
        showLinkDialog: function (name,id) {
            var $this = this;
            $this.queryEntity2.pid = id;
            $this.queryEntity3.pid = id;
            $("#linkOutlaysDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            $this.query2(0);
            $this.query3(0);
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
        link:function(id) {
            var $this = this;
            abp.services.app.planWithBudgetOutlay.saveAsync({ procurementPlanId: $this.queryEntity2.pid,budgetOutlayId:id})
            .done(function (m) {
                $this.query2(0);
                $this.query3(0);
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
            this.item.date= "";

            this.item.department= "";
            $("#editDepartment").select2().val("").trigger("change");
            this.item.user= "";
            $("#editUser").select2().val("").trigger("change");
            $("#editMode").select2().val("").trigger("change");
            $("#editCategory").select2().val("").trigger("change");

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
        query2: function (index) {
            var $this = this;
            $this.queryEntity2.skipCount = taf.defatulPageSize * index;
            abp.services.app.planWithBudgetOutlay.getUnCorrelatedOutlays($this.queryEntity2)
            .done(function (r) {
                $this.list2.items = r.items;
                $this.list2.total = r.totalCount;
                    main.list2.from = main.list2.total === 0 ? 0 : main.list2.pageSize * index + 1;
                    main.list2.index = index;
                    main.list2.to = main.list2.pageSize * (index + 1) < main.list2.total ? main.list2.pageSize * (index + 1) : main.list2.total;
                    $this.list2.index = index;
                    $("#container2").pagination(r.totalCount, $this.list2.options);
            })
            .fail(function (r) {
                $this.fail(r);
            });
        },
        query3: function (index) {
            var $this = this;
            $this.queryEntity3.skipCount = taf.defatulPageSize * index;
            abp.services.app.planWithBudgetOutlay.getCorrelatedOutlays($this.queryEntity3)
            .done(function (r) {
                $this.list3.items = r.items;
                $this.list3.total = r.totalCount;
                    main.list3.from = main.list3.total === 0 ? 0 : main.list3.pageSize * index + 1;
                    main.list3.index = index;
                    main.list3.to = main.list3.pageSize * (index + 1) < main.list3.total ? main.list3.pageSize * (index + 1) : main.list3.total;
                    $this.list3.index = index;
                    $("#container3").pagination(r.totalCount, $this.list3.options);
            })
            .fail(function (r) {
                $this.fail(r);
            });
        },
        remove: function (id) {
            var $this = this;
            abp.services.app.planWithBudgetOutlay.delete(id)
                .done(function (m) {
                    $this.query2(0);
                    $this.query3(0);
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        resetSearch: function () {
                this.queryEntity.category="";
                this.queryEntity.mode="";
                this.queryEntity.code="";
                this.queryEntity.name="";
                this.queryEntity.date="";
                this.queryEntity.department="";
                this.queryEntity.user="";
                $("#searchDepartment").select2().val("").trigger("change");
                $("#searchUser").select2().val("").trigger("change");
 
                $("#searchMode").select2().val("").trigger("change");
                $("#searchCategory").select2().val("").trigger("change");
        },
        resetSearch2: function () {
                this.queryEntity2.name="";
        }
    }
});



