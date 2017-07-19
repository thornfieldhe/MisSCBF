var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $this.query(0);
        var datePickerValidDrivingLicense = $('#datePickerValidDrivingLicense').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
                datePickerValidDrivingLicense.hide();
                $this.item.validDrivingLicense = $("#datePickerValidDrivingLicense").val();
            })
            .on('hide', function (event) {
                event.preventDefault();
                event.stopPropagation();
            })
            .data('datepicker');
        $("#searchEditLevel").select2()
        .on("change", function (e) {
            $this.item.level = $("#searchEditLevel").val();
        });   
    },
    data: {
        queryEntity: {
            name:"", 
            soldierId:"", 
            validDrivingLicenseFrom:"", 
            validDrivingLicenseTo:"", 
            drivingLicense:"", 
            level:"", 
            phoneNumber: ""
        },
        list: {
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: taf.defatulPageSize, //每页显示1项  
                callback: function (index, jq) {
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total ? main.list.pageSize * (index + 1) : main.list.total;
                    main.queryEntity.skipCount = taf.defatulPageSize * index;
                    abp.services.app.driver.getAll(main.queryEntity)
                        .done(function (r) {
                            main.list.items = r.items;
                            main.list.total = r.totalCount;

                        })
                        .fail(function (r) {
                            $this.fail(r);
                        });
                }
            }
        }
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteDriverDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.driver.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteDriverDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyDriverDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.driver.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#searchEditLevel").select2().val($this.item.level).trigger("change");
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }else {
                $this.clear();
            }
        },
        save:function() {
            var $this = this;
            abp.services.app.driver.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyDriverDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        saveNew:function() {
            var $this = this;
            abp.services.app.driver.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $this.clear();
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        clear: function () {
            this.item = {
                id: "00000000-0000-0000-0000-000000000000",
                name: "",
                soldierId: "",
                validDrivingLicense: "",
                drivingLicense: "",
                level: "",
                phoneNumber: ""
            };
            $("#searchEditLevel").select2().val("").trigger("change");
            this.$resetValidation();
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.driver.getAll($this.queryEntity)
            .done(function (r) {
                $this.list.items = r.items;
                $this.list.total = r.totalCount;
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total ? main.list.pageSize * (index + 1) : main.list.total;
                    $this.list.index = index;
                $(".pagination").pagination(r.totalCount, $this.list.options);
            })
            .fail(function (r) {
                $this.fail(r);
            });
        }
    }
});




