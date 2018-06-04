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
          
        $("#searchUser").select2()
            .on("change", function (e) {
                $this.queryEntity.user = $("#searchUser").val(); 
        });  

        $("#searchMode").select2()
            .on("change", function (e) {
                $this.queryEntity.mode = $("#searchMode").val(); 
        });  
        $("#searchType").select2()
            .on("change", function (e) {
                $this.queryEntity.mode = $("#searchType").val(); 
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
            type:""
        },
        queryEntity3: {
            name:"",
            pid:null,
            maxResultCount: 5,//每页条数
            skipCount: 0,//过滤条数
            sorting: '',
            type:""
        },
        list: {
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: taf.defatulPageSize, //每页显示1项  
                callback: function (index, jq) {
                    console.log(123);
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
            type:"",
        }
    },
    methods: {
        showLinkDialog: function (id,type) {
            var $this = this;
            $this.queryEntity3.pid = id;
            $this.queryEntity3.type = type;
            $("#linkOutlaysDialog").modal("show");
            $this.query3(0);
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
        resetSearch: function () {
                this.queryEntity.category="";
                this.queryEntity.mode="";
                this.queryEntity.code="";
                this.queryEntity.type="";
                this.queryEntity.name="";
                this.queryEntity.date="";
                this.queryEntity.department="";
                this.queryEntity.user="";
                $("#searchDepartment").select2().val("").trigger("change");
                $("#searchUser").select2().val("").trigger("change");
                $("#searchType").select2().val("").trigger("change");
                $("#searchMode").select2().val("").trigger("change");
                $("#searchCategory").select2().val("").trigger("change");
        },
        exportXls: function() {
            taf.download("/ProcurementPlan/DownloadPlan");
        },
        exportDoc: function() {
            taf.download("/ProcurementPlan/DownloadReport");
        }
    }
});



