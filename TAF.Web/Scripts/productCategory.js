Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#productCategoryFormBody",
    ready: function () {
        var $this = this;
        var order = $('#spinboxOrder').spinbox('value', 0);
        order.options.max = 100;
        order.options.min = 0;
    },
    data: function () {
        return {
            item: {
                category:''
            }
        };
    },
    events: {
        'onSaveItem': function () {
            var $this = this;
            abp.services.app.layer.saveAsync($this.item)
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
            abp.services.app.layer.get(id)
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
            $('#spinboxOrder').spinbox('value', 0);
        }
    }
});

var main = new Vue({
    el: "#main",
    ready: function () {
    },
    data: {},
    events: {},
    methods: {
        newItem: function () {
            console.log(0);
            $("#addItemModal").modal("show");
            this.$broadcast('onAddItem', "新增");
        }
    }
});