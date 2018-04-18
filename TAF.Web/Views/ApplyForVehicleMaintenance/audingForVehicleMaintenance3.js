var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    data: {
        queryEntity: { status: 3 },
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
                            main.fail(r);
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
            status: "",
            repairType:""
        },
        manHour: [],
        manHourItem: {
            partName:"",
            manHourName:"",
            manHourValue:0,
            hours1:0,
            hours2:0,
            id:""
        },
        materials: [],
        materialItem: {
            partName: "",
            materialName: "",
            materialValue: 0,
            amount1: 0,
            amount2: 0,
            id: ""
        },
        deliveries: [],
        balance:0,
        total: 0,
        showItem:false
    },
    computed: {
        total:function() {
            var result=0;
            _.forEach(this.manHour, function (value) {
                result += value.hours2 * value.manHourValue;
            });

            _.forEach(this.materials, function (value) {
                result += value.materialValue * value.amount2;
            });

            _.forEach(this.deliveries, function (value) {
                result += value.amount * value.price;
            });
            return result;
        }
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
                    if ($this.item.repairType !== undefined && $this.item.repairType!==null) {
                        abp.services.app.repairCost.getBalance($this.item.repairType)
                            .done(function (m) {
                                $this.balance = m;
                                abp.services.app.applyForVehicleMaintenance.getClosingItem(id)
                                    .done(function (m) {
                                        $this.manHour = m.manHour;
                                        $this.materials = m.materials;
                                        $this.deliveries = m.deliveries;
                                    })
                                    .fail(function (m) {
                                        $this.fail(m);
                                    });
                            })
                            .fail(function (m) {
                                $this.fail(m);
                            });
                    }
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        updateIndex: function () {
            var $this = this;
            abp.services.app.applyForVehicleMaintenance.saveNote3({ key: $this.item.id, value: $this.item.note3, item3:$this.item.repairType})
                .done(function (m) {
                    abp.services.app.applyForVehicleMaintenance.get($this.item.id)
                        .done(function (m) {
                            $this.item = m;
                            abp.services.app.repairCost.getBalance($this.item.repairType)
                                .done(function (m) {
                                    $this.balance = m;
                                })
                                .fail(function (m) {
                                    $this.fail(m);
                                });
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

        loadBalance:function() {
            abp.services.app.deliveryBill.getSimpleList($this.queryEntity)
                .done(function (m) {
                    $this.balance = m;
                })
                .fail(function (m) {
                    $this.fail(m);
                });

        },
        showManHourDialog:function(item){
			this.manHourItem.partName=item.partName;
			this.manHourItem.manHourName=item.manHourName;
			this.manHourItem.manHourValue=item.manHourValue;
			this.manHourItem.hours1=item.hours1;
			this.manHourItem.hours2=item.hours2;
			this.manHourItem.rowId=item.rowId;
			$("#modifyManHourDialog").modal("show");
        },
        updateManHour:function(){
    	 	var obj = this.manHour.filter(v => v.rowId === this.manHourItem.rowId )[0];
			obj.hours2=this.manHourItem.hours2;
			$("#modifyManHourDialog").modal("hide");
        },
        showMaterialDialog:function(item){
            console.log(item,123);
			this.materialItem.partName=item.partName;
			this.materialItem.materialName=item.materialName;
			this.materialItem.materialValue=item.materialValue;
			this.materialItem.amount1=item.amount1;
			this.materialItem.amount2=item.amount2;
			this.materialItem.rowId=item.rowId;
			$("#modifyMaterialDialog").modal("show");
        },
        updateMaterial:function(){
    	 	var obj = this.materials.filter(v => v.rowId === this.materialItem.rowId )[0];
			obj.amount2=this.materialItem.amount2;
			$("#modifyMaterialDialog").modal("hide");
        },
        audit: function () {
            var $this = this;
            if (this.total > this.danger) {
                taf.notify.success("当前修别余额不足!");
            } else {
                abp.services.app.applyForVehicleMaintenance.update2({
                        id: this.item.id,
                        total: this.total,
                        manHour: this.manHour,
                        deliveries: this.deliveries,
                        materials: this.materials
                    })
                    .done(function(m) {
                        taf.notify.success("送修结算单提交成功!");
                        $this.item = {
                            killomiters: 0,
                            note:"",
                            note2:"",
                            note3:"",
                            driverId:"00000000-0000-0000-0000-000000000000",
                            carInfoId:"00000000-0000-0000-0000-000000000000",
                            code:"",
                            status:"",
                            repairType: ""
                        };
                        $this.manHour = [];
                        $this.materials = [];
                        $this.deliveries = [];
                        $this.total = 0;
                        $this.showItem=false;
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }
        }
    }
});



