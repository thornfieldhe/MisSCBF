Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#sysDictionaryFormBody",
    ready: function () {
        var $this = this;
    },
    data: function () {
        return {
            item: {
                id: "",            
                category: "",
                value: "",
                note: "",
                title:""
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
        $this.title = "颜色";
        $this.category = "ProductColor";
        $this.queryEntity.category = $this.category;
        $("#myTab").on("shown.bs.tab", function(e) {
            console.log(e.target);
            var id = $(e.target).attr("id");
            if (id === "pcolor") {
                $this.title = "颜色";
                $this.category = "ProductColor";
            } else if (id === "pstorage") {
                $this.title = "仓库";
                $this.category = "Storage";
            } else {
                $this.title = "品牌";
                $this.category = "ProductBrand";
            }
            $this.queryEntity.category = $this.category;
            $this.query(0);
        });
    },
    data: {
        queryEntity: {
            category:"", 
            value:"", 
            note:"" 
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
            console.log(123);
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



