var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        $("#editPlanId").select2()
            .on("change", function (e) {
                $this.item.planId = $("#editPlanId").val(); 
        });            
        var datePickerDate1 = $('#datePickerDate1').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerDate1.hide();
            $this.item.date1 = $("#datePickerDate1").val();
        })
        .on('hide', function (event) {
		        event.preventDefault();
		        event.stopPropagation();
	    })
        .data('datepicker');
        var datePickerDate2 = $('#datePickerDate2').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerDate2.hide();
            $this.item.date2 = $("#datePickerDate2").val();
        })
        .on('hide', function (event) {
		        event.preventDefault();
		        event.stopPropagation();
	    })
        .data('datepicker');
    },
    data: {
        queryEntity: {
            code:"", 
            name:""
        },
        queryEntity2: {
            text: "",
            type: "ProcessCost",
            principalKey: "",
        },
        queryEntity3: {
            text: "",
            type: "ProcessCost",
            principalKey: "",
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
            date1:"", 
            date2:"", 
            hasPrint:0
        },
        item2: {
            price1:0,
            price2:0,
            price3:0
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
                items_per_page: taf.defatulPageSize, //每页显示1项  
                callback: function(index, jq) {
                    main.list2.from = main.list2.total === 0 ? 0 : main.list2.pageSize * index + 1;
                    main.list2.index = index;
                    main.list2.to = main.list2.pageSize * (index + 1) < main.list2.total
                        ? main.list2.pageSize * (index + 1)
                        : main.list2.total;
                    main.queryEntity2.skipCount = taf.defatulPageSize * index;
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
                items_per_page: taf.defatulPageSize, //每页显示1项  
                callback: function(index, jq) {
                    main.list3.from = main.list3.total === 0 ? 0 : main.list3.pageSize * index + 1;
                    main.list3.index = index;
                    main.list3.to = main.list3.pageSize * (index + 1) < main.list3.total
                        ? main.list3.pageSize * (index + 1)
                        : main.list3.total;
                    main.queryEntity3.skipCount = taf.defatulPageSize * index;
                }
            }
        },
        list4: []
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteProjectManagementDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.projectManagement.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteProjectManagementDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyProjectManagementDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.projectManagement.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#editPlanId").select2().val($this.item.planId).trigger("change");
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
            abp.services.app.projectManagement.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyProjectManagementDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        saveNew:function() {
            var $this = this;
            abp.services.app.projectManagement.saveAsync($this.item)
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
            this.item.planId= "";
            $("#editPlanId").select2().val("").trigger("change");
            this.item.date1= "";
            this.item.date2= "";
            this.item.price= 0;
            this.item.hasPrint= 0;
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.projectManagement.getAll($this.queryEntity)
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
        query2: function(index) {
            var $this = this;
            $this.queryEntity2.skipCount = taf.defatulPageSize * index;
            abp.services.app.actualOutlay.loadUnLinkOutlays($this.queryEntity2)
                .done(function(r) {
                    $this.list2.items = r.items;
                    $this.list2.total = r.totalCount;
                    $this.list2.from = $this.list2.total === 0 ? 0 : $this.list2.pageSize * index + 1;
                    $this.list2.index = index;
                    $this.list2.to = $this.list2.pageSize * (index + 1) < $this.list2.total
                        ? $this.list2.pageSize * (index + 1)
                        : $this.list2.total;
                    $this.list2.index = index;
                    $("#container2").pagination(r.totalCount, $this.list2.options);
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        },
        query3: function(index) {
            var $this = this;
            $this.queryEntity3.skipCount = taf.defatulPageSize * index;
            $this.queryEntity3.principalKey = $this.item.id;

            abp.services.app.actualOutlay.loadLinkedOutlays($this.queryEntity3)
                .done(function(r) {
                    $this.list3.items = r.items;
                    $this.list3.total = r.totalCount;
                    $this.list3.from = $this.list3.total === 0 ? 0 : $this.list3.pageSize * index + 1;
                    $this.list3.index = index;
                    $this.list3.to = $this.list3.pageSize * (index + 1) < $this.list3.total
                        ? $this.list3.pageSize * (index + 1)
                        : $this.list3.total;
                    $this.list3.index = index;
                    $("#container3").pagination(r.totalCount, $this.list3.options);
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        },
        resetSearch: function () {
                this.queryEntity.code="";
                this.queryEntity.name=""; 
        },
        showOutlayDialog: function(name, id) {
            var $this = this;
            $this.modifyEntity.modifyTitle = name;
            $("#updateOutlayDialog").modal("show");
            abp.services.app.projectManagement.get(id)
                .done(function(m) {
                    $this.item = m;

                    abp.services.app.projectManagement.computePrice(id)
                        .done(function(r) {
                            $this.item2 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                    $this.query2(0);
                    $this.query3(0,id);
                })
                .fail(function(m) {
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
        link:function(r) {
            var $this = this;
            console.log(r.amount,$this.item.hasPrint,$this.item2.price2,"eeee");
            if (r.amount > $this.item2.price2 && $this.item.hasPrint < 3) {
                taf.notify.danger("付款总额不能超过未付款进度")
            } else {
                abp.services.app.relationship.add({ principalKey: $this.item.id,foreignKey:r.id,type:"ProcessCost"})
                    .done(function (m) {
                        abp.services.app.projectManagement.computePrice($this.item.id)
                            .done(function(m) {
                                $this.item2 = m;
                                $this.query2(0);
                                $this.query3(0);
                            })
                            .fail(function(m) {
                                $this.fail(m);
                            });
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }
        },
        unlink:function(id) {
            var $this = this;
            abp.services.app.relationship.removeForeignKey(id)
                .done(function (m) {
                    abp.services.app.projectManagement.computePrice($this.item.id)
                        .done(function(m) {
                            $this.item2 = m;
                            $this.query2(0);
                            $this.query3(0);
                        })
                        .fail(function(m) {
                            $this.fail(m);
                        });
                })
                .fail(function (m) {
                    $this.fail(m);
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
