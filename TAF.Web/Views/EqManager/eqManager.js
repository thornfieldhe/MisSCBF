var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        $("#editPlanId").select2()
            .on("change",
                function(e) {
                    abp.services.app.procurementPlan.getInfo($("#editPlanId").val())
                        .done(function(s) {
                            $this.item = s;
                            $this.item.planId = $("#editPlanId").val();

                        })
                        .fail(function(s) {
                            $this.fail(s);
                        });
                    $this.item.planId = $("#editPlanId").val();
                });
    },
    data: {
        queryEntity: {
            name:"",
            code:""
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
            planId:"",
            unit1:"",
            score1:0,
            unit2:"",
            score2:0,
            unit3:"",
            score3:0,
            unit4:"",
            score4:0,
            unit5:"", 
            score5:0,
            unitName1:"",
            unitName2:"",
            unitName3:"",
            unitName4:"",
        }
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteEqManagerDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.eqManager.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteEqManagerDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyEqManagerDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.eqManager.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editPlanId").select2().val($this.item.planId);
                        
                        
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
            abp.services.app.eqManager.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyEqManagerDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },

        clear: function () {
            this.item.id = "";
            this.item.planId= "";
            $("#editPlanId").select2().val("").trigger("change");
            this.item.unit1= "";
            this.item.score1= 0;
            this.item.unit2= "";
            this.item.score2= 0;
            this.item.unit3= "";
            this.item.score3= 0;
            this.item.unit4= "";
            this.item.score4= 0;
            this.item.unit5= "";
            this.item.score5= 0;
            this.item.unitName1= "";
            this.item.unitName2= "";
            this.item.unitName3= "";
            this.item.unitName4= "";
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.eqManager.getAll($this.queryEntity)
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
                this.queryEntity.name="";
                this.queryEntity.code="";
        }
    }
});



