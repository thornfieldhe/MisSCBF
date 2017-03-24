var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchStorageId").select2().on("change", function (e) { main.queryEntity.storageId = $("#searchStorageId").val(); });
        $("#searchIsSpecial").select2().on("change", function (e) { main.queryEntity.isSpecial = $("#searchIsSpecial").val(); });
    },
    data: {
        queryEntity: {
            storageId:"", 
            code:"", 
            note:"", 
            isSpecial:false        
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.storageId="";
            this.queryEntity.code="";
            this.queryEntity.note="";
            this.queryEntity.isSpecial=false;      
            $("#searchStorageId").select2().val("").trigger("change");
            $("#searchIsSpecial").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.entryBill.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.entryBill.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    }
});




