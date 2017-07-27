Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#applicationForBunkerBFormBody2",
    ready: function () {
        var $this = this;
        $("#editOctaneStoreId").select2()
            .on("change", function (e) {
                abp.services.app.octaneStore.getAmount($("#editOctaneStoreId").val())
                    .done(function (m) {
                        $this.item.totalAmount = m;
                        $this.item.octaneStoreId = $("#editOctaneStoreId").val();
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    }); });            
        $("#edithDriverId").select2()
            .on("change", function (e) {
                $this.item.driverId = $("#edithDriverId").val(); });                
        $("#editCarId").select2()
            .on("change", function (e) {
                $this.item.carInfoId = $("#editCarId").val(); });            
        var datePickerDate = $('#datePickerDate').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerDate.hide();
            $this.item.date = $("#datePickerDate").val();
        })
        .on('hide', function (event) {
		        event.preventDefault();
		        event.stopPropagation();
	    })
        .data('datepicker');
    },
    data: function () {
        return {
            item: {
                id: "",            
                code: "",
                octaneStoreId: "",
                carInfoId: "",
                amount: 0,
                totalAmount: 0,
                auditingAmount: 0,
                driverId: "",
                auditorId: "",
                date: "",
                status: 0,
                note:""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            if ($this.item.totalAmount < $this.item.amount) {
                taf.notify.danger("结余量不足");
            }else {
                abp.services.app.applicationForBunkerB.saveAsync($this.item)
                    .done(function (m) {
                        $this.done(closeModal);
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.applicationForBunkerB.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#editOctaneStoreId").select2().val($this.item.octaneStoreId).trigger("change");
                    $("#editCarId").select2().val($this.item.carInfoId).trigger("change");
                    $("#edithDriverId").select2().val($this.item.driverId).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.code= "";
            this.item.oilCardId= "";
            $("#searchOctaneStoreId").select2().val("").trigger("change");
            this.item.amount= 0;
            this.item.totalAmount= 0;
            this.item.auditingAmount= 0;
            this.item.driverId= "";
            $("#searchDriverId").select2().val("").trigger("change");
            this.item.auditorId= "";
            this.item.date= "";
            this.item.status = 0;
            this.item.note=""
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchOctaneStoreId").select2().on("change", function (e) { main.queryEntity.octaneStoreId = $("#searchOctaneStoreId").val(); });
        $("#searchDriverId").select2().on("change", function (e) { main.queryEntity.driverId = $("#searchDriverId").val(); });
        $("#searchStatus").select2().on("change", function (e) { main.queryEntity.status = $("#searchStatus").val(); });

        var dateFrom = $('#dateFrom').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            dateFrom.hide();
            main.queryEntity.dateFrom = $("#dateFrom").val();
        }).data('datepicker');
        var dateTo = $('#dateTo').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            dateTo.hide();
            main.queryEntity.dateTo = $("#dateTo").val();
        }).data('datepicker');
    },
    data: {
        queryEntity: {
            code:"", 
            octaneStoreId:"", 
            driverId:"", 
            dateFrom:"", 
            dateTo: "",
            status:""
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.code="";
            this.queryEntity.octaneStoreId="";
            this.queryEntity.driverId="";
            this.queryEntity.dateFrom=""; 
            this.queryEntity.dateTo="";
            $("#searchOctaneStoreId").select2().val("").trigger("change");
            $("#searchDriverId").select2().val("").trigger("change");
            $("#searchStatus").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.applicationForBunkerB.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.applicationForBunkerB.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    }
});

main.query(0);



