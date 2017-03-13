Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#productFormBody",
    ready: function () {
        var $this = this;
        var spinboxUnitConversion = $('#spinboxUnitConversion').spinbox('value', 0);
        spinboxUnitConversion.options.max = 100;
        spinboxUnitConversion.options.min= 0;
    },
    data: function () {
        return {
            item: {
                id: "",            
                name: "",
                specifications: "",
                pYCode: "",
                unit: "",
                unit2: "",
                unitConversion: 0,
                color: "",
                note1: "",
                note2: "",
                order: ""
            }
        };
    },
    events: {
        'onSaveItem': function () {
            var $this = this;
            $this.item.unitConversion = $('#unitConversion').val();
            abp.services.app.product.saveAsync($this.item)
            .done(function (m) {
                $this.done();
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.product.get(id)
                .done(function (m) {
                    $this.item = m;
                    $('#spinboxUnitConversion').spinbox('value',$this.item.unitConversion);
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.name= "";
            this.item.specifications= "";
            this.item.pYCode= "";
            this.item.unit= "";
            this.item.unit2= "";
            this.item.unitConversion= 0;
            $('#spinboxUnitConversion').spinbox('value', 0);
            this.item.color= "";
            this.item.note1= "";
            this.item.note2= "";
            this.item.order= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
    },
    data: {
        queryEntity: {
            name:"", 
            specifications:"", 
            pYCode:"", 
            unit:"", 
            unit2:"", 
            color:"", 
            note1:"", 
            note2:"", 
            order:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.name="";
            this.queryEntity.specifications="";
            this.queryEntity.pYCode="";
            this.queryEntity.unit="";
            this.queryEntity.unit2="";
            this.queryEntity.color="";
            this.queryEntity.note1="";
            this.queryEntity.note2="";
            this.queryEntity.order="";
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.product.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.product.delete(id)
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



