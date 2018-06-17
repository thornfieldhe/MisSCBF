var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        $("#searchbiddingAgency").select2()
            .on("change", function (e) {
                $this.queryEntity.biddingAgencyId = $("#searchbiddingAgency").val(); 
        });  
        $("#searchCategory").select2()
            .on("change", function (e) {
                $this.queryEntity.category = $("#searchCategory").val(); 
        });  
        $("#searchMode").select2()
            .on("change", function (e) {
                $this.queryEntity.mode = $("#searchMode").val(); 
        });  
        $("#editbiddingAgencyId").select2()
            .on("change", function (e) {
                $this.item.biddingAgencyId = $("#editbiddingAgencyId").val(); 
        });   
        $("#editplanId").select2()
            .on("change", function (e) {
                $this.item.planId = $("#editplanId").val(); 
        });  
        var datePickerDate = $('#datePickerDate').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
                datePickerDate.hide();
                $this.item.date = $("#datePickerDate").val();
            })   
            .on('hide', function (event) {
                event.preventDefault();
                event.stopPropagation();
            })
            .data('datepicker');

        var datePickerPlanDateFrom = $('#datePickerPlanDateFrom').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
                datePickerPlanDateFrom.hide();
                $this.item.planDateFrom = $("#datePickerPlanDateFrom").val();
            })   
            .on('hide', function (event) {
                event.preventDefault();
                event.stopPropagation();
            })
            .data('datepicker');

        var datePickerPlanDateTo = $('#datePickerPlanDateTo').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
                datePickerPlanDateTo.hide();
                $this.item.planDateTo = $("#datePickerPlanDateTo").val();
            })   
            .on('hide', function (event) {
                event.preventDefault();
                event.stopPropagation();
            })
            .data('datepicker');

        var datePickerPlanDateEnd = $('#datePickerPlanDateEnd').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
                datePickerPlanDateEnd.hide();
                $this.item.planDateEnd = $("#datePickerPlanDateEnd").val();
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
            biddingAgencyId:""
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
            biddingAgencyId:"",
            date:"", 
            planDateFrom:"", 
            planDateTo:"", 
            planDateEnd:"", 
            total:0 ,
            schedule:0,
            expertName:"", 
            expertId:"", 
            hasPrint:0,
            costList:[],
            tenderers:[]
        },
        list4:[]
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteBiddingManagementDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.biddingManagement.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteBiddingManagementDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyBiddingManagementDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.biddingManagement.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editplanId").select2().val($this.item.planId).trigger("change");
                        $("#editbiddingAgencyId").select2().val($this.item.biddingAgencyId).trigger("change");
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
            abp.services.app.biddingManagement.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                    $("#modifyBiddingManagementDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        clear: function () {
            this.item.id = "";
            $("#editbiddingAgencyId").select2().val("").trigger("change");
            $("#editplanId").select2().val("").trigger("change");
            this.item.planId= "";
            this.item.biddingAgencyId= "";
            this.item.date= "";
            this.item.planDateFrom= "";
            this.item.planDateTo= "";
            this.item.planDateEnd= "";
            this.item.expertName= "";
            this.item.expertId= "";
            this.item.total= 0;
            this.item.schedule= 0;
            this.item.tenderers=[],
            this.item.costList=[],
            this.item.hasPrint = 0;
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.biddingManagement.getAll($this.queryEntity)
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
                this.queryEntity.biddingAgencyId="";
                $("#searchbiddingAgency").select2().val("").trigger("change");
                $("#searchCategory").select2().val("").trigger("change");
                $("#searchMode").select2().val("").trigger("change");
        },
        getExpert: function() {
            var $this = this;
            abp.services.app.unitPool.getRandomItem("Purchase_Expert")
                .done(function(r) {
                    $this.item.expertId = r.key;
                    $this.item.expertName = r.value;
                });
        },
        addDetail: function() {
            var $this = this;
                var details = {
                    id: "",
                    biddingManagementId: $this.item.id,
                    category: "",
                    details: "",
                    unit: "",
                    amount: 0,
                    editStatus: true
                };

                $this.item.costList.push(details);
        },
        deleteItem: function(index) {
            this.item.costList.splice(index,1);
        },
        saveItem: function(item) {
            item.editStatus = false;
        },
        cancelItem: function(item) {
            item.editStatus = false;
        },
        editItem: function(item) {
            item.editStatus = true;
        },
        export: function() {
            var $this = this;
            $this.item.hasPrint=1;
            abp.services.app.biddingManagement.saveAsync($this.item)
                .done(function (m) {
                    var url = "/BiddingManagement/DownloadPlan/" + m;
                    taf.download(url);
                    $("#modifyBiddingManagementDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        addTenderer: function() {
            var $this = this;
            var tenderer = {
                id: "",
                biddingManagementId: $this.item.id,
                name: "",
                editStatus: true
            };

            $this.item.tenderers.push(tenderer);
        },
        deleteTenderer: function(index) {
            this.item.tenderers.splice(index,1);
        },
        saveTenderer: function(item) {
            item.editStatus = false;
        },
        editTenderer: function(item) {
            item.editStatus = true;
        },
        cancelTenderer: function(item) {
            item.editStatus = false;
        },
        showModifyTendererDialog: function (id) {
            var $this = this;
            $("#modifyTendererDialog").modal("show");
            if (id !==null) {
                abp.services.app.biddingManagement.get(id)
                    .done(function (m) {
                        $this.item = m;
                        abp.services.app.tenderer.getAll(id)
                            .done(function(s) {
                                $this.item.tenderers = s;
                            });
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }else {
                $this.modifyEntity.editModel = false;
                $this.clear();
            }
        },
        saveTenderers: function() {
            var $this = this;
            abp.services.app.tenderer.saveAsync($this.item.tenderers)
                .done(function (m) {
                    taf.notify.success("投标单位保存成功");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showAttachmentsDialog: function(name, id) {
            var $this = this;
            $this.modifyEntity.modifyTitle = name;
            $this.item.id = id;
            $("#attachmentsDialog").modal("show");
            $this.query4();

        },
        removeAttach: function(id) {
            var $this = this;
            abp.services.app.attachment.delete(id)
                .done(function (m) {
                    $this.query4();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }, 
        query4: function() {
            var $this = this;

            abp.services.app.attachment.getAll($this.item.id)
                .done(function(r) {
                    $this.list4 = r;
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        },
    }
});


$(".fileUpload").liteUploader({
        script: defaultUrl + "ProcessManagement/Upload?modelId=" + main.item.id
    })
    .on("lu:success", function (e, response) {
        main.query4();
        taf.notify.success("附件上传成功");
    });

$(".fileUpload").change(function () {
    $(".fileUpload").data("liteUploader").options.script= defaultUrl + "ProcessManagement/Upload?modelId=" + main.item.id;
    $(this).data("liteUploader").startUpload();
});


