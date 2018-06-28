Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#rechargeRecordFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditOilCardId").select2()
            .on("change", function (e) {
                if ($("#searchEditOilCardId").val()!=="") {
                    abp.services.app.oilCard.getAmount($("#searchEditOilCardId").val())
                        .done(function (m) {
                            $this.item.hisAmount = m;
                            $this.item.oilCardId = $("#searchEditOilCardId").val();
                        })
                        .fail(function (m) {
                            $this.fail(m);
                        });
                }
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
    },
    data: function () {
        return {
            item: {
                id: "",            
                oilCardId: "",
                amount: 0,
                hisAmount: 0,
                date: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.rechargeRecord.saveAsync($this.item)
            .done(function (m) {
                $this.done(closeModal);
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.rechargeRecord.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditOilCardId").select2().val($this.item.oilCardId).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.oilCardId= "";
            $("#searchEditOilCardId").select2().val("").trigger("change");
            this.item.amount= 0;
            this.item.hisAmount= 0;
            this.item.date= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchOilCardId").select2().on("change", function (e) { main.queryEntity.oilCardId = $("#searchOilCardId").val(); });
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
            oilCardId:"", 
            dateFrom:"", 
            dateTo:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.oilCardId="";
            this.queryEntity.dateFrom=""; 
            this.queryEntity.dateTo="";
            $("#searchOilCardId").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.rechargeRecord.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.rechargeRecord.delete(id)
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



