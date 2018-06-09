var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function() {
        var $this = this;
        $this.query(0);
        $("#searchUnit").select2()
            .on("change",
                function(e) {
                    $this.queryEntity.unit = $("#searchUnit").val();
                });
        $("#editUnit").select2()
            .on("change",
                function(e) {
                    $this.item.unit = $("#editUnit").val();
                });
        $("#editPurchaseId").select2()
            .on("change",
                function(e) {
                    $this.item.purchaseId = $("#editPurchaseId").val();
                });
        $("#searchProject").select2()
            .on("change",
                function(e) {
                    $this.queryEntity.procurementPlanId = $("#searchProject").val();
                });
    },
    data: {
        queryEntity: {
            procurementPlanId: "",
            type: "Purchase_ConstructionControlUnit",
            unit: "",
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
                callback: function(index, jq) {
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total
                        ? main.list.pageSize * (index + 1)
                        : main.list.total;
                    main.queryEntity.skipCount = taf.defatulPageSize * index;
                }
            }
        },
        item: {
            id: "",
            type: "Purchase_ConstructionControlUnit",
            price: 0,
            status: 0,
            users: [],
            unit: "",
            unitName: "",
            purchaseId: "",
            schedule: 0
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
        showDeleteDialog: function(id, name) {
            var $this = this;
            $("#deleteProcessManagementDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function(id) {
            var $this = this;
            abp.services.app.processManagement.delete(id)
                .done(function(m) {
                    $this.query(0);
                    $("#deleteProcessManagementDialog").modal("hide");
                })
                .fail(function(m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function(name, id) {
            var $this = this;
            $("#modifyProcessManagementDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !== null) {
                abp.services.app.processManagement.get(id)
                    .done(function(m) {
                        $this.item = m;
                        $("#editUnit").select2().val($this.item.unit).trigger("change");
                        $("#editPurchaseId").select2().val($this.item.purchaseId).trigger("change");
                    })
                    .fail(function(m) {
                        $this.fail(m);
                    });
            } else {
                $this.modifyEntity.editModel = false;
                $this.clear();
            }
        },
        showOutlayDialog: function(name, id) {
            var $this = this;
            $this.modifyEntity.modifyTitle = name;
            $("#updateOutlayDialog").modal("show");
            abp.services.app.processManagement.get(id)
                .done(function(m) {
                    $this.item = m;
                    $this.query2(0);
                    $this.query3(0);
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
        savePrice: function() {
            var $this = this;
            abp.services.app.processManagement.savePrice({ key: $this.item.id, value: $this.item.price })
                .done(function(m) {
                    $this.item = m;
                })
                .fail(function(m) {
                    $this.fail(m);
                });
        },
        save: function() {
            var $this = this;
            abp.services.app.processManagement.saveAsync($this.item)
                .done(function(m) {
                    $this.query(0);
                    $("#modifyProcessManagementDialog").modal("hide");
                })
                .fail(function(m) {
                    $this.fail(m);
                });
        },
        print: function() {
            var $this = this;

            abp.services.app.processManagement.saveAsync($this.item)
                .done(function(m) {

                    var url = "/ProcessManagement/Print/" + m;
                    taf.download(url);
                    $this.query(0);
                    $("#modifyProcessManagementDialog").modal("hide");
                })
                .fail(function(m) {
                    $this.fail(m);
                });

        },
        clear: function() {
            this.item.id = "";
            this.item.users = [];
            this.item.price = 0;
            this.item.unit = "";
            this.item.unitName = "";
            this.item.purchaseId = "";
            $("#editUnit").select2().val("").trigger("change");
            $("#editPurchaseId").select2().val("").trigger("change");
        },
        query: function(index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.processManagement.getAll($this.queryEntity)
                .done(function(r) {
                    $this.list.items = r.items;
                    $this.list.total = r.totalCount;
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total
                        ? main.list.pageSize * (index + 1)
                        : main.list.total;
                    $this.list.index = index;
                    $(".pagination").pagination(r.totalCount, $this.list.options);
                })
                .fail(function(r) {
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
        resetSearch: function() {
            this.queryEntity.unit = "";
            this.queryEntity.procurementPlanId = "";
            $("#searchUnit").select2().val("").trigger("change");
            $("#searchProject").select2().val("").trigger("change");
        },
        resetSearch2: function () {
            this.queryEntity2.text="";
        },
        getUnit: function() {
            var $this = this;
            abp.services.app.unitPool.getRandomItem("Purchase_ConstructionControlUnit")
                .done(function(r) {
                    $this.item.unit = r.key;
                    $this.item.unitName = r.value;
                });
        },
        link:function(id) {
            var $this = this;
            abp.services.app.relationship.add({ principalKey: $this.item.id,foreignKey:id,type:"ProcessCost"})
                .done(function (m) {
                    abp.services.app.processManagement.get($this.item.id)
                        .done(function(m) {
                            $this.item = m;
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
        unlink:function(id) {
            var $this = this;
            abp.services.app.relationship.removeForeignKey(id)
                .done(function (m) {
                    abp.services.app.processManagement.get($this.item.id)
                        .done(function(m) {
                            $this.item = m;
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
        removeAttach: function(id) {
            var $this = this;
            abp.services.app.attachment.delete(id)
                .done(function (m) {
                     $this.query4();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
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