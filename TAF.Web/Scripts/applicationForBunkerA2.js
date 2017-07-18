Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#applicationForBunkerAFormBody2",
    ready: function () {
        var $this = this;
        $("#searchEditOilCardId").select2()
            .on("change", function (e) {
                abp.services.app.oilCard.getAmount($("#searchEditOilCardId").val())
                    .done(function (m) {
                        $this.item.totalAmount = m;
                        $this.item.oilCardId = $("#searchEditOilCardId").val();
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    }); });            
        $("#searchEditDriverId").select2()
            .on("change", function (e) {
                $this.item.driverId = $("#searchEditDriverId").val(); });            
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
                oilCardId: "",
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
                taf.notify.danger("余额不足");
            }else {
                abp.services.app.applicationForBunkerA.saveAsync($this.item)
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
            abp.services.app.applicationForBunkerA.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditOilCardId").select2().val($this.item.oilCardId).trigger("change");
                    $("#searchEditDriverId").select2().val($this.item.driverId).trigger("change");
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
            $("#searchEditoilCardId").select2().val("").trigger("change");
            this.item.amount= 0;
            this.item.totalAmount= 0;
            this.item.auditingAmount= 0;
            this.item.driverId= "";
            $("#searchEditdriverId").select2().val("").trigger("change");
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
        $("#searchOilCardId").select2().on("change", function (e) { main.queryEntity.oilCardId = $("#searchOilCardId").val(); });
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
            oilCardId:"", 
            driverId:"", 
            dateFrom:"", 
            dateTo: "",
            status:""
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.code="";
            this.queryEntity.oilCardId="";
            this.queryEntity.driverId="";
            this.queryEntity.dateFrom=""; 
            this.queryEntity.dateTo="";
            $("#searchOilCardId").select2().val("").trigger("change");
            $("#searchDriverId").select2().val("").trigger("change");
            $("#searchStatus").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.applicationForBunkerA.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.applicationForBunkerA.delete(id)
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



