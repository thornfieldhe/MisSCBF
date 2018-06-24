var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function() {
        var $this = this;
        $this.query(0);
    },
    data:
    {
        queryEntity: {
            code: "",
            name: "",
            category: "",
            mode: "",
            department: "",
            user: "",
            date: "",
            type: ""
        },
        list: {
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries:
                    4, //主体页数
                items_per_page:
                    taf.defatulPageSize, //每页显示1项  
                callback:
                    function(index, jq) {
                        main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                        main.list.index = index;
                        main.list.to = main.list.pageSize * (index + 1) < main.list.total
                            ? main.list.pageSize * (index + 1)
                            : main.list.total;
                        main.queryEntity.skipCount = taf.defatulPageSize * index;
                    }
            }
        },
        list2: [],
        list3: [],
        list4: [],
        list5: [],
        list6: [],
        list7: [],
        list8: [],
    },
    methods: {
        query: function(index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.procurementPlan.getAll($this.queryEntity)
                .done(function(r) {
                    $this.list.items = r.items;
                    $this.list.total = r.totalCount;
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total
                        ? main.list.pageSize * (index + 1)
                        : main.list.total;
                    $this.list.index = index;
                    $(".pagination").pagination(r.totalCount, $this.list.options);
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        },
        resetSearch: function() {
            this.queryEntity.code = "";
            this.queryEntity.name = "";
        },
        view: function(id) {
            var $this = this;
            abp.services.app.projectManagement.getAttachments(id)
                .done(function(r) {
                    var $r = r;
                    abp.services.app.attachment.getAll($r[0])
                        .done(function(r) {
                            $this.list2 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });

                    abp.services.app.attachment.getAll($r[1])
                        .done(function(r) {
                            $this.list3 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                    abp.services.app.attachment.getAll($r[2])
                        .done(function(r) {
                            $this.list4 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                    abp.services.app.attachment.getAll($r[3])
                        .done(function(r) {
                            $this.list5 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                    abp.services.app.attachment.getAll($r[4])
                        .done(function(r) {
                            $this.list6 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                    abp.services.app.attachment.getAll($r[5])
                        .done(function(r) {
                            $this.list7 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                    abp.services.app.attachment.getAll($r[6])
                        .done(function(r) {
                            $this.list8 = r;
                        })
                        .fail(function(r) {
                            $this.fail(r);
                        });
                   
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        }
    }
});

