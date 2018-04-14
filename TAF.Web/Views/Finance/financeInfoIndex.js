Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#budgetYearFormBody",
    data: function () {
        return {
            item: {
                id: "",            
                category: "",
                value: "",
                value2: "",
                value3: "",
                title:""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            $this.item.value2 = $this.item.value + "-01-01";
            $this.item.value3 = parseInt($this.item.value) + 1 + "-03-31";
            abp.services.app.sysDictionary.saveYearAsync($this.item)
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
            abp.services.app.sysDictionary.get(id)
                .done(function (m) {
                    $this.item = m;
                    $this.item.title= main.title;
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item = {category:main.category,title:main.title};
            this.$resetValidation();
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var $this = this;
        $this.title = "年度";
        $this.category = "Budget_Year";
        $this.queryEntity.category = $this.category;
        $("#myTab").on("shown.bs.tab", function(e) {
            console.log(e.target);
            var id = $(e.target).attr("id");
            if (id === "year") {
                $this.title = "年度";
                $this.category = "Budget_Year";
            }
            $this.queryEntity.category = $this.category;
            $this.query(0);
        });
    },
    data: {
        queryEntity: {
            category:"", 
            value:""
        },
        category: '',
        title:''
    },
    events: {
        
    },
    methods: {
        search:function(category) {
            this.queryEntity.category = category;
            this.query();
        },
        excuteQuery: function ($this) {
            abp.services.app.sysDictionary.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        resetSearch: function () {
            this.queryEntity.value="";
            this.queryEntity.note="";
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
        },
        newItem: function (title, category) {
            this.title = title;
            this.category = category;
            $("#addItemModal").modal("show");
            this.$broadcast('onAddItem', title);
        }
    }
});


main.query(0);



