Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#oilCardProofFormBody",
    ready: function () {
        var $this = this;
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
                month: "",
                bunkerACode: "",
                date: "",
                ss: 0,
                msjg: 0,
                cardNo: "",
                carCode: "",
                clxh: "",
                cph: "",
                sy: "",
                yyje: 0,
                jyje: 0,
                syje: 0,
                ylbh: 0,
                jsy: 0,
                note: 0
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.oilCardProof.saveAsync($this.item)
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
            abp.services.app.oilCardProof.get(id)
                .done(function (m) {
                    $this.item = m;
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.month= "";
            this.item.bunkerACode= "";
            this.item.date= "";
            this.item.ss= 0;
            this.item.msjg= 0;
            this.item.cardNo= "";
            this.item.carCode= "";
            this.item.clxh= "";
            this.item.cph= "";
            this.item.sy= "";
            this.item.yyje= 0;
            this.item.jyje= 0;
            this.item.syje= 0;
            this.item.ylbh= 0;
            this.item.jsy= 0;
            this.item.note= 0;
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
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
            month:"", 
            bunkerACode:"", 
            dateFrom:"", 
            dateTo:"", 
            cardNo:"", 
            carCode:"", 
            clxh:"", 
            cph:"", 
            sy:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.month="";
            this.queryEntity.bunkerACode="";
            this.queryEntity.dateFrom=""; 
            this.queryEntity.dateTo="";
            this.queryEntity.cardNo="";
            this.queryEntity.carCode="";
            this.queryEntity.clxh="";
            this.queryEntity.cph="";
            this.queryEntity.sy="";
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.oilCardProof.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.oilCardProof.delete(id)
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



