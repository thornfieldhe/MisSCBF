var main = new Vue({
    el: "#main",
    ready: function () {
        $("#searchStorageId").select2().on("change", function (e) { main.queryEntity.storageId = $("#searchStorageId").val(); });
        this.load();
    },
    data: {
        queryEntity: {
            storageId: "",
            code: "",
            isSpecial: false
        },
        item: {
            items: []
        },
        temp: -1,
        isReadOnly:false
    },
    events: {

    },
    methods: {
        load: function () {
            var $this = this;
            abp.services.app.deliveryBill.new()
                .done(function (m) {
                    $this.item = m;
                })
                .fail(function (r) {
                    if (r.validationErrors !== null) {
                        taf.notify.danger(r.validationErrors[0].message);
                    } else if (r.details !== null) {
                        taf.notify.danger(r.details);
                    } else {
                        taf.notify.danger(r.message);
                    }
                });

        },
        add: function () {
            var $this = this;
            abp.services.app.delivery.entry($this.queryEntity)
                .done(function (m) {
                    $this.item.items.push(m);
                    $this.queryEntity.code = "";
                    $("#code").focus();
                    console.log(m);
                })
                .fail(function (r) {
                    if (r.validationErrors !== null) {
                        taf.notify.danger(r.validationErrors[0].message);
                    } else if (r.details !== null) {
                        taf.notify.danger(r.details);
                    } else {
                        taf.notify.danger(r.message);
                    }
                });
        },
        edit: function (item) {
            item.status = true;
            this.temp = item.amount;
        },
        delete: function (item) {
            this.item.items.$remove(item);
        },
        cancel: function (item) {
            item.status = false;
            item.amount = this.temp;
        },
        update: function (item) {
            item.status = false;
        },
        save: function () {
            var $this = this;
            abp.services.app.deliveryBill.saveAsync($this.item)
                .done(function (m) {
                    $this.item.items = m;
                    $this.isReadOnly = true;
                })
                .fail(function (r) {
                    if (r.validationErrors !== null) {
                        taf.notify.danger(r.validationErrors[0].message);
                    } else if (r.details !== null) {
                        taf.notify.danger(r.details);
                    } else {
                        taf.notify.danger(r.message);
                    }
                });
        },
        clear:function() {
            this.item.items = [];
            this.isReadOnly = false;
            this.load();
            this.queryEntity.code = "";
            $("#code").focus();
        }
    }
});




