Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#sysDictionaryFormBody",
    ready: function () {
        var $this = this;
        $("#category").select2().on("change", function (e) { $this.item.category = $("#category").val(); });
    },
    data: function () {
        return {
            item: {
                id: "00000000-0000-0000-0000-000000000000",            
                value: "",
                note: "",
                category: "",
                value2: "",
                value3: "",
                value4: "",
                value5: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.sysDictionary.saveAsync($this.item)
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
            this.clearItem();
            abp.services.app.sysDictionary.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#category").select2().val(m.category).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "00000000-0000-0000-0000-000000000000";
            this.item.value= "";
            this.item.note= "";
            this.item.category= "";
            this.item.value2= "";
            this.item.value3= "";
            this.item.value4= "";
            this.item.value5= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchCategory").select2().on("change", function (e) { main.queryEntity.category = $("#searchCategory").val(); });
    },
    data: {
        queryEntity: {
            value:"", 
            note:"", 
            category:"", 
            value2:"", 
            value3:"", 
            value4:"", 
            value5:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.value="";
            this.queryEntity.note="";
            this.queryEntity.category="";
            this.queryEntity.value2="";
            this.queryEntity.value3="";
            this.queryEntity.value4="";
            this.queryEntity.value5 = "";
            $("#searchCategory").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.sysDictionary.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.sysDictionary.delete(id)
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



