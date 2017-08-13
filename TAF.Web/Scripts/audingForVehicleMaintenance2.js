var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function() {
        var $this = this;
        $("body").bind("mousedown",
            function(event) {
                if (!(event.target.id === "menuBtn" ||
                    event.target.id === "menuContent" ||
                    $(event.target).parents("#menuContent").length > 0 ||
                    $(event.target).parents("#menuContent2").length > 0)) {
                    $("#menuContent").hide();
                    $("#menuContent2").hide();
                }
            });
        $("#editManHours").select2()
            .on("change",
                function(e) {
                    $this.manHour.item.manHourId = $("#editManHours").val();
                });
        $("#editMaterial").select2()
            .on("change",
                function(e) {
                    $this.materials.item.materialId = $("#editMaterial").val();
                });

        this.loadList();
    },
    data: {
        queryEntity: { status: 2 },
        list: {
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: 1, //每页显示1项  
                callback: function(index, jq) {
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total
                        ? main.list.pageSize * (index + 1)
                        : main.list.total;
                    main.queryEntity.skipCount = taf.defatulPageSize * index;
                    abp.services.app.applyForVehicleMaintenance.getAll(main.queryEntity)
                        .done(function(r) {
                            main.list.items = r.items;
                            main.list.total = r.totalCount;

                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                }
            }
        },
        item: {
            killomiters: 0,
            note: "",
            note2: "",
            note3: "",
            driverId: "00000000-0000-0000-0000-000000000000",
            carInfoId: "00000000-0000-0000-0000-000000000000",
            code: "",
            status: ""
        },
        showItem: false,
        list2: {},
        list3: {},
        list4: {},
        manHour: {
            item: {
                manHourValue: 0,
                manHourName: '',
                manHourId: '',
                partName: '',
                partId: '',
                hours1: 0,
                id: 0,
                addState: true
            },
            title: '',
            tree: {},
            list: [],
            dicManHours: [],
            
        },
        materials: {
            item: {
                id: 0,
                partName: '',
                partId: '',
                materialId: '',
                materialName: '',
                materialValue: 0,
                amount1: 0,
                addState: true
            },
            title: '',
            list: [],
            dicMaterials: []
            
        },
        index: 0
    },
    methods: {
        query: function(index) {
            var $this = this;
            abp.services.app.applyForVehicleMaintenance.getAuditedItems($this.queryEntity)
                .done(function(m) {
                    $this.list.items = m.items;
                    $this.list.total = m.totalCount;
                    $this.list.from = $this.list.total === 0 ? 0 : $this.list.pageSize * index + 1;
                    $this.list.to = $this.list.pageSize * (index + 1) < $this.list.total ? $this.list.pageSize * (index + 1) : $this.list.total;
                    $(".pagination").pagination(m.totalCount, $this.list.options);
                    $("#chooseAuditingItem").modal("show");
                })
                .fail(function(m) {
                    $this.fail(m);
                });
        },
        select: function (id) {
            var $this = this;
            abp.services.app.applyForVehicleMaintenance.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#chooseAuditingItem").modal("hide");
                    $this.showItem = true;
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        updateIndex: function () {
            var $this = this;
            abp.services.app.applyForVehicleMaintenance.saveNote3({key:$this.item.id,value:$this.item.note3})
                .done(function (m) {
                    abp.services.app.applyForVehicleMaintenance.get($this.item.id)
                        .done(function (m) {
                            $this.item = m;
                            $("#modifyApplyForVehicleMaintenanceNote3Dialog").modal("hide");
                        })
                        .fail(function (m) {
                            $this.fail(m);
                        });
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showDialog:function() {
            $("#modifyApplyForVehicleMaintenanceNote3Dialog").modal("show");
        },
        showManHourDialog: function (title,id) {
            this.manHour.title = title;
            console.log(title, id);
            if (id !== undefined) {
                var obj = this.manHour.list[0];
                console.log(obj,111);
                this.manHour.item = {
                    id: obj.id,
                    manHourValue: obj.manHourValue,
                    manHourName: obj.manHourName,
                    manHourId: obj.manHourId,
                    hours1: obj.hours1,
                    partName: obj.partName,
                    partId: obj.partId,
                    addState: false
                };
                $("#editManHours").select2().val(this.manHour.item.manHourId).trigger("change");
            } else {
                this.index++;
                this.manHour.item = {
                    manHourValue: 0,
                    manHourName: '',
                    manHourId: '',
                    partName: '',
                    partId: '',
                    hours1: 0,
                    id: this.index,
                    addState: true
                };
                $("#editManHours").select2().val("").trigger("change");
            }
            this.loadTree();
            $("#modifyManHourDialog").modal("show");
            
        },
        showMaterialDialog: function (title,id) {
            this.materials.title = title;
            console.log(title,id);
            
            if (id !== undefined) {
                var obj = this.materials.list[id];
                this.materials.item = {
                    id: obj.id,
                    materialName: obj.materialName,
                    materialId: obj.materialId,
                    materialValue: obj.materialValue,
                    amount1: obj.amount1,
                    partName: obj.partName,
                    partId: obj.partId,
                    addState: false
                };
                $("#editMaterial").select2().val(this.materials.item.materialId).trigger("change");
            } else {
                this.index++;
                this.materials.item = {
                    id: this.index,
                    partName: '',
                    partId: '',
                    materialId: '',
                    materialName: '',
                    materialValue: 0,
                    amount1: 0,
                    addState: true
                };
                $("#editMaterial").select2().val("").trigger("change");
            }
            this.loadTree2();
            $("#modifyMaterialDialog").modal("show");
        },
        showDeleteManHourDialog: function (title,index) {
            this.manHour.title = title;
            this.manHour.item.index = index;
            $("#deleteManHourDialog").modal("show");
        },
        showDeleteMaterialDialog: function (title,index) {
            this.materials.title = title;
            this.materials.item.index = index;
            $("#deleteMaterialDialog").modal("show");
        },
        addManHour: function () {
            this.manHour.item.id = this.index;
            var id = this.manHour.item.manHourId;
            this.manHour.item.manHourValue = parseFloat(_.find(this.manHour.dicManHours, function (o) { return o.id === id }).value3);
            this.manHour.item.manHourName = _.find(this.manHour.dicManHours, function (o) { return o.id === id }).value;
            this.manHour.item.hours1 = parseFloat(this.manHour.item.hours1);
            this.manHour.list.push({
                hours1: this.manHour.item.hours1, id: this.manHour.item.id, manHourId: this.manHour.item.manHourId, manHourValue: this.manHour.item.manHourValue,
                manHourName: this.manHour.item.manHourName, partId: this.manHour.item.partId, partName: this.manHour.item.partName
            });
            this.manHour.item = {
                manHourValue: 0,
                manHourName: '',
                manHourId: '',
                partName: '',
                partId: '',
                hours1: 0,
                id: 0,
                addState: true};
            $("#modifyManHourDialog").modal("hide");
        },
        addMaterial: function () {
            this.materials.item.id = this.index;
            var id = this.materials.item.materialId;
            this.materials.item.materialValue = parseFloat(_.find(this.materials.dicMaterials, function (o) { return o.id === id }).value3);
            this.materials.item.materialName = _.find(this.materials.dicMaterials, function (o) { return o.id === id }).value;
            this.materials.item.amount1 = parseFloat(this.materials.item.amount1);
            this.materials.list.push({
                amount1: this.materials.item.amount1, id: this.materials.item.id, materialId: this.materials.item.materialId, materialValue: this.materials.item.materialValue,
                materialName: this.materials.item.materialName, partId: this.materials.item.partId, partName: this.materials.item.partName
            });
            this.manHour.item = {};
            $("#modifyMaterialDialog").modal("hide");
        },
        updateManHour: function () {
            var obj = this.manHour.list.filter(v => v.id === this.manHour.item.id )[0];
            var id = this.manHour.item.manHourId;
            obj.manHourId = this.manHour.item.manHourId;
            obj.partName = this.manHour.item.partName;
            obj.partId = this.manHour.item.partId;
            obj.manHourValue = parseFloat(_.find(this.manHour.dicManHours, function (o) { return o.id === id  }).value3);
            obj.manHourName = _.find(this.manHour.dicManHours, function (o) { return o.id === id }).value;
            obj.hours1 = parseFloat(this.manHour.item.hours1);
            this.manHour.item = {
                manHourValue: 0,
                manHourName: '',
                manHourId: '',
                partName: '',
                partId: '',
                hours1: 0,
                id: 0,
                addState: true
            };
            $("#modifyManHourDialog").modal("hide");
        },
        updateMaterial: function () {
            var obj = this.materials.list.filter(v => v.id === this.materials.item.id)[0];
                var id = this.materials.item.materialId;
                obj.materialId = this.materials.item.materialId;
                obj.partName = this.materials.item.partName;
                obj.partId = this.materials.item.partId;
                obj.materialValue = parseFloat(_.find(this.materials.dicMaterials, function (o) { return o.id === id }).value3);
                obj.materialName = _.find(this.materials.dicMaterials, function (o) { return o.id === id }).value;
                obj.amount1 = parseFloat(this.materials.item.amount1);
            this.materials.item = {
                    id: 0,
                    partName: '',
                    partId: '',
                    materialId: '',
                    materialName: '',
                    materialValue: 0,
                    amount1: 0,
                    addState: true};

            $("#modifyMaterialDialog").modal("hide");
        },
        loadTree: function () {
            var $this = this;
            abp.services.app.layer.getAllByCategory('Car_MaintenanceParts')
                .done(function (m) {
                    $this.manHour.tree = $.fn.zTree.init($("#treePart"), {
                        data: {
                            simpleData: {
                                enable: true
                            }
                        },
                        callback: {
                            onClick: function (event, treeId, treeNode, clickFlag) {
                                $this.manHour.item.partName = treeNode.name;
                                $this.manHour.item.partId = treeNode.id;
                                console.log(treeNode,123);
                                
                                $("#menuContent").hide();
                            }
                        }
                    }, m);
                    $this.manHour.tree.expandAll(true);
                    $("#menuContent").slideDown("fast");
                });

        },
        loadTree2: function () {
            var $this = this;
            abp.services.app.layer.getAllByCategory('Car_MaintenanceParts')
                .done(function (m) {
                    $this.materials.tree = $.fn.zTree.init($("#treePart2"), {
                        data: {
                            simpleData: {
                                enable: true
                            }
                        },
                        callback: {
                            onClick: function (event, treeId, treeNode, clickFlag) {
                                $this.materials.item.partName = treeNode.name;
                                $this.materials.item.partId = treeNode.id;
                                $("#menuContent2").hide();
                            }
                        }
                    }, m);
                    $this.materials.tree.expandAll(true);
                    $("#menuContent2").slideDown("fast");
                });

        },
        loadList: function () {
            var $this = this;
            abp.services.app.sysDictionary.getSimpleList('Car_ManHours')
                .done(function(m) {
                    $this.manHour.dicManHours = m;
                });
            abp.services.app.sysDictionary.getSimpleList('Car_ServicingMaterials')
                .done(function (m) {
                    $this.materials.dicMaterials = m;
                });
        },
        deleteManHour:function(index) {
            this.manHour.list.splice(index, 1);
            $("#deleteManHourDialog").modal("hide");
        },
        deleteMaterial:function(index) {
            this.materials.list.splice(index, 1);
            $("#deleteMaterialDialog").modal("hide");
        }
    }
});



