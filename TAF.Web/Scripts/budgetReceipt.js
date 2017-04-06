Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#budgetReceiptFormBody",
    ready: function () {
        var $this = this;
        var spinboxYear = $('#spinboxYear').spinbox('value', 0);
        spinboxYear.options.max = 100;
        spinboxYear.options.min= 0;
        var spinboxType = $('#spinboxType').spinbox('value', 0);
        spinboxType.options.max = 100;
        spinboxType.options.min= 0;
    },
    data: function () {
        return {
            item: {
                id: "",            
                code: "",
                year: 0,
                type: 0,
                column1: "",
                note1: "",
                column21: "",
                note21: "",
                column22: "",
                note22: "",
                column31: "",
                note31: "",
                column32: "",
                note32: "",
                column33: "",
                note33: "",
                column34: "",
                note34: "",
                column35: "",
                note35: "",
                column36: "",
                note36: "",
                column41: "",
                note41: "",
                column42: "",
                note42: "",
                column43: "",
                note43: "",
                column44: "",
                note44: "",
                column45: "",
                note45: "",
                column46: "",
                note46: "",
                column47: "",
                note47: "",
                column5: "",
                note5: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            $this.item.year = $('#year').val();
            $this.item.type = $('#type').val();
            abp.services.app.budgetReceipt.saveAsync($this.item)
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
            abp.services.app.budgetReceipt.get(id)
                .done(function (m) {
                    $this.item = m;
                    $('#spinboxYear').spinbox('value',$this.item.year);
                    $('#spinboxType').spinbox('value',$this.item.type);
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
            this.item.year= 0;
            $('#spinboxYear').spinbox('value', 0);
            this.item.type= 0;
            $('#spinboxType').spinbox('value', 0);
            this.item.column1= "";
            this.item.note1= "";
            this.item.column21= "";
            this.item.note21= "";
            this.item.column22= "";
            this.item.note22= "";
            this.item.column31= "";
            this.item.note31= "";
            this.item.column32= "";
            this.item.note32= "";
            this.item.column33= "";
            this.item.note33= "";
            this.item.column34= "";
            this.item.note34= "";
            this.item.column35= "";
            this.item.note35= "";
            this.item.column36= "";
            this.item.note36= "";
            this.item.column41= "";
            this.item.note41= "";
            this.item.column42= "";
            this.item.note42= "";
            this.item.column43= "";
            this.item.note43= "";
            this.item.column44= "";
            this.item.note44= "";
            this.item.column45= "";
            this.item.note45= "";
            this.item.column46= "";
            this.item.note46= "";
            this.item.column47= "";
            this.item.note47= "";
            this.item.column5= "";
            this.item.note5= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
    },
    data: {
        queryEntity: {
            code:"", 
            column1:"", 
            note1:"", 
            column21:"", 
            note21:"", 
            column22:"", 
            note22:"", 
            column31:"", 
            note31:"", 
            column32:"", 
            note32:"", 
            column33:"", 
            note33:"", 
            column34:"", 
            note34:"", 
            column35:"", 
            note35:"", 
            column36:"", 
            note36:"", 
            column41:"", 
            note41:"", 
            column42:"", 
            note42:"", 
            column43:"", 
            note43:"", 
            column44:"", 
            note44:"", 
            column45:"", 
            note45:"", 
            column46:"", 
            note46:"", 
            column47:"", 
            note47:"", 
            column5:"", 
            note5:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.code="";
            this.queryEntity.column1="";
            this.queryEntity.note1="";
            this.queryEntity.column21="";
            this.queryEntity.note21="";
            this.queryEntity.column22="";
            this.queryEntity.note22="";
            this.queryEntity.column31="";
            this.queryEntity.note31="";
            this.queryEntity.column32="";
            this.queryEntity.note32="";
            this.queryEntity.column33="";
            this.queryEntity.note33="";
            this.queryEntity.column34="";
            this.queryEntity.note34="";
            this.queryEntity.column35="";
            this.queryEntity.note35="";
            this.queryEntity.column36="";
            this.queryEntity.note36="";
            this.queryEntity.column41="";
            this.queryEntity.note41="";
            this.queryEntity.column42="";
            this.queryEntity.note42="";
            this.queryEntity.column43="";
            this.queryEntity.note43="";
            this.queryEntity.column44="";
            this.queryEntity.note44="";
            this.queryEntity.column45="";
            this.queryEntity.note45="";
            this.queryEntity.column46="";
            this.queryEntity.note46="";
            this.queryEntity.column47="";
            this.queryEntity.note47="";
            this.queryEntity.column5="";
            this.queryEntity.note5="";
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.budgetReceipt.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.budgetReceipt.delete(id)
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



